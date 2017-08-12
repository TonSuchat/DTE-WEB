Imports System.ComponentModel.DataAnnotations.Schema
Imports DTE.Entities

Public Class ReportViewModels

    <NotMapped()>
    Public Class ServiceOrder
        Inherits Transaction

        Public ReadOnly Property ETADate As DateTime
            Get
                If IsNothing(Me.ETA) Then Return Nothing Else Return DateTime.ParseExact(Me.ETA, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            End Get
        End Property
        Public ReadOnly Property ETDDate As DateTime
            Get
                If IsNothing(Me.ETD) Then Return Nothing Else Return DateTime.ParseExact(Me.ETD, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            End Get
        End Property
        Public ReadOnly Property PCAStartDate As DateTime
            Get
                If IsNothing(Me.PCAStart) Then Return Nothing Else Return DateTime.ParseExact(Me.PCAStart, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            End Get
        End Property
        Public ReadOnly Property PCAEndDate As DateTime
            Get
                If IsNothing(Me.PCAEnd) Then Return Nothing Else Return DateTime.ParseExact(Me.PCAEnd, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            End Get
        End Property
        Public ReadOnly Property GPUStartDate As DateTime
            Get
                If IsNothing(Me.GPUStart) Then Return Nothing Else Return DateTime.ParseExact(Me.GPUStart, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            End Get
        End Property
        Public ReadOnly Property GPUEndDate As DateTime
            Get
                If IsNothing(Me.GPUEnd) Then Return Nothing Else Return DateTime.ParseExact(Me.GPUEnd, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            End Get
        End Property

        Public Sub New(model As Transaction)
            Me.WONumber = model.WONumber
            Me.Station = model.Station
            Me.GateNo = model.GateNo
            Me.PCA1 = model.PCA1
            Me.PCA2 = model.PCA2
            Me.GPU1 = model.GPU1
            Me.GPU2 = model.GPU2
            Me.FlightNo = model.FlightNo
            Me.AircraftType = model.AircraftType
            Me.AircraftReg = model.AircraftReg
            Me.AircraftCarrier = model.AircraftCarrier
            Me.ETA = model.ETA
            Me.ETD = model.ETD
            Me.PCAStart = model.PCAStart
            Me.PCAEnd = model.PCAEnd
            Me.PCATotalMin = model.PCATotalMin
            Me.GPUStart = model.GPUStart
            Me.GPUEnd = model.GPUEnd
            Me.GPUTotalMin = model.GPUTotalMin
        End Sub

    End Class

End Class
