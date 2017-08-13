Public Class SORequestModels

    Public Class Login
        Public Property UserID As String
        Public Property Password As String
    End Class

    Public Class SaveSO
        Public Property Station As String
        Public Property FlightNo As String
        Public Property ACType As String
        Public Property ACCarrier As String
        Public Property ACReg As String
        Public Property STA As String
        Public Property STD As String
        Public Property GateNo As String
        Public Property PCA1 As Boolean
        Public Property PCA2 As Boolean
        Public Property PCAStart As String
        Public Property PCAStop As String
        Public Property PCATotalTime As String
        Public Property GPU1 As Boolean
        Public Property GPU2 As Boolean
        Public Property GPUStart As String
        Public Property GPUStop As String
        Public Property GPUTotalTime As String
        Public Property UserID As String
        Public Property CustIDStart As String
        Public Property CustSignStart As String
        Public Property CustIDStop As String
        Public Property CustSignStop As String
        Public Property CondOfCharge As String
        Public Property Remark As String
    End Class

End Class
