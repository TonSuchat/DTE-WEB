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
                    Helpers.SetCurrentUser(user)
                    'redirect
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
                    ModelState.AddModelError("", "UserName/Password ผิด")
                Else
                    Helpers.SetCurrentUser(user)
                    'redirect
                End If
            End If
            Return View(model)
        End Function

    End Class
End Namespace