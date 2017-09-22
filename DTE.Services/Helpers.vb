Imports System.Globalization
Imports System.IO

Public NotInheritable Class Helpers

    Public Shared Sub Log(message As String)
        Dim path As String = "E:\temp\log.txt"
        Using sw As StreamWriter = File.AppendText(path)
            sw.WriteLine(message)
        End Using
    End Sub

    Public Shared Function ConvertDateTimeDTEFormat(input As String) As DateTime
        Try
            Return DateTime.ParseExact(input, "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
