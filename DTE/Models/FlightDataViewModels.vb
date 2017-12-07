
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<NotMapped()>
Public Class FlightDataViewModel
    Inherits Entities.FlightData

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property SelectedDate As Date
    <DataType(DataType.DateTime)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property STATime As DateTime
    <DataType(DataType.DateTime)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property STDTime As DateTime?

    Public Sub New()
        STDTime = STATime
    End Sub

    Public Sub New(model As Entities.FlightData)
        If IsNothing(model) Then Exit Sub
        Me.id = model.id
        Me.ACCarrier = model.ACCarrier
        Me.ACReg = model.ACReg
        Me.ACType = model.ACType
        Me.CreateDate = model.CreateDate
        Me.FlightNo = model.FlightNo
        Me.GateNo = model.GateNo
        Me.STA = model.STA
        Me.STD = model.STD
    End Sub

End Class
