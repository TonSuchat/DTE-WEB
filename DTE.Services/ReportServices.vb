Imports DTE.DA.DTERepository
Imports DTE.Entities

Public Class ReportServices

    Public Function GetTransactions(startDate As String, endDate As String) As List(Of Transaction)
        Using repository As New TransactionRepository()
            Dim transactions = repository.GetTransactions()
            If IsNothing(transactions) Then Return Nothing
            'find only transactions that in between startdate and enddate
            Dim dStartDate As DateTime = DateTime.ParseExact(startDate, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            Dim dEndDate As DateTime = DateTime.ParseExact(endDate, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture)
            Return transactions.Where(Function(t) (DateTime.ParseExact(t.ETD, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture) >= dStartDate _
                                                   AndAlso DateTime.ParseExact(t.ETD, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture) <= dEndDate)).OrderBy(Function(t) t.CreateDate).ToList()
        End Using
    End Function

End Class
