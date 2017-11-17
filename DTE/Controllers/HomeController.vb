Imports System.IO

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

    Function DownloadAPK() As ActionResult
        Using fs As FileStream = IO.File.OpenRead(Server.MapPath("~/Files/app.apk"))
            Dim length As Integer = fs.Length
            Dim buffer As Byte()

            Using br As New BinaryReader(fs)
                buffer = br.ReadBytes(length)
            End Using

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", Path.GetFileName(Server.MapPath("~/Files/app.apk"))))
            Response.ContentType = "application/vnd.android.package-archive"
            Response.BinaryWrite(buffer)
            Response.End()
        End Using
        Return View()
    End Function

End Class
