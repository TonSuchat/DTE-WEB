Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("vw_Log")>
Public Class VW_Log
    <Key()>
    Public Property Id As Integer
    Public Property logdescription As String
    Public Property ReferenceId As Integer?
    Public Property Model As String
    Public Property UserName As String
    Public Property Remark As String
    Public Property CreateDate As DateTime
End Class
