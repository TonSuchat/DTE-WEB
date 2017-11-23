@ModelType ChangePasswordViewModel

@Code
    ViewData("Title") = "เปลี่ยนรหัสผ่าน"
End Code

@section scripts

    <script type="text/javascript">

        $(function () {
            $('#btnChangePassword').click(function () {
                if (!$('#formAccountChangePassword').valid()) return;
                if (!confirm('ต้องการเปลี่ยนรหัสผ่าน?')) return;
                $('#formAccountChangePassword').submit();
            });
        });

    </script>

End Section

<div class="row">
    <h2>เปลี่ยนรหัสผ่าน</h2>

    @Using Html.BeginForm("ChangePassword", "Account", FormMethod.Post, New With {.id = "formAccountChangePassword"})

        @Html.ValidationSummary(True)

        @Html.Hidden("Id", Helpers.GetCurrentUser().id)

        @<div class="form-group">
            @Html.LabelFor(Function(c) c.OldPassword)
            @Html.TextBoxFor(Function(f) f.OldPassword, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.OldPassword)
        </div>

        @<div class="form-group">
            @Html.LabelFor(Function(c) c.NewPassword)
            @Html.TextBoxFor(Function(f) f.NewPassword, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.NewPassword)
        </div>

        @<div class="form-group">
            @Html.LabelFor(Function(c) c.ConfirmPassword)
            @Html.TextBoxFor(Function(f) f.ConfirmPassword, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.ConfirmPassword)
        </div>

        @<input type="button" class="btn btn-default btn-primary" value="เปลี่ยนรหัสผ่าน" id="btnChangePassword" />

    End Using

    
</div>


