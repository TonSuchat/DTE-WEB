Imports System.ComponentModel.DataAnnotations

Public Class ExportExcelViewModel
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property ExcelSelectedDate As Date
End Class

Public Class ManageServiceOrderViewModel
    Public Property TransactionsDetail As List(Of Entities.TransactionDetail)
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property SelectedDate As Date

    Public Sub New()
        SelectedDate = Date.Now()
    End Sub

End Class

Public Class RemoveServiceOrderViewModel
    Public Property id As Integer
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property removeSelectedDate As Date
End Class