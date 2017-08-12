Imports System.Configuration
Imports System.Data.Entity
Imports DTE.Entities

Public Class DTEContext
    Inherits DbContext

    Public Sub New()
        MyBase.New(ConfigurationManager.ConnectionStrings("DTEConnection").ToString())
    End Sub

    Public Property Transactions As DbSet(Of Transaction)
    Public Property Users As DbSet(Of User)

End Class
