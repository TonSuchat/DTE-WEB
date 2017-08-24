Imports System.ComponentModel.DataAnnotations

Public Class ExportExcelViewModel
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property SelectedDate As Date
End Class
