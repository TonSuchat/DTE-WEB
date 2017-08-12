Imports DTE.Entities
Imports DTE.Services
Imports System.Web.Mvc

Namespace Controllers
    Public Class ReportController
        Inherits Controller

        Private services As New ReportServices()

        Function ServiceOrder() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function ServiceOrder(startDate As String, endDate As String) As ActionResult
            'where ETD
            Dim transactions = services.GetTransactions(startDate, endDate)
            If Not IsNothing(transactions) Then
                Dim viewModels As New List(Of ReportViewModels.ServiceOrder)
                For Each item In transactions
                    viewModels.Add(New ReportViewModels.ServiceOrder(item))
                Next
                Return View(viewModels)
            Else
                Return View()
            End If
        End Function

    End Class
End Namespace