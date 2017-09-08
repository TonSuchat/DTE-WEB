Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_Sequence")>
Public Class Sequence
    <Key()>
    Public Property Id As Integer
    <Required()>
    <MaxLength(5)>
    Public Property SequenceNo As String
    <Required()>
    Public Property UpdateDate As DateTime
End Class
