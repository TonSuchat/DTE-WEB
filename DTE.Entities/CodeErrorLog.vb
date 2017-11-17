Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_CodeErrorLog")>
Public Class CodeErrorLog
    <Key()>
    Public Property Id As Integer
    <Required()>
    <MaxLength(250)>
    Public Property ModelType As String
    <Required()>
    <MaxLength(500)>
    Public Property MethodName As String
    Public Property Message As String
    <Required()>
    Public Property CreateDate As DateTime
End Class
