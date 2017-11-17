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
        Public Property PCATotalMin As String
        Public Property GPU1 As Boolean
        Public Property GPU2 As Boolean
        Public Property GPUStart As String
        Public Property GPUStop As String
        Public Property GPUTotalMin As String
        Public Property UserID As String
        Public Property CustIDStart As String
        Public Property CustSignStart As String
        Public Property CustIDStop As String
        Public Property CustSignStop As String
        Public Property CondOfCharge As String
        Public Property Remark As String
        Public Property UploadImages As List(Of String)
        Public Property RefId As Integer
    End Class

    Public Class GetSO
        Public Property Station As String
    End Class

    Public Class GetSOByWONumber
        Public Property WONumber As String
    End Class

    Public Class GetSOById
        Public Property Id As Integer
    End Class

    Public Class GetListRecall
        Public Property Station As String
    End Class

    Public Class GetRecallById
        Public Property Id As Integer
    End Class

    Public Class EditSO
        Inherits SaveSO

        Public Property Id As Integer
    End Class

    Public Class DeleteSO
        Public Property Id As Integer
    End Class

    Public Class DeleteTempSO
        Public Property Id As Integer
    End Class

    Public Class GetFlightData
        Public Property FlightDate As String
    End Class

    Public Class GetAirlineLogo
        Public Property ACCarrier As String
    End Class

    Public Class ChangePassword
        Public Property UserId As Integer
        Public Property OldPassword As String
        Public Property NewPassword As String
    End Class

End Class
