Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_User")>
Public Class User
    <Key()>
    Public Property id As Integer
    <Required()>
    <MaxLength(10)>
    <Display(Name:="ชื่อผู้ใช้")>
    Public Property UserName As String
    <Required()>
    <MaxLength(50)>
    <Display(Name:="รหัสผ่าน")>
    Public Property PWD As String
    <MaxLength(50)>
    <Display(Name:="หมายเหตุ")>
    Public Property UserDesc As String
    <Required()>
    <Display(Name:="ประเภท")>
    Public Property Type As Integer
    <Required()>
    <MaxLength(10)>
    Public Property Station As String
    <Required()>
    Public Property CreateDate As DateTime
End Class
