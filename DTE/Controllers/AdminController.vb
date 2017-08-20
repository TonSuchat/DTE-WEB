Imports System.Web.Mvc

Namespace Controllers

    <AuthorizationFilter(Roles:="Administrator")>
    Public Class AdminController
        Inherits Controller

        Private services As New Services.ServiceOrderServices()

        Function ManageUser() As ActionResult
            Return View(services.GetUsers())
        End Function

        Function AddUser() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function AddUser(model As Entities.User) As ActionResult
            If ModelState.IsValid Then
                services.AddUser(model)
                'log
                Helpers.Log(Helpers.LogType.AddData, Helpers.GetCurrentUser().id, model.id, "User")
                Return RedirectToAction("ManageUser")
            End If
            Return View(model)
        End Function

        <HttpPost()>
        Function RemoveUser(id As Integer) As ActionResult
            'log
            Helpers.Log(Helpers.LogType.DeleteData, Helpers.GetCurrentUser().id, id, "User")
            services.RemoveUser(id)
            Return RedirectToAction("ManageUser")
        End Function

        Function Log() As ActionResult
            Return View(services.GetViewLogs())
        End Function

    End Class
End Namespace