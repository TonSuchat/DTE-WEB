Imports System.Web.Mvc

Namespace Controllers

    <AuthorizationFilter(Roles:="Administrator,SuperUser")>
    Public Class AdminController
        Inherits Controller

        Private services As New Services.ServiceOrderServices()

        Function ManageUser() As ActionResult
            Return View(services.GetUsersByRole(Helpers.GetCurrentUser().Type))
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

        Function EditUser(id As Integer) As ActionResult
            Return View(services.GetUser(id))
        End Function

        <HttpPost()>
        Function EditUser(model As Entities.User) As ActionResult
            If ModelState.IsValid Then
                services.EditUser(model)
                'log
                Helpers.Log(Helpers.LogType.EditData, Helpers.GetCurrentUser().id, model.id, "User")
                Return RedirectToAction("ManageUser")
            End If
            Return View(model)
        End Function

        Function ChangePassword(id As Integer, userName As String) As ActionResult
            ViewBag.id = id
            ViewBag.userName = userName
            Return View()
        End Function

        <HttpPost()>
        Function ChangePassword(id As Integer, userName As String, newPassword As String) As ActionResult
            If id <> 0 AndAlso Not String.IsNullOrEmpty(newPassword) Then
                'change password
                services.ChangePassword(id, newPassword)
                'log
                Helpers.Log(Helpers.LogType.EditData, Helpers.GetCurrentUser().id, id, "User", "Admin-ChangePassword")
                Return RedirectToAction("ManageUser")
            End If
            ViewBag.id = id
            ViewBag.userName = userName
            ModelState.AddModelError("", "รหัสผ่านใหม่ต้องห้ามเป็นค่าว่าง")
            Return View()
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