﻿Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_UploadImage")>
Public Class UploadImage
    <Key()>
    Public Property id As Integer
    <MaxLength(13)>
    Public Property WONumber As String
    Public Property refId As Integer?
    <Required()>
    Public Property objectImage As String
    <Required()>
    Public Property createDate As DateTime
End Class
