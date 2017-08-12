Imports System.Net
Imports System.Web.Http
Imports DTE.Services

Namespace Controllers
    Public Class SOController
        Inherits ApiController

        Private services As New ServiceOrderServices()

        Public Function Login(model As SORequestModels.Login) As IHttpActionResult
            Return Ok(services.Login(model.UserID, model.Password))
        End Function

    End Class
End Namespace