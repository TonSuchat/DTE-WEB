@ModelType Entities.AirlineMasterData

@Code
    ViewData("Title") = "แก้ไขข้อมูล Airline"
End Code

<div class="row">
    <a class="btn btn-primary" href="@Url.Action("ManageAirlineMasterData", "Airline")">ย้อนกลับ</a>
</div>

@Using Html.BeginForm("EditAirlineMasterData", "Airline", FormMethod.Post)
    @<div class="row">
        <h2>แก้ไขข้อมูล Airline</h2>

        @Html.HiddenFor(Function(a) a.Id)
        @Html.HiddenFor(Function(a) a.CreateDate)

        <div class="form-group">
            @Html.LabelFor(Function(a) a.ALC2)
            @Html.TextBoxFor(Function(a) a.ALC2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ALC2)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.ALC3)
            @Html.TextBoxFor(Function(a) a.ALC3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ALC3)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.ALFN)
            @Html.TextBoxFor(Function(a) a.ALFN, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ALFN)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.ADD1)
            @Html.TextBoxFor(Function(a) a.ADD1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD1)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.ADD2)
            @Html.TextBoxFor(Function(a) a.ADD2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD2)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.ADD3)
            @Html.TextBoxFor(Function(a) a.ADD3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD3)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.ADD4)
            @Html.TextBoxFor(Function(a) a.ADD4, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.ADD4)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(a) a.EmailAddress)
            @Html.TextBoxFor(Function(a) a.EmailAddress, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(a) a.EmailAddress)
        </div>

        <button type="submit" class="btn btn-primary">ตกลง</button>

    </div>
End Using




