Imports System.IO
Imports DTE.Entities
Imports DTE.Services

Namespace Controllers

    <AuthorizationFilter()>
    Public Class ServiceOrderController
        Inherits Controller

        Private services As New ServiceOrderServices

        Function Index() As ActionResult
            Return View()
        End Function

        Function ManageServiceOrder() As ActionResult
            Return View(services.GetTransactionsDetail())
        End Function

        Function Detail(id As Integer) As ActionResult
            Return View(services.GetTransactionDetail(id))
        End Function

        Function EditSO(id As Integer) As ActionResult
            Return View(services.GetTransactionDetail(id))
        End Function

        <HttpPost()>
        Function RemoveSO(id As Integer) As ActionResult
            services.RemoveTransaction(id)
            Return RedirectToAction("ManageServiceOrder")
        End Function

        Function ExportExcel() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function ExportExcel(model As ExportExcelViewModel) As ActionResult
            Try
                Dim dt As DataTable = services.GetDtTransactions(model.SelectedDate)
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    Dim fileName As String = String.Format("SO_{0}", model.SelectedDate.ToString("yyyyMMdd"))
                    Dim grid As New GridView()
                    grid.DataSource = dt
                    grid.DataBind()

                    Response.ClearContent()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", "attachment; filename=" & fileName & ".xls")
                    Response.ContentType = "application/ms-excel"

                    Response.Charset = ""
                    Dim sw As New StringWriter()
                    Dim htw As New HtmlTextWriter(sw)

                    grid.RenderControl(htw)

                    Response.Output.Write(sw.ToString())
                    Response.Flush()
                    Response.End()
                Else : ModelState.AddModelError("", "ไม่พบข้อมูลในวันที่เลือก")
                End If
                Return View()
            Catch ex As Exception
                Helpers.LogTxt(ex.ToString())
                ModelState.AddModelError("", "เกิดข้อผิดพลาด")
                Return View()
            End Try
        End Function

    End Class

End Namespace