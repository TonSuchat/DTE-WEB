@Imports Microsoft.AspNet.Identity

@If Helpers.CheckIsAuthen() Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @*@Html.AntiForgeryToken()*@
        @<ul class="nav navbar-nav navbar-right">
            <li>
                <a href="#">สวัสดี  @Helpers.GetCurrentUser().UserName </a>
            </li>
            <li><a href="javascript:document.getElementById('logoutForm').submit()">ออกจากระบบ</a></li>
            <li><a href="#">เวลา : @DateTime.Now().ToString("HH:mm:ss") น.</a></li>
        </ul>
    End Using
Else
    @<ul class="nav navbar-nav navbar-right">
        <li>@Html.ActionLink("เข้าสู่ระบบ", "LogIn", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
        <li>@Html.ActionLink("เข้าสู่ระบบ-Admin", "LogInAdmin", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginAdminLink"})</li>
        <li><a href="#">เวลา : @DateTime.Now().ToString("HH:mm:ss") น.</a></li>
    </ul>
End If

