Imports System.Web.Mvc

Namespace Controllers

    <AuthorizationFilter()>
    Public Class AirlineController
        Inherits Controller

        Private services As New Services.ServiceOrderServices()

        Function ManageAirlineMasterData() As ActionResult
            Return View(services.GetAirlineMasterDatas())
        End Function

        Function AddAirlineMasterData() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function AddAirlineMasterData(model As Entities.AirlineMasterData) As ActionResult
            If ModelState.IsValid Then
                services.AddAirlineMasterData(model)
                'log
                Helpers.Log(Helpers.LogType.AddData, Helpers.GetCurrentUser().id, model.Id, "AirlineMasterData")
                Return RedirectToAction("ManageAirlineMasterData")
            End If
            Return View(model)
        End Function

        Function EditAirlineMasterData(id As Integer) As ActionResult
            Return View(services.GetAirlineMasterData(id))
        End Function

        <HttpPost()>
        Function EditAirlineMasterData(model As Entities.AirlineMasterData) As ActionResult
            If ModelState.IsValid Then
                'log
                Helpers.Log(Helpers.LogType.EditData, Helpers.GetCurrentUser().id, model.Id, "AirlineMasterData")
                services.EditAirlineMasterData(model)
                Return RedirectToAction("ManageAirlineMasterData")
            End If
            Return View(model)
        End Function

        <HttpPost()>
        Function RemoveAirlineMasterData(id As Integer) As ActionResult
            'log
            Helpers.Log(Helpers.LogType.DeleteData, Helpers.GetCurrentUser().id, id, "AirlineMasterData")
            services.RemoveAirlineMasterData(id)
            Return RedirectToAction("ManageAirlineMasterData")
        End Function

    End Class
End Namespace