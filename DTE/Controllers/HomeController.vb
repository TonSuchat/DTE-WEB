Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
    Function Report() As ActionResult
        ViewData("Message") = "Your Report page."

        Return View()
    End Function
    Function Admin() As ActionResult
        ViewData("Message") = "Your Admin page."

        Return View()
    End Function

    Function Denied() As ActionResult
        Return View()
    End Function

End Class
