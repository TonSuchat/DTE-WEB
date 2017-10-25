Imports System.IO
Imports System.Web.Mvc

Namespace Controllers

    <AuthorizationFilter()>
    Public Class FlightDataController
        Inherits Controller

        Private services As New Services.ServiceOrderServices()

        Function ManageFlightData() As ActionResult
            Return View(services.GetFlightDatas())
        End Function

        Function AddFlightData() As ActionResult
            ViewBag.Type = "Add"
            Return View("AddOrEditFlightData", New FlightDataViewModel())
        End Function

        <HttpPost()>
        Function AddFlightData(model As FlightDataViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim result = TransformFlightDataViewModelToFlightData(model)
                services.AddFlightData(result)
                'gen new sequence
                services.GenerateNewSequence()
                'log
                Helpers.Log(Helpers.LogType.AddData, Helpers.GetCurrentUser().id, result.id, "FlightData")
                Return RedirectToAction("ManageFlightData")
            End If
            Return View(model)
        End Function

        Function ImportExcel() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Public Function ImportExcel(collection As FormCollection) As ActionResult
            Dim filepath As String = ""
            Try
                If Not IsNothing(Request) Then
                    Dim file = Request.Files("uploadFile")
                    If Not IsNothing(file) AndAlso file.ContentLength > 0 AndAlso Not String.IsNullOrEmpty(file.FileName) Then
                        'validate file format
                        Dim validExtensions As New List(Of String) From {".csv", ".xlsx"}
                        Dim filename As String = file.FileName
                        'validate file name
                        If filename.Replace(".xlsx", "").Replace(".xls", "").Replace(".csv", "").Length = 8 Then
                            Dim uploadDirectory As String = Server.MapPath("~/Uploads")
                            filepath = String.Format("{0}\{1}", uploadDirectory, filename)
                            Dim fileExtension As String = IO.Path.GetExtension(filepath)
                            If validExtensions.Contains(fileExtension) Then
                                'create directory if not exist
                                If Not Directory.Exists(uploadDirectory) Then Directory.CreateDirectory(uploadDirectory)
                                'if it has recent file delete it
                                If IO.File.Exists(filepath) Then IO.File.Delete(filepath)
                                file.SaveAs(filepath)
                                Dim connectionString As String = ""
                                Dim dt As DataTable = Nothing
                                If fileExtension = ".csv" Then
                                    dt = Helpers.GetExcelDataCSV(filepath)
                                Else
                                    If fileExtension = ".xlsx" Then
                                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filepath & ";Extended Properties=""Excel 12.0;HDR=NO;IMEX=1"""
                                    ElseIf fileExtension = ".xls" Then
                                        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filepath & ";Extended Properties=""Excel 8.0;HDR=NO;IMEX=1\"""
                                    End If
                                    dt = Helpers.GetExcelData(connectionString)
                                End If
                                If Not IsNothing(dt) Then
                                    'import data
                                    services.ImportFlightDataByDatatable(dt, New Date(filename.Substring(0, 4), filename.Substring(4, 2), filename.Substring(6, 2)))
                                    'delete trash datas
                                    services.RemoveTrashFlightData()
                                    'gen new sequence
                                    services.GenerateNewSequence()
                                    Return RedirectToAction("ManageFlightData")
                                Else : ModelState.AddModelError("", "ไม่สามารถดึงข้อมูลจากไฟล์ได้")
                                End If
                            Else : ModelState.AddModelError("", "ไฟล์ไม่ถูกต้อง รองรับกสุลไฟล์ .xls, .xlsx เท่านั้น")
                            End If
                        Else : ModelState.AddModelError("", "ตั้งชื่อไฟล์ไม่ถูกต้อง ชื่อไฟล์ต้องมีแค่ 8 ตัว format yyyymmdd")
                        End If
                    Else : ModelState.AddModelError("", "ไม่พบไฟล์")
                    End If
                End If
                Return View()
            Catch ex As Exception
                Helpers.LogTxt(ex.ToString())
                ModelState.AddModelError("", "เกิดความผิดพลาดไม่สามารถ import file ได้ : " & ex.ToString())
                Return View()
            Finally
                If IO.File.Exists(filepath) Then IO.File.Delete(filepath)
            End Try
        End Function

        Function EditFlightData(id As Integer) As ActionResult
            ViewBag.Type = "Edit"
            Dim result = New FlightDataViewModel(services.GetFlightData(id))
            Return View("AddOrEditFlightData", result)
        End Function

        <HttpPost()>
        Function EditFlightData(model As FlightDataViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim result = TransformFlightDataViewModelToFlightData(model)
                'log
                Helpers.Log(Helpers.LogType.EditData, Helpers.GetCurrentUser().id, result.id, "FlightData")
                If services.EditFlightData(result) Then services.GenerateNewSequence() 'gen new sequence if edit flight template
                Return RedirectToAction("ManageFlightData")
            End If
            ViewBag.Type = "Edit"
            Return View("AddOrEditFlightData", model)
        End Function

        <HttpPost()>
        Function RemoveFlightData(id As Integer) As ActionResult
            services.RemoveFlightData(id)
            'log
            Helpers.Log(Helpers.LogType.DeleteData, Helpers.GetCurrentUser().id, id, "FlightData")
            Return RedirectToAction("ManageFlightData")
        End Function

        Private Function TransformFlightDataViewModelToFlightData(model As FlightDataViewModel) As Entities.FlightData
            Dim result = New Entities.FlightData() With {.id = model.id, .ACCarrier = model.ACCarrier, .ACReg = model.ACReg, .ACType = model.ACType, .CreateDate = model.CreateDate, .FlightNo = model.FlightNo, .GateNo = model.GateNo}
            'sta
            result.STA = New Date(model.SelectedDate.Year, model.SelectedDate.Month, model.SelectedDate.Day, model.STATime.Hour, model.STATime.Minute, 0)
            'std
            result.STD = New Date(model.SelectedDate.Year, model.SelectedDate.Month, model.SelectedDate.Day, model.STDTime.Hour, model.STDTime.Minute, 0)
            Return result
        End Function

    End Class
End Namespace