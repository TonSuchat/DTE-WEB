Imports System.Net
Imports System.Web.Http
Imports DTE.Services

Namespace Controllers
    Public Class SOController
        Inherits ApiController

        Private services As New ServiceOrderServices()

        <HttpPost()>
        Public Function Login(model As SORequestModels.Login) As IHttpActionResult
            Return Ok(services.GetUser(model.UserID, model.Password))
        End Function

        <HttpPost()>
        Public Function SaveSO(model As SORequestModels.SaveSO) As IHttpActionResult
            Dim inputSaveSO As New Entities.ServiceOrder.InputSPInsertSO() With {
                .AircraftCarrier = model.ACCarrier,
                .AircraftReg = model.ACReg,
                .AircraftType = model.ACType,
                .CondOfCharge = model.CondOfCharge,
                .CreateBy = model.UserID,
                .CustIDStart = model.CustIDStart,
                .CustIDStop = model.CustIDStop,
                .CustSignStart = model.CustSignStart,
                .CustSignStop = model.CustSignStop,
                .ETA = model.STA,
                .ETD = model.STD,
                .FlightNo = model.FlightNo,
                .GateNo = model.GateNo,
                .GPU1 = model.GPU1,
                .GPU2 = model.GPU2,
                .GPUEnd = model.GPUStop,
                .GPUStart = model.GPUStart,
                .GPUTotalMin = If(String.IsNullOrEmpty(model.GPUTotalMin), 0, model.GPUTotalMin),
                .PCA1 = model.PCA1,
                .PCA2 = model.PCA2,
                .PCAEnd = model.PCAStop,
                .PCAStart = model.PCAStart,
                .PCATotalMin = If(String.IsNullOrEmpty(model.PCATotalMin), 0, model.PCATotalMin),
                .Station = model.Station,
                .Remark = model.Remark
                }
            Dim result = services.ExecuteStoredInsertSO(inputSaveSO)
            If result.Success = 1 Then
                'if save from recall then remove temptransaction
                If model.RefId <> 0 Then
                    services.ProcessRemoveTempTransaction(model.RefId)
                    'remove recall upload image
                    services.RemoveUploadImagesByRefId(model.RefId)
                End If
                'insert new uploadimages
                If Not IsNothing(model.UploadImages) Then
                    'insert upload images
                    Dim uploadImgs As New List(Of Entities.UploadImage)
                    For Each img In model.UploadImages
                        uploadImgs.Add(New Entities.UploadImage() With {.WONumber = result.RetMsg, .objectImage = img})
                    Next
                    services.AddUploadImages(uploadImgs)
                End If
            End If
            Return Ok(New With {.success = result.Success, .message = result.RetMsg})
        End Function

        <HttpPost()>
        Public Function SaveTempSO(model As SORequestModels.SaveSO) As IHttpActionResult
            'find logo
            Dim tempTransaction As New Entities.TempTransaction() With {
                .AircraftCarrier = model.ACCarrier, .AircraftReg = model.ACReg,
                .AircraftType = model.ACType, .CondOfCharge = model.CondOfCharge,
                .CreateBy = model.UserID, .CustIDStart = model.CustIDStart,
                .CustIDStop = model.CustIDStop, .CustSignStart = model.CustSignStart,
                .CustSignStop = model.CustSignStop, .ETA = model.STA,
                .ETD = model.STD, .FlightNo = model.FlightNo, .GateNo = model.GateNo,
                .GPU1 = model.GPU1, .GPU2 = model.GPU2, .GPUEnd = model.GPUStop,
                .GPUStart = model.GPUStart, .GPUTotalMin = If(String.IsNullOrEmpty(model.GPUTotalMin), Nothing, model.GPUTotalMin),
                .PCA1 = model.PCA1, .PCA2 = model.PCA2, .PCAEnd = model.PCAStop,
                .PCAStart = model.PCAStart, .PCATotalMin = If(String.IsNullOrEmpty(model.PCATotalMin), Nothing, model.PCATotalMin),
                .Remark = model.Remark, .Station = model.Station, .Logo = services.GetAirlineLogo(model.ACCarrier)
                }
            Dim result = services.AddTempTransaction(tempTransaction)
            If result Then
                'insert upload images
                Dim uploadImgs As New List(Of Entities.UploadImage)
                For Each img In model.UploadImages
                    uploadImgs.Add(New Entities.UploadImage() With {.refId = tempTransaction.id, .objectImage = img})
                Next
                services.AddUploadImages(uploadImgs)
            End If
            Return Ok(New With {.success = If(result, 1, 0)})
        End Function

        <HttpPost()>
        Public Function UpdateTempSO(model As SORequestModels.SaveSO) As IHttpActionResult
            'find temptransaction by id
            Dim tempTransaction = services.GetTempTransaction(model.RefId)
            If IsNothing(tempTransaction) Then Return InternalServerError(New ArgumentException("ไม่พบข้อมูล S/O นี้"))
            tempTransaction.AircraftCarrier = model.ACCarrier
            tempTransaction.AircraftReg = model.ACReg
            tempTransaction.AircraftType = model.ACType
            tempTransaction.CondOfCharge = model.CondOfCharge
            tempTransaction.CreateBy = model.UserID
            tempTransaction.CustIDStart = model.CustIDStart
            tempTransaction.CustIDStop = model.CustIDStop
            tempTransaction.CustSignStart = model.CustSignStart
            tempTransaction.CustSignStop = model.CustSignStop
            tempTransaction.ETA = model.STA
            tempTransaction.ETD = model.STD
            tempTransaction.FlightNo = model.FlightNo
            tempTransaction.GateNo = model.GateNo
            tempTransaction.GPU1 = model.GPU1
            tempTransaction.GPU2 = model.GPU2
            tempTransaction.GPUEnd = model.GPUStop
            tempTransaction.GPUStart = model.GPUStart
            tempTransaction.GPUTotalMin = If(String.IsNullOrEmpty(model.GPUTotalMin), Nothing, model.GPUTotalMin)
            tempTransaction.PCA1 = model.PCA1
            tempTransaction.PCA2 = model.PCA2
            tempTransaction.PCAEnd = model.PCAStop
            tempTransaction.PCAStart = model.PCAStart
            tempTransaction.PCATotalMin = If(String.IsNullOrEmpty(model.PCATotalMin), Nothing, model.PCATotalMin)
            tempTransaction.Remark = model.Remark
            tempTransaction.Station = model.Station
            tempTransaction.Logo = services.GetAirlineLogo(model.ACCarrier)
            Dim result = services.UpdateTempTransaction(tempTransaction)
            If result Then Return Ok(New With {.success = If(result, 1, 0)}) Else Return InternalServerError(New ArgumentException("เกิดข้อผิดพลาดขณะทำการอัพเดตข้อมูล/โปรดติดต่อผู้ดูแลระบบ"))
        End Function

        <HttpPost()>
        Public Function DeleteTempSO(model As SORequestModels.DeleteTempSO) As IHttpActionResult
            Return Ok(services.ProcessRemoveTempTransaction(model.Id))
        End Function

        <HttpPost()>
        Public Function GetTempSO(model As SORequestModels.GetListRecall) As IHttpActionResult
            Dim models = services.GetTempTransactionsDetail(model.Station)
            Return Ok(models)
        End Function

        '<HttpPost()>
        'Public Function GetTempSO(id As Integer) As IHttpActionResult
        '    Dim model = services.GetTempTransaction(id)
        '    Return Ok(model)
        'End Function

        <HttpPost()>
        Public Function GetSO(model As SORequestModels.GetSO) As IHttpActionResult
            Dim models = services.GetTransactionsDetail(model.Station, model.SelectedDate)
            Return Ok(models)
        End Function

        <HttpPost()>
        Public Function GetSOIdByWONumber(model As SORequestModels.GetSOByWONumber) As IHttpActionResult
            Dim result = services.GetTransaction(model.WONumber)
            If IsNothing(result) Then Return Ok(0) Else Return Ok(result.id)
        End Function

        <HttpPost()>
        Public Function GetSOById(model As SORequestModels.GetSOById) As IHttpActionResult
            Return Ok(services.GetTransactionDetail(model.Id))
        End Function

        <HttpPost()>
        Public Function GetRecallById(model As SORequestModels.GetRecallById) As IHttpActionResult
            Return Ok(services.GetTransactionDetailByTempId(model.Id))
        End Function

        <HttpPost()>
        Public Function EditSO(model As SORequestModels.EditSO) As IHttpActionResult
            Return Ok()
        End Function

        <HttpPost()>
        Public Function DeleteSO(model As SORequestModels.DeleteSO) As IHttpActionResult
            Return Ok(services.RemoveTransaction(model.Id))
        End Function

        <HttpPost()>
        Public Function GetFlightData(model As SORequestModels.GetFlightData) As IHttpActionResult
            If String.IsNullOrEmpty(model.FlightDate) Then Return Ok(New EmptyResult())
            Dim year As Integer = CInt(model.FlightDate.Substring(0, 4))
            Dim month As Integer = CInt(model.FlightDate.Substring(4, 2))
            Dim day As Integer = CInt(model.FlightDate.Substring(6, 2))
            Dim selectedDate As New Date(year, month, day)
            Return Ok(services.GetFlightDatas(selectedDate.Date))
        End Function

        <HttpPost()>
        Public Function GetSequenceNo() As IHttpActionResult
            Return Ok(services.GetSequence().SequenceNo)
        End Function

        <HttpPost()>
        Public Function GetAirlineLogo(model As SORequestModels.GetAirlineLogo) As IHttpActionResult
            If String.IsNullOrEmpty(model.ACCarrier) Then Return Ok("")
            Return Ok(services.GetAirlineLogo(model.ACCarrier))
        End Function

        <HttpPost()>
        Public Function ChangePassword(model As SORequestModels.ChangePassword) As IHttpActionResult
            If model.UserId = 0 OrElse String.IsNullOrEmpty(model.NewPassword.Trim()) Then Return Ok(New With {.Success = False, .Message = "ไม่พบผู้ใช้งานนี้/รหัสผ่านใหม่ห้ามเป็นค่าว่าง"})
            'check the old password
            Dim user = services.GetUser(model.UserId)
            If IsNothing(user) Then Return Ok(New With {.Success = False, .Message = "ไม่พบผู้ใช้งานนี้"})
            If user.PWD <> model.OldPassword Then Return Ok(New With {.Success = False, .Message = "รหัสผ่านเก่าไม่ถูกต้อง"})
            'change password
            Dim response = services.ChangePassword(model.UserId, model.NewPassword)
            Return Ok(New With {.Success = response, .Message = If(response, "เปลี่ยนรหัสผ่านเรียบร้อย", "ไม่สามารถเปลี่ยนรหัสผ่านได้ โปรดแจ้ง Admin ตรวจสอบ Log")})
        End Function

    End Class
End Namespace