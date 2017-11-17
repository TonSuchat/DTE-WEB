Public Class AuthorizationFilter
    Inherits AuthorizeAttribute

    '<AuthorizationFilter(Roles:="Administrator")>
    '<AuthorizationFilter>

    Public Overrides Sub OnAuthorization(filterContext As AuthorizationContext)
        If Not Helpers.CheckIsAuthen() Then
            filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With {.controller = "Account", .action = "LogIn"}))
        Else
            'check roles
            If Not String.IsNullOrEmpty(Roles) AndAlso (Not CheckUserRolePermission(Roles.Split(",").ToList())) Then
                filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With {.controller = "Home", .action = "Denied"}))
            End If
        End If
    End Sub

    Private Function CheckUserRolePermission(roles As List(Of String)) As Boolean
        For Each role In roles
            If role.ToLower = "user" Then Return True
            If role.ToLower = "administrator" Then
                If Helpers.GetCurrentUser().Type = 1 Then Return True
            End If
            If role.ToLower = "superuser" Then
                If Helpers.GetCurrentUser().Type = 2 Then Return True
            End If
        Next
        Return False
    End Function

End Class
