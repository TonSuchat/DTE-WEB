@ModelType LogInViewModel

@Code
    ViewData("Title") = "เข้าสู่ระบบ"
End Code


<div class="row">
    <h2>เข้าสู่ระบบ</h2>
    <div class="col-md-12">
        <section id="loginForm">
            @Using Html.BeginForm("LogIn", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @<div class="form-group">
                    @Html.LabelFor(Function(m) m.UserName)
                    @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.UserName, "", New With {.class = "text-danger"})
                </div>
                @<div class="form-group">
                    @Html.LabelFor(Function(m) m.Password)
                    @Html.TextBoxFor(Function(m) m.Password, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                </div>
                @<div class="form-group">
                    <input type="submit" id="btnLogIn" value="เข้าสู่ระบบ" class="btn btn-default" />
                </div>
            End Using
        </section>
    </div>
</div>



