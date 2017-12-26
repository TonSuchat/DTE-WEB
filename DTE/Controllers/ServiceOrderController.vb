Imports System.IO
Imports DTE.Entities
Imports DTE.Services

Namespace Controllers

    <AuthorizationFilter()>
    Public Class ServiceOrderController
        Inherits Controller

        Private services As New ServiceOrderServices
        Function Index() As ActionResult
            Return View()
        End Function

        Function ManageServiceOrder() As ActionResult
            Return View(GetManageServiceOrderViewModel(Date.Now(), Date.Now()))
        End Function

        <HttpPost()>
        Function ManageServiceOrder(model As ManageServiceOrderViewModel) As ActionResult
            Return View(GetManageServiceOrderViewModel(model.SelectedStartDate, model.SelectedEndDate))
        End Function

        Function AddServiceOrder() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function AddServiceOrder(model As Transaction, hdUploadImage As String) As ActionResult

            Dim inputSO = New ServiceOrder.InputSPInsertSO() With {
                .AircraftCarrier = model.AircraftCarrier,
                .AircraftReg = model.AircraftReg,
                .AircraftType = model.AircraftType,
                .CondOfCharge = "",
                .CreateBy = Helpers.GetCurrentUser.id,
                .CustIDStart = "",
                .CustIDStop = "",
                .CustSignStart = "",
                .CustSignStop = "",
                .DateNow = DateTime.Now(),
                .ETA = model.ETA,
                .ETD = model.ETD,
                .FlightNo = model.FlightNo,
                .GateNo = model.GateNo,
                .GPU1 = model.GPU1,
                .GPU2 = model.GPU2,
                .GPUEnd = model.GPUEnd,
                .GPUStart = model.GPUStart,
                .GPUTotalMin = model.GPUTotalMin,
                .PCA1 = model.PCA1,
                .PCA2 = model.PCA2,
                .PCAEnd = model.PCAEnd,
                .PCAStart = model.PCAStart,
                .PCATotalMin = model.PCATotalMin,
                .Remark = model.Remark,
                .Station = model.Station
                }
            'add transaction
            Dim result = services.ExecuteStoredInsertSO(inputSO)

            If result.Success = 1 Then
                'add upload image
                If Not String.IsNullOrEmpty(hdUploadImage) Then
                    'insert upload images
                    services.AddUploadImage(New UploadImage() With {.WONumber = result.RetMsg, .objectImage = hdUploadImage})
                End If
                Return RedirectToAction("ManageServiceOrder")
            End If

            ModelState.AddModelError("", result.RetMsg)
            Return View(model)
        End Function

        Private Function GetManageServiceOrderViewModel(selectedStartDate As Date, selectedEndDate As Date)
            Dim result As New ManageServiceOrderViewModel()
            result.SelectedStartDate = selectedStartDate
            result.SelectedEndDate = selectedEndDate
            result.TransactionsDetail = services.GetTransactionsDetail(result.SelectedStartDate, result.SelectedEndDate)
            Return result
        End Function

        Function Detail(id As Integer) As ActionResult
            Return View(services.GetTransactionDetail(id))
        End Function

        Function EditSO(id As Integer) As ActionResult
            Return View(services.GetTransaction(id))
        End Function

        <HttpPost()>
        Function EditSO(model As Transaction) As ActionResult
            Try
                If ModelState.IsValid Then
                    model.UpdateDate = DateTime.Now()
                    model.UpdateBy = Helpers.GetCurrentUser.id
                    're calculate service-rate
                    Dim serviceRate = services.GetServiceRate(model.AircraftType, model.PCATotalMin, model.GPUTotalMin)
                    model.ServiceRate = serviceRate
                    'edit transaction
                    services.EditTransaction(model)
                    'log
                    Helpers.Log(Helpers.LogType.EditData, Helpers.GetCurrentUser.id, model.id, "Transaction")
                    'redirect to manageIndex
                    Return RedirectToAction("ManageServiceOrder")
                End If
            Catch ex As Exception
                ModelState.AddModelError("ManageServiceOrder", ex.ToString())
            End Try
            Return View(model)
        End Function

        <HttpPost()>
        Function RemoveSO(model As RemoveServiceOrderViewModel) As ActionResult
            services.RemoveTransaction(model.id)
            'log
            Helpers.Log(Helpers.LogType.DeleteData, Helpers.GetCurrentUser().id, model.id, "Transaction")
            Return View("ManageServiceOrder", GetManageServiceOrderViewModel(model.removeSelectedStartDate, model.removeSelectedEndDate))
        End Function

        'Function ExportExcel() As ActionResult
        '    Return View()
        'End Function

        <HttpPost()>
        Function ExportExcel(model As ExportExcelViewModel) As ActionResult
            Try
                Dim dt As DataTable = services.GetDtTransactions(model.ExcelSelectedStartDate, model.ExcelSelectedEndDate)
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    Dim fileName As String = String.Format("SO_{0}", model.ExcelSelectedStartDate.ToString("yyyyMMdd"))
                    Dim grid As New GridView()
                    grid.DataSource = dt
                    grid.DataBind()

                    Response.ClearContent()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", "attachment; filename=" & fileName & ".xls")
                    Response.ContentType = "application/ms-excel"

                    Response.Charset = ""
                    Dim sw As New StringWriter()
                    Dim htw As New HtmlTextWriter(sw)

                    grid.RenderControl(htw)

                    Response.Output.Write(sw.ToString())
                    Response.Flush()
                    Response.End()
                Else : ModelState.AddModelError("", "ไม่พบข้อมูลในวันที่เลือก")
                End If
                Return View("ManageServiceOrder", GetManageServiceOrderViewModel(model.ExcelSelectedStartDate, model.ExcelSelectedEndDate))
            Catch ex As Exception
                Helpers.LogTxt(ex.ToString())
                ModelState.AddModelError("", "เกิดข้อผิดพลาด " & ex.ToString())
                Return View("ManageServiceOrder", GetManageServiceOrderViewModel(model.ExcelSelectedStartDate, model.ExcelSelectedEndDate))
            End Try
        End Function

    End Class

End Namespace