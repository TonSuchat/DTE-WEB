@code
    ViewData("Title") = "Import-Excel"
End Code

@Using Html.BeginForm("ImportExcel", "FlightData", FormMethod.Post, New With {.enctype = "multipart/form-data"})

    @<div class="row">
        <a class="btn btn-primary" href="@Url.Action("ManageFlightData", "FlightData")">ย้อนกลับ</a>
    </div>

    @<div class="row">
         <div Class="jumbotron">
             @Html.ValidationSummary(True)
             <p> เลือกไฟล์ Excel ที่ต้องการ upload ชื่อไฟล์จะต้องเป็นวันที่ของข้อมูลในไฟล์ เช่น 20170822.xls เป็นต้น</p>
             <p> <input type="file" accept=".xlsx,.csv" name="uploadFile" value="Upload-Excel" /></p>
             <Button type="submit" Class="btn btn-lg btn-primary">ตกลง</Button>
         </div>
    </div>
End Using

