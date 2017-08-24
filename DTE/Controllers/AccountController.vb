Imports System.Web.Mvc

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Private services As New Services.ServiceOrderServices()

        Function LogIn() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function LogIn(model As LogInViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim user = services.GetUser(model.UserName, model.Password)
                If IsNothing(user) Then
                    ModelState.AddModelError("", "UserName/Password ผิด")
                Else
                    'log
                    Helpers.Log(Helpers.LogType.LogIn, user.id)
                    Helpers.SetCurrentUser(user)
                    'redirect
                    RedirectToAction("Index", "Home")
                End If
            End If
            Return View(model)
        End Function

        Public Function LogInAdmin() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Public Function LogInAdmin(model As LogInViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim user = services.GetUserAdmin(model.UserName, model.Password)
                If IsNothing(user) Then
                    ModelState.AddModelError("", "UserName/Password ผิด/ User อาจไม่มีสิทธิ์เข้าสู่ระบบแบบ Admin")
                Else
                    'log
                    Helpers.Log(Helpers.LogType.LogIn, user.id)
                    'keep current user in session
                    Helpers.SetCurrentUser(user)
                    'redirect
                    Return RedirectToAction("Index", "Home")
                End If
            End If
            Return View(model)
        End Function

        <HttpPost()>
        Public Function LogOff()
            'log
            Helpers.Log(Helpers.LogType.LogOut, Helpers.GetCurrentUser().id)
            Helpers.ClearCurrentUser()
            Return RedirectToAction("Index", "Home")
        End Function

    End Class
End Namespace