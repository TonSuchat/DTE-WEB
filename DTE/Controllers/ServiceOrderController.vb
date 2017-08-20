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

        'Function CreateServiceOrder() As ActionResult
        '    Return View(New ServiceOrder.InputSPInsertSO())
        'End Function

        '<HttpPost()>
        'Function CreateServiceOrder(model As ServiceOrder.InputSPInsertSO)
        '    If ModelState.IsValid Then
        '        Dim result = services.ExecuteStoredInsertSO(model)
        '        ViewData("result") = result
        '    End If
        '    Return View(model)
        'End Function

        '<HttpPost()>
        'Function CalcRate(model As ServiceOrder.InputServiceRate) As JsonResult
        '    'If ModelState.IsValid Then
        '    Dim result = services.ExecuteStoredCalcServiceRate(model)
        '    'ViewData("result") = result
        '    'End If
        '    Return Json(result)
        'End Function

    End Class

End Namespace