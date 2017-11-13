Imports System.ComponentModel.DataAnnotations

Public Class ExportExcelViewModel
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property ExcelSelectedStartDate As Date
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property ExcelSelectedEndDate As Date
End Class

Public Class ManageServiceOrderViewModel

    Public Property TransactionsDetail As List(Of Entities.TransactionDetail)

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property SelectedStartDate As Date

    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property SelectedEndDate As Date

    Public Sub New()
        SelectedStartDate = Date.Now()
        SelectedEndDate = Date.Now()
    End Sub

End Class

Public Class RemoveServiceOrderViewModel
    Public Property id As Integer
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property removeSelectedStartDate As Date
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property removeSelectedEndDate As Date
End Class