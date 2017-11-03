Imports System.Data.SqlClient
Imports DTE.DA.DTERepository
Imports DTE.Entities

Public Class ServiceOrderServices

    Public Function ExecuteStoredInsertSO(model As ServiceOrder.InputSPInsertSO) As ServiceOrder.OutputSPInsertSO
        Try
            Using repository As New DA.DTERepository()
                'initial parameters
                Dim station As New SqlParameter("Station", model.Station) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim gateNo As New SqlParameter("GateNo", model.GateNo) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim pca1 As New SqlParameter("PCA1", model.PCA1) With {.SqlDbType = SqlDbType.Bit}
                Dim pca2 As New SqlParameter("PCA2", model.PCA2) With {.SqlDbType = SqlDbType.Bit}
                Dim gpu1 As New SqlParameter("GPU1", model.GPU1) With {.SqlDbType = SqlDbType.Bit}
                Dim gpu2 As New SqlParameter("GPU2", model.GPU2) With {.SqlDbType = SqlDbType.Bit}
                Dim flightNo As New SqlParameter("FlightNo", model.FlightNo) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim acType As New SqlParameter("AircraftType", model.AircraftType) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim acReg As New SqlParameter("AircraftReg", model.AircraftReg) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim acCar As New SqlParameter("AircraftCarrier", model.AircraftCarrier) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim eta As New SqlParameter("ETA", model.ETA) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim etd As New SqlParameter("ETD", model.ETD) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim pcaStart As New SqlParameter("PCAStart", model.PCAStart) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim pcaEnd As New SqlParameter("PCAEnd", model.PCAEnd) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim pcaTotalMin As New SqlParameter("PCATotalMin", model.PCATotalMin) With {.SqlDbType = SqlDbType.Int}
                Dim gpuStart As New SqlParameter("GPUStart", model.GPUStart) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim gpuEnd As New SqlParameter("GPUEnd", model.GPUEnd) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim gpuTotalMin As New SqlParameter("GPUTotalMin", model.GPUTotalMin) With {.SqlDbType = SqlDbType.Int}
                Dim createBy As New SqlParameter("CreateBy", model.CreateBy) With {.SqlDbType = SqlDbType.Int}
                Dim custIdStart As New SqlParameter("CustIDStart", model.CustIDStart) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim custSignStart As New SqlParameter("CustSignStart", model.CustSignStart) With {.SqlDbType = SqlDbType.Text}
                Dim custIdStop As New SqlParameter("CustIDStop", model.CustIDStop) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim custSignStop As New SqlParameter("CustSignStop", model.CustSignStop) With {.SqlDbType = SqlDbType.Text}
                Dim condOfCharge As New SqlParameter("CondOfCharge", model.CondOfCharge) With {.SqlDbType = SqlDbType.NVarChar, .Size = 255}
                Dim remark As New SqlParameter("Remark", model.Remark) With {.SqlDbType = SqlDbType.NVarChar, .Size = 255}
                'initial output parameters
                Dim success As New SqlParameter("Success", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                Dim retmessage As New SqlParameter("RetMsg", SqlDbType.NVarChar) With {.Direction = ParameterDirection.Output, .Size = 255}

                repository.DTEDBContext.Database.ExecuteSqlCommand("sp_Insert_SO @Station, @GateNo, @PCA1, @PCA2, @GPU1, @GPU2, @FlightNo, @AircraftType, @AircraftReg, @AircraftCarrier, @ETA, 
                                                                @ETD, @PCAStart, @PCAEnd, @PCATotalMin, @GPUStart, @GPUEnd, @GPUTotalMin, @CreateBy, @CustIDStart, @CustSignStart, @CustIDStop, @CustSignStop,
                                                                @CondOfCharge, @Remark,@Success out, @RetMsg out",
                                                                   station, gateNo, pca1, pca2, gpu1, gpu2, flightNo, acType, acReg, acCar, eta, etd, pcaStart, pcaEnd, pcaTotalMin, gpuStart, gpuEnd, gpuTotalMin, createBy,
                                                                   custIdStart, custSignStart, custIdStop, custSignStop, condOfCharge, remark, success, retmessage)
                Dim result = New ServiceOrder.OutputSPInsertSO()
                result.Success = success.Value
                result.RetMsg = retmessage.Value
                Return result
            End Using
        Catch ex As Exception
            Return New ServiceOrder.OutputSPInsertSO() With {.Success = 0, .RetMsg = ex.ToString()}
        End Try
    End Function

    Public Function ExecuteStoredCalcServiceRate(model As ServiceOrder.InputServiceRate) As ServiceOrder.OutputServiceRate
        Try
            Using repository As New DA.DTERepository()
                'initial parameters
                Dim ACType As New SqlParameter("ACType", model.ACType) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim ServiceID As New SqlParameter("ServiceID", model.ServiceID) With {.SqlDbType = SqlDbType.Int}
                Dim UsageMin As New SqlParameter("UsageMin", model.UsageMin) With {.SqlDbType = SqlDbType.Int}

                'initial output parameters
                Dim Rate As New SqlParameter("Rate", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                Dim success As New SqlParameter("Success", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                Dim retmessage As New SqlParameter("retMessage", SqlDbType.NVarChar) With {.Direction = ParameterDirection.Output, .Size = 255}
                repository.DTEDBContext.Database.ExecuteSqlCommand("sp_get_ServiceRate @ACType, @ServiceID, @UsageMin ,@Rate out, @Success out, @retmessage out",
                                                                   ACType, ServiceID, UsageMin, Rate, success, retmessage)
                Dim result = New ServiceOrder.OutputServiceRate()
                result.Rate = Rate.Value
                result.success = success.Value
                result.retMessage = retmessage.Value
                Return result
            End Using
        Catch ex As Exception
            Return New ServiceOrder.OutputServiceRate() With {.success = 0, .retMessage = ex.ToString()}
        End Try
    End Function

#Region "AirlineMasterData"

    Public Function GetAirlineLogo(ACCarrier As String) As String
        Using repository As New AirlineMasterDataRepository()
            Dim result = repository.GetAirlineMasterDatas().Where(Function(a) a.ALC3 = ACCarrier).FirstOrDefault()
            If IsNothing(result) Then Return "" Else Return result.Logo
        End Using
    End Function

    Public Function GetAirlineMasterData(id As Integer) As AirlineMasterData
        Using repository As New AirlineMasterDataRepository()
            Return repository.GetAirlineMasterData(id)
        End Using
    End Function

    Public Function GetAirlineMasterDatas() As List(Of AirlineMasterData)
        Using repository As New AirlineMasterDataRepository()
            Return repository.GetAirlineMasterDatas()
        End Using
    End Function

    Public Function AddAirlineMasterData(model As AirlineMasterData) As Boolean
        Using repository As New AirlineMasterDataRepository()
            If (Not String.IsNullOrEmpty(model.Logo)) Then model.Logo = model.Logo.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "")
            Return repository.AddAirlineMasterData(model)
        End Using
    End Function

    Public Function EditAirlineMasterData(model As AirlineMasterData) As Boolean
        Using repository As New AirlineMasterDataRepository()
            If (Not String.IsNullOrEmpty(model.Logo)) Then model.Logo = model.Logo.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "")
            Return repository.EditAirlineMasterData(model)
        End Using
    End Function

    Public Function RemoveAirlineMasterData(id As Integer) As Boolean
        Using repository As New AirlineMasterDataRepository()
            Return repository.RemoveAirlineMasterDatas(id)
        End Using
    End Function

#End Region


#Region "User"

    Public Function AddUser(model As User) As Boolean
        Using repository As New UserRepository()
            Return repository.AddUser(model)
        End Using
    End Function

    Public Function Login(username As String, password As String) As Boolean
        Using repository As New UserRepository()
            Return If(Not IsNothing(repository.GetUser(username, password)), True, False)
        End Using
    End Function

    Public Function GetUser(id As Integer) As User
        Using repository As New UserRepository()
            Return repository.GetUser(id)
        End Using
    End Function

    Public Function GetUser(username As String, password As String) As User
        Using repository As New UserRepository()
            Return repository.GetUser(username, password)
        End Using
    End Function

    Public Function GetUserAdmin(username As String, password As String) As User
        Using repository As New UserRepository()
            Dim user = repository.GetUser(username, password)
            If IsNothing(user) Then Return Nothing
            If user.IsAdmin Then Return user Else Return Nothing
        End Using
    End Function

    Public Function GetUsers() As List(Of User)
        Using repository As New UserRepository()
            Return repository.GetUsers()
        End Using
    End Function

    Public Function RemoveUser(id As Integer) As Boolean
        Using repository As New UserRepository()
            Return repository.RemoveUser(id)
        End Using
    End Function

#End Region

#Region "UploadImage"

    Public Function AddUploadImage(model As UploadImage) As Boolean
        Using repository As New UploadImageRepository()
            Return repository.AddUploadImage(model)
        End Using
    End Function

    Public Function AddUploadImages(models As List(Of UploadImage)) As Boolean
        Using repository As New UploadImageRepository()
            Return repository.AddUploadImages(models)
        End Using
    End Function

    Public Function GetUploadImages(woNumber As String) As List(Of UploadImage)
        Using repository As New UploadImageRepository()
            Return repository.GetUploadImages(woNumber)
        End Using
    End Function

    Public Function GetUploadImages(refId As Integer) As List(Of UploadImage)
        Using repository As New UploadImageRepository()
            Return repository.GetUploadImages(refId)
        End Using
    End Function

    Public Function EditUploadImages(models As List(Of UploadImage)) As Boolean
        Using repository As New UploadImageRepository()
            For Each item In models
                repository.EditUploadImages(item)
            Next
        End Using
        Return True
    End Function

    Public Function RemoveUploadImagesByRefId(refId As Integer) As Boolean
        Dim models = GetUploadImages(refId)
        Using repository As New UploadImageRepository()
            Return repository.RemoveUploadImages(models)
        End Using
    End Function

#End Region

#Region "Transactions"

    Public Function GetTransaction(id As Integer) As Transaction
        Using repository As New TransactionRepository()
            Return repository.GetTransaction(id)
        End Using
    End Function

    Public Function GetTransactions() As List(Of Transaction)
        Using repository As New TransactionRepository()
            Return repository.GetTransactions()
        End Using
    End Function

    Public Function GetTransactionsDetail(station As String) As List(Of TransactionDetail)
        Dim models As List(Of Transaction) = Nothing
        Using repository As New TransactionRepository()
            models = repository.GetTransactions().Where(Function(t) t.Station = station).OrderByDescending(Function(t) t.CreateDate).ToList()
        End Using
        If IsNothing(models) OrElse models.Count = 0 Then Return Nothing
        Return (From t In models Select New TransactionDetail(t)).ToList()
        'Dim result As New List(Of TransactionDetail)
        'For Each item In models
        '    Dim currentDetail As New TransactionDetail(item)
        '    currentDetail.Logo = FindLogoForTransaction(item.FlightNo, Helpers.ConvertDateTimeDTEFormat(item.ETA), Helpers.ConvertDateTimeDTEFormat(item.ETD))
        '    result.Add(currentDetail)
        'Next
        'Return result
    End Function

    Public Function GetTransactions(userId As Integer) As List(Of Transaction)
        Using repository As New TransactionRepository()
            Return repository.GetTransactions(userId)
        End Using
    End Function

    Public Function RemoveTransaction(id As Integer) As Boolean
        Using repository As New TransactionRepository()
            Return repository.RemoveTransaction(id)
        End Using
    End Function

    Public Function GetTransactionDetail(id As Integer) As TransactionDetail
        Dim result = New TransactionDetail(GetTransaction(id))
        ProcessFindDetailForTransaction(result)
        Return result
    End Function

    Public Function GetTransactionDetailByTempId(tempId As Integer) As TransactionDetail
        Dim result = New TransactionDetail(GetTempTransaction(tempId))
        ProcessFindDetailForTransaction(result, tempId)
        Return result
    End Function

    Private Sub ProcessFindDetailForTransaction(ByRef transaction As TransactionDetail, Optional tempTransactionId As Integer = 0)
        'find createdbyname and updatedbyname
        transaction.CreatedByName = GetUser(transaction.CreateBy).UserName
        If (Not IsNothing(transaction.UpdateBy)) Then transaction.UpdatedByName = GetUser(transaction.UpdateBy).UserName
        'find upload images
        Dim uploadImages
        If tempTransactionId = 0 Then uploadImages = GetUploadImages(transaction.WONumber) Else uploadImages = GetUploadImages(tempTransactionId)
        For Each img In uploadImages
            transaction.UploadImages.Add(img.objectImage)
        Next
    End Sub

    Public Function GetTransactionsDetail() As List(Of TransactionDetail)
        Dim transactions = GetTransactions()
        If IsNothing(transactions) Then Return Nothing
        Dim result As New List(Of TransactionDetail)
        For Each item In transactions
            Dim currentDetail As New TransactionDetail(item)
            ProcessFindDetailForTransaction(currentDetail)
            result.Add(currentDetail)
        Next
        Return result
    End Function

    Public Function GetTransactionsDetail(selectedDate As Date) As List(Of TransactionDetail)
        Dim transactions = GetTransactions().Where(Function(t) t.CreateDate.Date = selectedDate.Date).OrderByDescending(Function(t) t.CreateDate).ToList()
        If IsNothing(transactions) Then Return Nothing
        Dim result As New List(Of TransactionDetail)
        For Each item In transactions
            Dim currentDetail As New TransactionDetail(item)
            ProcessFindDetailForTransaction(currentDetail)
            result.Add(currentDetail)
        Next
        Return result
    End Function

    Public Function GetDtTransactions(selectedDate As Date) As DataTable
        Dim transactions = GetTransactions().Where(Function(t) t.CreateDate.Date = selectedDate).OrderBy(Function(t) t.CreateDate).ToList()
        Dim dt As New DataTable()
        InitialDtColumns(dt)
        For Each item In transactions
            Dim row = dt.NewRow()
            SetValueToDataRow(row, item)
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    Private Sub InitialDtColumns(ByRef dt As DataTable)
        dt.Columns.Add("WONumber")
        dt.Columns.Add("Station")
        dt.Columns.Add("GateNo")
        dt.Columns.Add("PCA1")
        dt.Columns.Add("PCA2")
        dt.Columns.Add("GPU1")
        dt.Columns.Add("GPU2")
        dt.Columns.Add("FlightNo")
        dt.Columns.Add("AircraftType")
        dt.Columns.Add("AircraftReg")
        dt.Columns.Add("AircraftCarrier")
        dt.Columns.Add("ETA")
        dt.Columns.Add("ETD")
        dt.Columns.Add("PCAStart")
        dt.Columns.Add("PCAEnd")
        dt.Columns.Add("GPUStart")
        dt.Columns.Add("GPUEnd")
        dt.Columns.Add("PCATotalMin")
        dt.Columns.Add("GPUTotalMin")
        dt.Columns.Add("ServiceRate")
        dt.Columns.Add("Valid")
        dt.Columns.Add("Printed")
        dt.Columns.Add("CreateBy")
        dt.Columns.Add("CustIDStart")
        dt.Columns.Add("CustIDStop")
        dt.Columns.Add("CondOfCharge")
        dt.Columns.Add("Remark")
        dt.Columns.Add("UpdateBy")
        dt.Columns.Add("UpdateDate")
        dt.Columns.Add("CreateDate")
    End Sub

    Private Sub SetValueToDataRow(ByRef row As DataRow, data As Transaction)
        row("WONumber") = data.WONumber
        row("Station") = data.Station
        row("GateNo") = data.GateNo
        row("PCA1") = data.PCA1
        row("PCA2") = data.PCA2
        row("GPU1") = data.GPU1
        row("GPU2") = data.GPU2
        row("FlightNo") = data.FlightNo
        row("AircraftType") = data.AircraftType
        row("AircraftReg") = data.AircraftReg
        row("AircraftCarrier") = data.AircraftCarrier
        row("ETA") = If(String.IsNullOrEmpty(data.ETA), "", Date.ParseExact(data.ETA, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture))
        row("ETD") = If(String.IsNullOrEmpty(data.ETD), "", Date.ParseExact(data.ETD, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture))
        row("PCAStart") = If(String.IsNullOrEmpty(data.PCAStart), "", Date.ParseExact(data.PCAStart, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture))
        row("PCAEnd") = If(String.IsNullOrEmpty(data.PCAEnd), "", Date.ParseExact(data.PCAEnd, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture))
        row("GPUStart") = If(String.IsNullOrEmpty(data.GPUStart), "", Date.ParseExact(data.GPUStart, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture))
        row("GPUEnd") = If(String.IsNullOrEmpty(data.GPUEnd), "", Date.ParseExact(data.GPUEnd, "yyyyMMddHHmmss", Globalization.CultureInfo.InvariantCulture))
        row("PCATotalMin") = data.PCATotalMin
        row("GPUTotalMin") = data.GPUTotalMin
        row("ServiceRate") = data.ServiceRate
        row("Valid") = data.Valid
        row("Printed") = data.Printed
        row("CreateBy") = data.CreateBy
        row("CustIDStart") = data.CustIDStart
        row("CustIDStop") = data.CustIDStop
        row("CondOfCharge") = data.CondOfCharge
        row("Remark") = data.Remark
        row("UpdateBy") = data.UpdateBy
        row("UpdateDate") = data.UpdateDate
        row("CreateDate") = data.CreateDate
    End Sub

#End Region

#Region "TempTransaction"

    Public Function AddTempTransaction(model As TempTransaction) As Boolean
        Using repository As New TempTransactionRepository()
            Return repository.AddTempTransaction(model)
        End Using
    End Function

    Public Function GetTempTransactionsDetail(station As String) As List(Of TransactionDetail)
        Dim models As List(Of TempTransaction) = Nothing
        Using repository As New TempTransactionRepository()
            models = repository.GetTempTransactions().Where(Function(t) t.Station = station).OrderByDescending(Function(t) t.CreateDate).ToList()
        End Using
        If IsNothing(models) OrElse models.Count = 0 Then Return Nothing
        Return (From t In models Select New TransactionDetail(t)).ToList()
    End Function

    Public Function GetTempTransaction(id As Integer) As TempTransaction
        Using repository As New TempTransactionRepository()
            Return repository.GetTempTransaction(id)
        End Using
    End Function

    Public Function RemoveTempTransaction(id As Integer) As Boolean
        Using repository As New TempTransactionRepository()
            Dim model = repository.GetTempTransaction(id)
            If IsNothing(model) Then Return False
            Return repository.RemoveTempTransaction(model)
        End Using
    End Function

    Public Function ProcessRemoveTempTransaction(id As Integer) As Boolean
        Dim result = RemoveTempTransaction(id)
        'delete uploadimage 
        If result Then RemoveUploadImagesByRefId(id)
        Return result
    End Function

#End Region

#Region "FlightData"

    Public Function AddFlightData(model As FlightData) As Boolean
        Using repository As New FlightDataRepository()
            Return repository.AddFlightData(model)
        End Using
    End Function

    Public Function GetFlightData(id As Integer) As FlightData
        Using repository As New FlightDataRepository()
            Return repository.GetFlightData(id)
        End Using
    End Function

    Public Function GetFlightDatas() As List(Of FlightData)
        Using repository As New FlightDataRepository()
            Return repository.GetFlightDatas()
        End Using
    End Function

    Public Function GetFlightDatas(selectedDate As Date) As List(Of FlightData)
        Using repository As New FlightDataRepository()
            Return repository.GetFlightDatas(selectedDate)
        End Using
    End Function

    Public Function EditFlightData(model As FlightData) As Boolean
        Using repository As New FlightDataRepository()
            Return repository.EditFlightData(model)
        End Using
    End Function

    Public Function RemoveFlightData(id As Integer) As Boolean
        Using repository As New FlightDataRepository()
            Return repository.RemoveFlightData(id)
        End Using
    End Function

    Public Function ImportFlightDataByDatatable(dt As DataTable, selectedDate As Date) As Boolean
        Try
            If IsNothing(dt) Then Return False
            Dim flightDatas As New List(Of FlightData)
            For Each row As DataRow In dt.Rows
                If String.IsNullOrEmpty(row(4).ToString()) OrElse String.IsNullOrEmpty(row(5).ToString()) Then Continue For
                Dim sta As DateTime = If(row(4).ToString().Length <= 5, New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day, row(4).ToString().Split(":")(0), row(4).ToString().Split(":")(1), 0), DirectCast(row(4), DateTime))
                Dim std As DateTime = If(row(4).ToString().Length <= 5, New DateTime(Date.Now.Year, Date.Now.Month, Date.Now.Day, row(5).ToString().Split(":")(0), row(5).ToString().Split(":")(1), 0), DirectCast(row(5), DateTime))
                Dim currentFlightData As New FlightData() With {
                    .FlightNo = row(0).ToString().Replace(" ", ""),
                    .ACType = row(1),
                    .ACCarrier = row(2),
                    .ACReg = row(3),
                    .STA = New Date(selectedDate.Year, selectedDate.Month, selectedDate.Day, sta.Hour, sta.Minute, 0),
                    .STD = New Date(selectedDate.Year, selectedDate.Month, selectedDate.Day, std.Hour, std.Minute, 0),
                    .GateNo = row(6)
                    }
                flightDatas.Add(currentFlightData)
            Next
            'remove recent data of selected date
            Using repository As New FlightDataRepository()
                Dim recentDatas = repository.GetFlightDatas(selectedDate)
                repository.RemoveFlightDatas(recentDatas)
            End Using
            'add datas from CSV file
            For Each item In flightDatas
                AddFlightData(item)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub RemoveTrashFlightData()
        Using repository As New FlightDataRepository()
            Dim models = repository.GetFlightDatas().Where(Function(f) f.STA.Date < DateAdd(DateInterval.Day, -30, Date.Now())).ToList()
            repository.RemoveFlightDatas(models)
        End Using
    End Sub

#End Region

#Region "Sequence"

    Public Sub GenerateNewSequence()
        Dim sequenceNo = GetRandomSequenceNo()
        'check is exist
        Using repository As New SequenceRepository()
            Dim sequence = repository.GetSequence()
            If IsNothing(sequence) Then
                'create new sequence
                sequence = New Sequence() With {.SequenceNo = sequenceNo, .UpdateDate = DateTime.Now()}
                repository.AddSequence(sequence)
            Else
                'check is duplicate
                Do Until sequenceNo <> sequence.SequenceNo
                    sequenceNo = GetRandomSequenceNo()
                Loop
                'update sequence
                sequence.SequenceNo = sequenceNo
                repository.EditSequence(sequence)
            End If
        End Using
    End Sub

    Private Function GetRandomSequenceNo() As String
        Dim rdm As New Random()
        Return rdm.Next(10000, 99999)
    End Function

    Public Function GetSequence() As Sequence
        Using repository As New SequenceRepository()
            Return repository.GetSequence()
        End Using
    End Function

#End Region

#Region "Log"

    Public Function AddLog(model As Log) As Boolean
        Using repository As New LogRepository()
            Return repository.AddLog(model)
        End Using
    End Function

    Public Function GetLogs() As List(Of Log)
        Using repository As New LogRepository()
            Return repository.GetLogs()
        End Using
    End Function

    Public Function GetViewLogs() As List(Of VW_Log)
        Using repository As New ViewLogRepository()
            Return repository.GetViewLogs()
        End Using
    End Function

#End Region

    Private Function FindLogoForTransaction(flightNo As String, sta As DateTime, std As DateTime) As String
        Try
            Using repository As New DA.DTERepository()
                Return (From a In repository.DTEDBContext.AirlineMasterDatas Join f In repository.DTEDBContext.FlightDatas On a.ALC3 Equals f.ACCarrier
                        Where f.FlightNo = flightNo AndAlso f.STA = sta AndAlso f.STD = std Select a).SingleOrDefault().ImageLogo
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class
