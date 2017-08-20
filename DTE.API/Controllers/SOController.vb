Imports System.Net
Imports System.Web.Http
Imports DTE.Services

Namespace Controllers
    Public Class SOController
        Inherits ApiController

        Private services As New ServiceOrderServices()

        <HttpPost()>
        Public Function Login(model As SORequestModels.Login) As IHttpActionResult
            Return Ok(services.Login(model.UserID, model.Password))
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
                .PCA1 = model.PCA1,
                .PCA2 = model.PCA2,
                .PCAEnd = model.PCAStop,
                .PCAStart = model.PCAStart,
                .Station = model.Station,
                .Remark = model.Remark
                }
            Dim result = services.ExecuteStoredInsertSO(inputSaveSO)
            If result.Success = 1 Then
                'insert upload images
                Dim uploadImgs As New List(Of Entities.UploadImage)
                For Each img In model.UploadImages
                    uploadImgs.Add(New Entities.UploadImage() With {.WONumber = result.RetMsg, .objectImage = img})
                Next
                services.AddUploadImages(uploadImgs)
            End If
            Return Ok(New With {.success = result.Success, .message = result.RetMsg})
        End Function

        <HttpPost()>
        Public Function GetSO(model As SORequestModels.GetSO) As IHttpActionResult
            Dim models = services.GetTransactions(model.UserId)
            Return Ok(models)
        End Function

        <HttpPost()>
        Public Function GetSOById(model As SORequestModels.GetSOById) As IHttpActionResult
            Dim result = services.GetTransactionDetail(model.Id)
            Return Ok(result)
        End Function

        <HttpPost()>
        Public Function EditSO(model As SORequestModels.EditSO) As IHttpActionResult

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

    End Class
End Namespace