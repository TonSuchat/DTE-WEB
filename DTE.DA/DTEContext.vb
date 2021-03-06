﻿Imports System.Configuration
Imports System.Data.Entity
Imports DTE.Entities

Public Class DTEContext
    Inherits DbContext

    Public Sub New()
        MyBase.New(ConfigurationManager.ConnectionStrings("DTEConnection").ToString())
    End Sub

    Public Property AirlineMasterDatas As DbSet(Of AirlineMasterData)
    Public Property CodeErrorLogs As DbSet(Of CodeErrorLog)
    Public Property FlightDatas As DbSet(Of FlightData)
    Public Property Transactions As DbSet(Of Transaction)
    Public Property TempTransactions As DbSet(Of TempTransaction)
    Public Property Users As DbSet(Of User)
    Public Property UploadImages As DbSet(Of UploadImage)
    Public Property Logs As DbSet(Of Log)
    Public Property Sequences As DbSet(Of Sequence)
    Public Property ViewLogs As DbSet(Of VW_Log)
End Class
