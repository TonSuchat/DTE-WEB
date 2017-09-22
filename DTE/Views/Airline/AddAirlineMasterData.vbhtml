@ModelType Entities.AirlineMasterData

@Code
    ViewData("Title") = "เพิ่มข้อมูล Airline"
End Code

@section scripts

    <script type="text/javascript">
        $(function () {

            $('#imgPreview').hide();

            $('#uploadFile').on('change', function () {
                if ($(this).prop('files') == null) return;
                var FR = new FileReader();
                FR.addEventListener("load", function(e){
                    $('#imgPreview').prop('src', e.target.result);
                    $('#Logo').val(e.target.result);
                });
                FR.readAsDataURL($(this).prop('files')[0]);
                $('#imgPreview').show();
            });
        });
    </script>

End Section

<div class="row">
    <a class="btn btn-primary" href="@Url.Action("ManageAirlineMasterData", "Airline")">ย้อนกลับ</a>
</div>


@Using Html.BeginForm("AddAirlineMasterData", "Airline", FormMethod.Post)
    @<div Class="row">
        <h2> เพิ่มข้อมูล Airline</h2>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.ALC2)
            @Html.TextBoxFor(Function(a) a.ALC2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ALC2)
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.ALC3)
            @Html.TextBoxFor(Function(a) a.ALC3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ALC3)
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.ALFN)
            @Html.TextBoxFor(Function(a) a.ALFN, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ALFN)
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.ADD1)
            @Html.TextBoxFor(Function(a) a.ADD1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD1)
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.ADD2)
            @Html.TextBoxFor(Function(a) a.ADD2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD2)
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.ADD3)
            @Html.TextBoxFor(Function(a) a.ADD3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD3)
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.ADD4)
            @Html.TextBoxFor(Function(a) a.ADD4, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD4)
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(a) a.EmailAddress)
            @Html.TextBoxFor(Function(a) a.EmailAddress, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.EmailAddress)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.Logo)
            <input type="file" id="uploadFile" accept=".png,.jpeg,.jpg" />
            @Html.Hidden("Logo", "", New With {.id = "Logo"})
            <img id="imgPreview" style="margin-top:10px;" src="" width="220" height="130" />
        </div>

        <Button type="submit" Class="btn btn-default btn-primary">ตกลง</Button>

    </div>
End Using




