Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_Log")>
Public Class Log
    <Key()>
    Public Property Id As Integer
    <Required()>
    Public Property LogType As Integer
    Public Property ReferenceId As Integer?
    <MaxLength(500)>
    Public Property Model As String
    <Required()>
    Public Property UserId As Integer
    Public Property Remark As String
    <Required()>
    Public Property CreateDate As DateTime
End Class
