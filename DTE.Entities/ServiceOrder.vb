Imports System.ComponentModel.DataAnnotations

Public Class ServiceOrder

    Public Class InputSPInsertSO
        Public SONumber As String
        Public Property DateNow As String
        <Required()>
        Public Property Station As String
        <Required()>
        Public Property GateNo As String
        <Display(Name:="1 House")>
        Public Property PCA1 As Boolean
        <Display(Name:="2 House")>
        Public Property PCA2 As Boolean
        <Display(Name:="1 Plug")>
        Public Property GPU1 As Boolean
        <Display(Name:="2 Plug")>
        Public Property GPU2 As Boolean
        <Required()>
        <MaxLength(10)>
        Public Property FlightNo As String
        <Required()>
        <MaxLength(10)>
        Public Property AircraftType As String
        <Required()>
        <MaxLength(10)>
        Public Property AircraftReg As String
        <Required()>
        <MaxLength(10)>
        Public Property AircraftCarrier As String
        <Required()>
        Public Property ETA As String
        <Required()>
        Public Property ETD As String
        Public Property PCAStart As String
        Public Property PCAEnd As String
        Public Property GPUStart As String
        Public Property GPUEnd As String
        Public Property CreateBy As Integer
        Public Property CustIDStart As String
        Public Property CustSignStart As String
        Public Property CustIDStop As String
        Public Property CustSignStop As String
        Public Property CondOfCharge As String
        Public Property Remark As String


        Public Sub New()
            Me.DateNow = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            CreateBy = 1
        End Sub
    End Class

    Public Class OutputSPInsertSO
        Public Property Success As Integer
        Public Property RetMsg As String
    End Class
    Public Class InputServiceRate
        Public Property ACType As String
        Public Property ServiceID As Integer
        Public Property UsageMin As Integer
    End Class
    Public Class OutputServiceRate
        Public Property Rate As Integer
        Public Property success As String
        Public Property retMessage As String
    End Class
End Class


