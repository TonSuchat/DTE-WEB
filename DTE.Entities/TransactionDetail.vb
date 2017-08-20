Imports System.ComponentModel.DataAnnotations.Schema

<NotMapped()>
Public Class TransactionDetail
    Inherits Entities.Transaction
    Public Property UploadImages As List(Of String)
    Public Property CreatedByName As String
    Public Property UpdatedByName As String

    Public Sub New()

    End Sub

    Public Sub New(model As Entities.Transaction)
        Me.AircraftCarrier = model.AircraftCarrier
        Me.AircraftReg = model.AircraftReg
        Me.AircraftType = model.AircraftType
        Me.CondOfCharge = model.CondOfCharge
        Me.CreateBy = model.CreateBy
        Me.CreateDate = model.CreateDate
        Me.CustIDStart = model.CustIDStart
        Me.CustIDStop = model.CustIDStop
        Me.CustSignStart = model.CustSignStart
        Me.CustSignStop = model.CustSignStop
        Me.ETA = model.ETA
        Me.ETD = model.ETD
        Me.FlightNo = model.FlightNo
        Me.GateNo = model.GateNo
        Me.GPU1 = model.GPU1
        Me.GPU2 = model.GPU2
        Me.GPUEnd = model.GPUEnd
        Me.GPUStart = model.GPUStart
        Me.GPUTotalMin = model.GPUTotalMin
        Me.id = model.id
        Me.PCA1 = model.PCA1
        Me.PCA2 = model.PCA2
        Me.PCAEnd = model.PCAEnd
        Me.PCAStart = model.PCAStart
        Me.PCATotalMin = model.PCATotalMin
        Me.Printed = model.Printed
        Me.ServiceRate = model.ServiceRate
        Me.Station = model.Station
        Me.UpdateBy = model.UpdateBy
        Me.UpdateDate = model.UpdateDate
        Me.Valid = model.Valid
        Me.WONumber = model.WONumber
        Me.UploadImages = New List(Of String)
    End Sub

End Class
