Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        Dim services As New Services.ServiceOrderServices()
        Dim model As New Entities.ServiceOrder.InputSPInsertSO() With {
            .AircraftCarrier = "ICAO",
            .AircraftReg = "HS123",
            .AircraftType = "A380",
            .CondOfCharge = "Condition",
            .CreateBy = 1,
            .CustIDStart = "tester1",
            .CustIDStop = "tester1",
            .CustSignStart = "base64",
            .CustSignStop = "base64",
            .DateNow = DateTime.Now(),
            .ETA = "20170814092200",
            .ETD = "20170814092500",
            .FlightNo = "TG123",
            .GateNo = "A2",
            .GPU1 = True,
            .GPU2 = False,
            .GPUStart = "20170814092200",
            .GPUEnd = "20170814092700",
            .PCA1 = False,
            .PCA2 = True,
            .PCAStart = "20170814092200",
            .PCAEnd = "20170814092700",
            .Remark = "remark",
            .Station = "BKK"
            }

        Dim result = services.ExecuteStoredInsertSO(model)

        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
    Function Report() As ActionResult
        ViewData("Message") = "Your Report page."

        Return View()
    End Function
    Function Admin() As ActionResult
        ViewData("Message") = "Your Admin page."

        Return View()
    End Function
End Class
