Public NotInheritable Class Helpers

    Public Shared Function CheckIsAuthen() As Boolean
        If Not IsNothing(HttpContext.Current.Session("CurrentUser")) Then Return True Else Return False
    End Function

    Public Shared Function GetCurrentUser() As Entities.User
        If IsNothing(HttpContext.Current.Session("CurrentUser")) Then Return Nothing Else Return HttpContext.Current.Session("CurrentUser")
    End Function

    Public Shared Sub SetCurrentUser(user As Entities.User)
        HttpContext.Current.Session("CurrentUser") = user
    End Sub

End Class
