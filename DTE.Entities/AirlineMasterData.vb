Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_AirlineMasterData")>
Public Class AirlineMasterData
    <Key()>
    Public Property Id As Integer
    <MaxLength(2)>
    Public Property ALC2 As String
    <MaxLength(3)>
    Public Property ALC3 As String
    <MaxLength(60)>
    Public Property ALFN As String
    <MaxLength(60)>
    Public Property ADD1 As String
    <MaxLength(60)>
    Public Property ADD2 As String
    <MaxLength(60)>
    Public Property ADD3 As String
    <MaxLength(60)>
    Public Property ADD4 As String
    <MaxLength(255)>
    Public Property EmailAddress As String
    <Required()>
    Public Property CreateDate As DateTime
    Public Property UpdateDate As DateTime
End Class
