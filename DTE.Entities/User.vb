Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_User")>
Public Class User

    <Key()>
    Public Property id As Integer
    <Required()>
    <MaxLength(10)>
    Public Property UserName As String
    <Required()>
    <MaxLength(50)>
    Public Property PWD As String
    <MaxLength(50)>
    Public Property UserDesc As String
    <Required()>
    Public Property IsAdmin As Boolean
    <Required()>
    Public Property CreateDate As DateTime
End Class
