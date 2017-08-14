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
                Dim gpuStart As New SqlParameter("GPUStart", model.GPUStart) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim gpuEnd As New SqlParameter("GPUEnd", model.GPUEnd) With {.SqlDbType = SqlDbType.NVarChar, .Size = 14}
                Dim createBy As New SqlParameter("CreateBy", model.CreateBy) With {.SqlDbType = SqlDbType.Int}
                Dim custIdStart As New SqlParameter("CustIDStart", model.CustIDStart) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim custSignStart As New SqlParameter("CustSignStart", model.CustSignStart) With {.SqlDbType = SqlDbType.NVarChar, .Size = 4000}
                Dim custIdStop As New SqlParameter("CustIDStop", model.CustIDStop) With {.SqlDbType = SqlDbType.NVarChar, .Size = 10}
                Dim custSignStop As New SqlParameter("CustSignStop", model.CustSignStop) With {.SqlDbType = SqlDbType.NVarChar, .Size = 4000}
                Dim condOfCharge As New SqlParameter("CondOfCharge", model.CondOfCharge) With {.SqlDbType = SqlDbType.NVarChar, .Size = 255}
                Dim remark As New SqlParameter("Remark", model.Remark) With {.SqlDbType = SqlDbType.NVarChar, .Size = 255}
                'initial output parameters
                Dim success As New SqlParameter("Success", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                Dim retmessage As New SqlParameter("RetMsg", SqlDbType.NVarChar) With {.Direction = ParameterDirection.Output, .Size = 255}

                repository.DTEDBContext.Database.ExecuteSqlCommand("sp_Insert_SO @Station, @GateNo, @PCA1, @PCA2, @GPU1, @GPU2, @FlightNo, @AircraftType, @AircraftReg, @AircraftCarrier, @ETA, 
                                                                @ETD, @PCAStart, @PCAEnd, @GPUStart, @GPUEnd, @CreateBy, @CustIDStart, @CustSignStart, @CustIDStop, @CustSignStop,
                                                                @CondOfCharge, @Remark,@Success out, @RetMsg out",
                                                                   station, gateNo, pca1, pca2, gpu1, gpu2, flightNo, acType, acReg, acCar, eta, etd, pcaStart, pcaEnd, gpuStart, gpuEnd, createBy,
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


#Region "User"

    Public Function Login(username As String, password As String) As Boolean
        Using repository As New UserRepository()
            Return If(Not IsNothing(repository.GetUser(username, password)), True, False)
        End Using
    End Function

#End Region

#Region "UploadImage"

    Public Function AddUploadImages(models As List(Of UploadImage)) As Boolean
        Using repository As New UploadImageRepository()
            Return repository.AddUploadImages(models)
        End Using
    End Function

#End Region

End Class
