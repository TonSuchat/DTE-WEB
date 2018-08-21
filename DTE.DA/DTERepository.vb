Imports System.Configuration
Imports System.IO
Imports DTE.Entities

Public Class DTERepository
    Inherits BaseRepository

    Private _DTEDBContext As DTEContext
    Public Property DTEDBContext As DTEContext
        Get
            If IsNothing(_DTEDBContext) Then _DTEDBContext = New DTEContext()
            Return _DTEDBContext
        End Get
        Set(value As DTEContext)
            _DTEDBContext = value
        End Set
    End Property

    Private _dispose As Boolean

    Public Sub New()
        _dispose = False
    End Sub

    Public Overloads Sub Dispose()
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overrides Sub Dispose(disposing As Boolean)
        If (Not (_dispose) And disposing) And Not (IsNothing(DTEDBContext)) Then
            DTEDBContext.Dispose()
        End If
        _dispose = True
    End Sub

#Region "AirlineMasterData"
    Public Class AirlineMasterDataRepository
        Inherits DTERepository

        Public Function AddAirlineMasterData(model As AirlineMasterData) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.CreateDate = DateTime.Now()
                model.UpdateDate = DateTime.Now()
                DTEDBContext.AirlineMasterDatas.Add(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "AirlineMasterData", .MethodName = "AddAirlineMasterData", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetAirlineMasterData(id As Integer) As AirlineMasterData
            Try
                If id = 0 Then Return Nothing
                Return DTEDBContext.AirlineMasterDatas.FirstOrDefault(Function(a) a.Id = id)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "AirlineMasterData", .MethodName = "GetAirlineMasterData", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetAirlineMasterDatas() As List(Of AirlineMasterData)
            Try
                Return DTEDBContext.AirlineMasterDatas().OrderByDescending(Function(a) a.UpdateDate).ThenByDescending(Function(a) a.CreateDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "AirlineMasterData", .MethodName = "GetAirlineMasterDatas", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function EditAirlineMasterData(model As AirlineMasterData) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.UpdateDate = DateTime.Now()
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "AirlineMasterData", .MethodName = "EditAirlineMasterData", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function RemoveAirlineMasterDatas(id As Integer) As Boolean
            Try
                Dim model As AirlineMasterData = GetAirlineMasterData(id)
                If IsNothing(model) Then Return False
                DTEDBContext.AirlineMasterDatas.Remove(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "AirlineMasterData", .MethodName = "RemoveAirlineMasterDatas", .Message = ex.ToString()})
                Return False
            End Try
        End Function

    End Class
#End Region

#Region "Service Order"

    Public Class ServiceOrderRepository
        Inherits DTERepository



    End Class
    Public Function SOGetList() As DTE.Entities.ServiceOrder.InputSPInsertSO
        'Using repository As New DA.DTERepository()
        '    'Dim strSql As String = "select * from vw_get_Transaction"
        '    'Dim dtb As New DataTable
        '    'Using cnn As New SqlConnection(repository.DTEDBContext.Database.Connection.ConnectionString)
        '    '    cnn.Open()
        '    '    Using dad As New SqlDataAdapter(strSql, cnn)
        '    '        dad.Fill(dtb)
        '    '    End Using
        '    '    cnn.Close()
        '    'End Using
        '    'Return dtb.tol
        'End Using
        Using repository As New DTE.DA.DTERepository

            'Return repository.GetDeptConfigs().OrderBy(Function(d) d.EmplCode).ToList()
        End Using
    End Function

#End Region

#Region "FlightData"

    Public Class FlightDataRepository
        Inherits DTERepository

        Public Function AddFlightData(model As FlightData) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.CreateDate = DateTime.Now()
                DTEDBContext.FlightDatas.Add(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "FlightData", .MethodName = "AddFlightData", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function GetFlightDatas() As List(Of FlightData)
            Try
                Return DTEDBContext.FlightDatas.OrderByDescending(Function(f) f.CreateDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "FlightData", .MethodName = "GetFlightDatas", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetFlightDatas(selectedDate As Date) As List(Of FlightData)
            Try
                Return DTEDBContext.FlightDatas.Where(Function(f) Entity.DbFunctions.TruncateTime(f.STD) = selectedDate OrElse Entity.DbFunctions.TruncateTime(f.STA) = selectedDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "FlightData", .MethodName = "GetFlightDatas", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetFlightData(id As Integer) As FlightData
            Try
                Return DTEDBContext.FlightDatas.FirstOrDefault(Function(f) f.id = id)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "FlightData", .MethodName = "GetFlightData", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function EditFlightData(model As FlightData) As Boolean
            Try
                If IsNothing(model) Then Return False
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "FlightData", .MethodName = "EditFlightData", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function RemoveFlightData(id As Integer) As Boolean
            Try
                If id = 0 Then Return False
                Dim model = GetFlightData(id)
                If IsNothing(model) Then Return False
                DTEDBContext.FlightDatas.Remove(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "FlightData", .MethodName = "RemoveFlightData", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function RemoveFlightDatas(models As List(Of FlightData)) As Boolean
            Try
                If IsNothing(models) Then Return False
                DTEDBContext.FlightDatas.RemoveRange(models)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "FlightData", .MethodName = "RemoveFlightDatas", .Message = ex.ToString()})
                Return False
            End Try
        End Function

    End Class

#End Region

#Region "Transaction"

    Public Class TransactionRepository
        Inherits DTERepository

        Public Function GetTransaction(id As Integer) As Transaction
            Try
                If id = 0 Then Return Nothing
                Return DTEDBContext.Transactions.FirstOrDefault(Function(t) t.id = id AndAlso t.IsActive = True)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Transaction", .MethodName = "GetTransaction", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetTransactions() As List(Of Transaction)
            Try
                Return DTEDBContext.Transactions.OrderByDescending(Function(t) t.UpdateDate).ThenByDescending(Function(t) t.CreateDate).Where(Function(t) t.IsActive = True).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Transaction", .MethodName = "GetTransactions", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetTransactions(userId As Integer) As List(Of Transaction)
            Try
                If userId = 0 Then Return Nothing
                Return DTEDBContext.Transactions.Where(Function(t) t.CreateBy = userId AndAlso t.IsActive = True).OrderByDescending(Function(t) t.CreateDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Transaction", .MethodName = "GetTransactions", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function RemoveTransaction(id As Integer) As Boolean
            Try
                If id = 0 Then Return False
                Dim model = DTEDBContext.Transactions.FirstOrDefault(Function(t) t.id = id)
                If IsNothing(model) Then Return False
                'flag delete
                model.IsActive = False
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Transaction", .MethodName = "RemoveTransaction", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function EditTransaction(model As Transaction) As Boolean
            Try
                If IsNothing(model) Then Return False
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Transaction", .MethodName = "EditTransaction", .Message = ex.ToString()})
                Return False
            End Try
        End Function

    End Class

#End Region

#Region "TempTransaction"

    Public Class TempTransactionRepository
        Inherits DTERepository

        Public Function AddTempTransaction(model As TempTransaction) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.CreateDate = DateTime.Now()
                DTEDBContext.TempTransactions.Add(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "TempTransaction", .MethodName = "AddTempTransaction", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function RemoveTempTransaction(model As TempTransaction) As Boolean
            Try
                If IsNothing(model) Then Return False
                DTEDBContext.TempTransactions.Remove(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "TempTransaction", .MethodName = "RemoveTempTransaction", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function GetTempTransactions() As List(Of TempTransaction)
            Try
                Return DTEDBContext.TempTransactions.OrderByDescending(Function(t) t.CreateDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "TempTransaction", .MethodName = "GetTempTransactions", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetTempTransaction(id As Integer) As TempTransaction
            Try
                If id = 0 Then Return Nothing
                Return DTEDBContext.TempTransactions.FirstOrDefault(Function(t) t.id = id)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "TempTransaction", .MethodName = "GetTempTransaction", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function UpdateTempTransaction(model As TempTransaction) As Boolean
            Try
                If IsNothing(model) Then Return False
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "TempTransaction", .MethodName = "UpdateTempTransaction", .Message = ex.ToString()})
                Return False
            End Try
        End Function

    End Class

#End Region

#Region "UserRepository"

    Public Class UserRepository
        Inherits DTERepository

        Public Function GetUser(username As String, password As String) As User
            Try
                If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then Return Nothing
                Return DTEDBContext.Users.FirstOrDefault(Function(u) u.UserName.Trim() = username AndAlso u.PWD.Trim() = password)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "User", .MethodName = "GetUser", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetUser(id As Integer) As User
            Try
                If id = 0 Then Return Nothing
                Return DTEDBContext.Users.FirstOrDefault(Function(u) u.id = id)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "User", .MethodName = "GetUser", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetUsers() As List(Of User)
            Try
                Return DTEDBContext.Users.OrderByDescending(Function(u) u.CreateDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "User", .MethodName = "GetUsers", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function AddUser(model As User) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.CreateDate = DateTime.Now()
                DTEDBContext.Users.Add(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "User", .MethodName = "AddUser", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function EditUser(model As User) As Boolean
            Try
                If IsNothing(model) Then Return False
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "User", .MethodName = "EditUser", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function RemoveUser(id As Integer) As Boolean
            Try
                Dim model = GetUser(id)
                If IsNothing(model) Then Return False
                DTEDBContext.Users.Remove(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "User", .MethodName = "RemoveUser", .Message = ex.ToString()})
                Return False
            End Try
        End Function

    End Class

#End Region

#Region "UploadImageRepository"

    Public Class UploadImageRepository
        Inherits DTERepository

        Public Function AddUploadImage(model As UploadImage) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.createDate = DateTime.Now()
                DTEDBContext.UploadImages.Add(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "UploadImage", .MethodName = "AddUploadImage", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function AddUploadImages(models As List(Of UploadImage)) As Boolean
            Try
                For Each model In models
                    AddUploadImage(model)
                Next
                Return True
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "UploadImage", .MethodName = "AddUploadImages", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function GetUploadImages(woNumber As String) As List(Of UploadImage)
            Try
                Return DTEDBContext.UploadImages.Where(Function(u) u.WONumber = woNumber).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "UploadImage", .MethodName = "GetUploadImages", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function GetUploadImages(refId As Integer) As List(Of UploadImage)
            Try
                Return DTEDBContext.UploadImages.Where(Function(u) u.refId = refId).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "UploadImage", .MethodName = "GetUploadImages", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function RemoveUploadImages(models As List(Of UploadImage)) As Boolean
            Try
                If IsNothing(models) Then Return False
                DTEDBContext.UploadImages.RemoveRange(models)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "UploadImage", .MethodName = "RemoveUploadImages", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function EditUploadImages(model As UploadImage) As Boolean
            Try
                If IsNothing(model) Then Return False
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "UploadImage", .MethodName = "EditUploadImages", .Message = ex.ToString()})
                Return False
            End Try
        End Function

    End Class

#End Region

#Region "Log"

    Public Class LogRepository
        Inherits DTERepository

        Public Function AddLog(model As Log) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.CreateDate = DateTime.Now()
                DTEDBContext.Logs.Add(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Log", .MethodName = "AddLog", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function GetLogs() As List(Of Log)
            Try
                Return DTEDBContext.Logs.OrderByDescending(Function(l) l.CreateDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Log", .MethodName = "GetLogs", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

    End Class

#End Region

#Region "Sequence"

    Public Class SequenceRepository
        Inherits DTERepository

        Public Function GetSequence() As Sequence
            Try
                Return DTEDBContext.Sequences.FirstOrDefault()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Sequence", .MethodName = "GetSequence", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

        Public Function EditSequence(model As Sequence) As Boolean
            Try
                If IsNothing(model) Then Return False
                model.UpdateDate = DateTime.Now()
                DTEDBContext.Entry(model).State = Entity.EntityState.Modified
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Sequence", .MethodName = "EditSequence", .Message = ex.ToString()})
                Return False
            End Try
        End Function

        Public Function AddSequence(model As Sequence) As Boolean
            Try
                If IsNothing(model) Then Return False
                DTEDBContext.Sequences.Add(model)
                Return If(DTEDBContext.SaveChanges > 0, True, False)
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "Sequence", .MethodName = "AddSequence", .Message = ex.ToString()})
                Return False
            End Try
        End Function

    End Class

#End Region

#Region "ViewLog"
    Public Class ViewLogRepository
        Inherits DTERepository

        Public Function GetViewLogs() As List(Of VW_Log)
            Try
                Return DTEDBContext.ViewLogs.OrderByDescending(Function(l) l.CreateDate).ToList()
            Catch ex As Exception
                Log(New CodeErrorLog() With {.ModelType = "VW_Log", .MethodName = "GetViewLogs", .Message = ex.ToString()})
                Return Nothing
            End Try
        End Function

    End Class
#End Region

#Region "CodeErrorLog"
    Public Class CodeErrorLogRepository
        Inherits DTERepository

        Public Sub AddCodeErrorLog(model As CodeErrorLog)
            Try
                If IsNothing(model) Then Exit Sub
                model.CreateDate = DateTime.Now()
                DTEDBContext.CodeErrorLogs.Add(model)
                DTEDBContext.SaveChanges()
            Catch ex As Exception

            End Try
        End Sub

    End Class
#End Region

    Public Sub Log(model As CodeErrorLog)
        Using repository As New CodeErrorLogRepository()
            repository.AddCodeErrorLog(model)
        End Using
    End Sub


    Public Shared Sub Log(message As String)
        Dim path As String = "E:\temp\log.txt"
        Using sw As StreamWriter = File.AppendText(path)
            sw.WriteLine(message)
        End Using
    End Sub

End Class
