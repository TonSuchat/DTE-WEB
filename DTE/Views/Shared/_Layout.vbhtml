<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("DTE", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    @if Helpers.CheckIsAuthen() Then
                        @<li><a href="@Url.Action("ManageServiceOrder", "ServiceOrder")">ข้อมูล Service-Order</a></li>
                        @<li> <a href="@Url.Action("ManageFlightData", "FlightData")">ข้อมูล Flight-Data</a></li>
                        @<li> <a href="@Url.Action("ManageAirlineMasterData", "Airline")">ข้อมูล Airline</a></li>
                        If Helpers.GetCurrentUser().IsAdmin Then
                            @<li Class="dropdown">
                                <a href="#" Class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Admin <span Class="caret"></span></a>
                                <ul Class="dropdown-menu">
                                    <li> <a href="@Url.Action("ManageUser", "Admin")"> จัดการ-User</a></li>
                                    <li> <a href="@Url.Action("Log", "Admin")"> ดู-Log</a></li>
                                </ul>
                            </li>
                        End If
                    End If
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - DTE Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
