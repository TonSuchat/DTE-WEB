@ModelType LogInViewModel

@Code
    ViewData("Title") = "เข้าสู่ระบบ-Admin"
End Code

<div class="row">
    <h2>เข้าสู่ระบบ-Admin</h2>
    <div class="col-md-12">
        <section id="loginForm">
            @Using Html.BeginForm("LogInAdmin", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @<div class="form-group">
                    @Html.LabelFor(Function(m) m.UserName)
                    @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.UserName, "", New With {.class = "text-danger"})
                </div>
                @<div class="form-group">
                    @Html.LabelFor(Function(m) m.Password)
                    @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                </div>
                @<div class="form-group">
                    <input type="submit" id="btnLogIn" value="Log in" class="btn btn-default" />
                </div>
            End Using
        </section>

        <div class="row">
            <p>UserName = admin</p>
            <p>Password = password</p>
        </div>

    </div>
</div>
