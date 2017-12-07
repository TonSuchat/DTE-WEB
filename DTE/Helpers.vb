Imports System.Data.OleDb
Imports System.Globalization

Public NotInheritable Class Helpers

    Public Enum LogType
        LogIn = 1
        LogOut = 2
        OpenPage = 3
        AddData = 4
        EditData = 5
        DeleteData = 6
    End Enum

    Public Const Version As String = "1.0"

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

    Public Shared Function GetExcelData(connectionString As String) As DataTable
        Try
            Using conn As New OleDbConnection(connectionString)
                conn.Open()
                Using cmd As New OleDbCommand("select * from [Sheet1$]", conn)
                    Dim ds As New DataSet()
                    Using adapter As New OleDbDataAdapter(cmd)
                        adapter.Fill(ds)
                        Return ds.Tables(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LogTxt(ex.ToString())
            Return Nothing
        End Try
    End Function

    Public Shared Function GetExcelDataCSV(filePath As String) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("")
        dt.Columns.Add("")
        dt.Columns.Add("")
        dt.Columns.Add("")
        dt.Columns.Add("")
        dt.Columns.Add("")
        dt.Columns.Add("")
        Using sr As New IO.StreamReader(filePath)
            Do While Not sr.EndOfStream()
                Dim row = sr.ReadLine().Split(",")
                If row.Length > 1 Then
                    Dim dr = dt.NewRow()
                    For index = 0 To row.Length - 1
                        If String.IsNullOrEmpty(row(index).Trim()) Then Continue For
                        dr(index) = row(index).Trim()
                    Next
                    dt.Rows.Add(dr)
                End If
            Loop
        End Using
        Return dt
    End Function

    Public Shared Sub LogTxt(message As String)
        Dim filename As String = DateTime.Now().ToString("ddMMyyyy") & ".txt"
        Dim path As String = HttpContext.Current.Server.MapPath("~/Logs")
        Dim filepath As String = path & "\" & filename
        If Not IO.Directory.Exists(path) Then IO.Directory.CreateDirectory(path)
        Dim y As System.IO.StreamWriter = IO.File.AppendText(filepath)
        y.WriteLine("[" & Format(DateTime.Now().Hour, "00") & ":" & Format(DateTime.Now().Minute, "00") & ":" & Format(DateTime.Now().Second, "00") & "] " & "Message: " & message)
        y.Close()
        y.Dispose()
    End Sub

    Public Shared Function ConvertDateTimeDTEFormat(input As String) As DateTime
        Try
            Return DateTime.ParseExact(input, "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function ConvertUserTypeToText(type As Integer) As String
        Select Case type
            Case 1 : Return "Admin"
            Case 2 : Return "SuperUser"
            Case 3 : Return "User"
            Case 4 : Return "Operator"
            Case Else : Return ""
        End Select
    End Function

    Public Shared Function GetSelectListItemUserTypes(role As Integer) As List(Of SelectListItem)
        Dim userTypes = New List(Of SelectListItem)() From {
                                                        New SelectListItem() With {.Text = "Admin", .Value = 1, .Selected = True},
                                                        New SelectListItem() With {.Text = "Super User", .Value = 2},
                                                        New SelectListItem() With {.Text = "User", .Value = 3},
                                                        New SelectListItem() With {.Text = "Operator", .Value = 4}}
        userTypes = userTypes.Where(Function(u) u.Value >= role).ToList()
        Return userTypes
    End Function

End Class
