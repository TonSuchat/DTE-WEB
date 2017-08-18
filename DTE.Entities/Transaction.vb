Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_Transaction")>
Public Class Transaction
    <Key()>
    Public Property id As Integer
    <Required()>
    <MaxLength(13)>
    Public Property WONumber As String
    <MaxLength(13)>
    Public Property Station As String
    <MaxLength(10)>
    Public Property GateNo As String
    Public Property PCA1 As Boolean
    Public Property PCA2 As Boolean
    Public Property GPU1 As Boolean
    Public Property GPU2 As Boolean
    <Required()>
    <MaxLength(10)>
    Public Property FlightNo As String
    <MaxLength(10)>
    Public Property AircraftType As String
    <MaxLength(10)>
    Public Property AircraftReg As String
    <MaxLength(10)>
    Public Property AircraftCarrier As String
    <MaxLength(14)>
    Public Property ETA As String
    <MaxLength(14)>
    Public Property ETD As String
    <MaxLength(14)>
    Public Property PCAStart As String
    <MaxLength(14)>
    Public Property PCAEnd As String
    <MaxLength(14)>
    Public Property GPUStart As String
    <MaxLength(14)>
    Public Property GPUEnd As String
    Public Property PCATotalMin As Integer?
    Public Property GPUTotalMin As Integer?
    <Required()>
    Public Property ServiceRate As Integer
    <Required()>
    Public Property Valid As Boolean
    <Required()>
    Public Property Printed As Boolean
    Public Property CreateBy As Integer?
    Public Property CustIDStart As String
    Public Property CustSignStart As String
    Public Property CustIDStop As String
    Public Property CustSignStop As String
    Public Property CondOfCharge As String
    Public Property Remark As String
    Public Property UpdateBy As Integer?
    <Required()>
    Public Property UpdateDate As DateTime
    <Required()>
    Public Property IsActive As Boolean
    <Required()>
    Public Property CreateDate As DateTime
End Class

Partial Public Class Transaction
    Public ReadOnly Property CreatedDateTxt As String
        Get
            Return Me.CreateDate.ToString("dd/MM/yyyy HH:mm")
        End Get
    End Property
End Class
