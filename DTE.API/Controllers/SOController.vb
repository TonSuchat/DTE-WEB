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
            Return Ok("SONumber")
        End Function

    End Class
End Namespace