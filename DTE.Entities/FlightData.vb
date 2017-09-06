Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_FlightData")>
Public Class FlightData
    <Key()>
    Public Property id As Integer
    <Required()>
    <MaxLength(50)>
    Public Property FlightNo As String
    <Required()>
    <MaxLength(50)>
    Public Property ACType As String
    <Display(Name:="Airline")>
    <Required()>
    <MaxLength(50)>
    Public Property ACCarrier As String
    <Required()>
    <MaxLength(50)>
    Public Property ACReg As String
    <Required()>
    <DataType(DataType.DateTime)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property STA As DateTime
    <Required()>
    <DataType(DataType.DateTime)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property STD As DateTime
    <Required()>
    <MaxLength(10)>
    Public Property GateNo As String
    <Required()>
    Public Property CreateDate As DateTime
End Class

Partial Public Class FlightData
    Public ReadOnly Property STAValueTxt As String
        Get
            Return STA.ToString("yyyyMMddHHmmss")
        End Get
    End Property
    Public ReadOnly Property STDValueTxt As String
        Get
            Return STD.ToString("yyyyMMddHHmmss")
        End Get
    End Property
End Class
