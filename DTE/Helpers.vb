Public NotInheritable Class Helpers

    Public Enum LogType
        LogIn = 1
        LogOut = 2
        OpenPage = 3
        AddData = 4
        EditData = 5
        DeleteData = 6
    End Enum

    Private Shared services As New Services.ServiceOrderServices()

    Public Shared Function CheckIsAuthen() As Boolean
        If Not IsNothing(HttpContext.Current.Session("CurrentUser")) Then Return True Else Return False
    End Function

    Public Shared Function GetCurrentUser() As Entities.User
        If IsNothing(HttpContext.Current.Session("CurrentUser")) Then Return Nothing Else Return HttpContext.Current.Session("CurrentUser")
    End Function

    Public Shared Sub SetCurrentUser(user As Entities.User)
        HttpContext.Current.Session("CurrentUser") = user
    End Sub

    Public Shared Sub ClearCurrentUser()
        HttpContext.Current.Session("CurrentUser") = Nothing
    End Sub

    Public Shared Sub Log(type As LogType, userId As Integer, Optional referenceId As Integer? = Nothing, Optional model As String = Nothing, Optional remark As String = Nothing)
        Dim log As New Entities.Log() With {.LogType = type, .Model = model, .ReferenceId = referenceId, .Remark = remark, .UserId = userId}
        services.AddLog(log)
    End Sub

End Class
