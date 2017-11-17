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
                If IsNothing(user) OrElse user.Type = 4 Then
                    ModelState.AddModelError("", "UserName/Password ผิด")
                Else
                    'log
                    Helpers.Log(Helpers.LogType.LogIn, user.id)
                    Helpers.SetCurrentUser(user)
                    'redirect
                    Return RedirectToAction("Index", "Home")
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

        Public Function LogOff()
            'log
            Helpers.Log(Helpers.LogType.LogOut, Helpers.GetCurrentUser().id)
            Helpers.ClearCurrentUser()
            Return RedirectToAction("Index", "Home")
        End Function

        <AuthorizationFilter()>
        Public Function ChangePassword()
            Return View()
        End Function

        <AuthorizationFilter()>
        <HttpPost()>
        Public Function ChangePassword(model As ChangePasswordViewModel)
            If ModelState.IsValid Then
                'check old password
                If model.OldPassword = Helpers.GetCurrentUser().PWD Then
                    'change password
                    services.ChangePassword(model.Id, model.NewPassword)
                    'log
                    Helpers.Log(Helpers.LogType.EditData, Helpers.GetCurrentUser().id,, "User", "User-ChangePassword")
                    Return RedirectToAction("LogOff")
                End If
                ModelState.AddModelError("", "รหัสผ่านเก่าไม่ถูกต้อง")
            End If
            Return View(model)
        End Function


    End Class
End Namespace