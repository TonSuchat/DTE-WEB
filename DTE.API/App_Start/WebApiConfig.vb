Imports System.Web.Http
Imports System.Web.Http.Cors
Imports Microsoft.Owin.Security.OAuth

Public Module WebApiConfig
    Public Sub Register(config As HttpConfiguration)
        'Dim cors As New EnableCorsAttribute("*", "*", "*")
        'config.EnableCors(cors)
        ' Web API configuration and services
        ' Configure Web API to use only bearer token authentication.
        config.SuppressDefaultHostAuthentication()
        config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{action}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
