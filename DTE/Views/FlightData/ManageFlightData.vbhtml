@ModelType List(Of Entities.FlightData)

@Code
    ViewData("Title") = "จัดการข้อมูล-Flight"
End Code


@section scripts

    <link href="~/Content/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">

        $(function () {

            var userType = +@Helpers.GetCurrentUser.Type;

            console.log(userType);

            if(userType == 1 || userType == 2)
            {
                $('#tblFlight').DataTable({
                    "bSort": false,
                    "columns": [
                        { "searchable": false },
                        { "searchable": false },
                        { "searchable": false },
                        { "searchable": false },
                        null,
                        null,
                        { "searchable": false },
                        { "searchable": false },
                        { "searchable": false },
                        { "searchable": false }
                    ]
                });
            }
            else
            {
                $('#tblFlight').DataTable({
                    "bSort": false,
                    "columns": [
                        { "searchable": false },
                        { "searchable": false },
                        { "searchable": false },
                        { "searchable": false },
                        null,
                        null,
                        { "searchable": false },
                        { "searchable": false }
                    ]
                });
            }

            $('.btnremove').click(function () {
                if (confirm('ต้องการลบข้อมูลนี้?')) {
                    $(this).parent('form').submit();
                }
            })

        })

    </script>

End Section

<div class="row">

    <h2>จัดการข้อมูล-Flight</h2>

    <div class="row">
        @If Helpers.GetCurrentUser.Type = 1 OrElse Helpers.GetCurrentUser.Type = 2 Then
            @<a class="btn btn-lg btn-warning" href="@Url.Action("ImportExcel", "FlightData")">Import-CSV</a>
            @<a Class="btn btn-lg btn-success" href="@Url.Action("AddFlightData", "FlightData")">เพิ่มข้อมูล</a>
        End If
    </div>

    @If IsNothing(Model) OrElse Model.Count = 0 Then
        @Html.Partial("NotFoundData")
    Else
        @<div class="row">
            <table id="tblFlight" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th class="text-center">Flight No.</th>
                        <th class="text-center">AC-Type</th>
                        <th class="text-center">Airline</th>
                        <th class="text-center">AC-Reg</th>
                        <th class="text-center">STA</th>
                        <th class="text-center">STD</th>
                        <th class="text-center">Gate No.</th>
                        <th class="text-center">วันที่สร้างรายการ</th>
                        @If Helpers.GetCurrentUser.Type = 1 OrElse Helpers.GetCurrentUser.Type = 2 Then
                            @<th Class="text-center">แก้ไข</th>
                            @<th Class="text-center">ลบ</th>
                        End If
                    </tr>
                </thead>
                <tbody>
                    @for Each item In Model
                        @<tr>
                            <td class="text-center">@item.FlightNo</td>
                            <td class="text-center">@item.ACType</td>
                            <td class="text-center">@item.ACCarrier</td>
                            <td class="text-center">@item.ACReg</td>
                            <td class="text-center">@item.STA.ToString("dd/MM/yyyy HH:mm")</td>
                            <td class="text-center">@item.STD.ToString("dd/MM/yyyy HH:mm")</td>
                            <td class="text-center">@item.GateNo</td>
                            <td class="text-center">@item.CreateDate.ToString("dd/MM/yyyy HH:mm")</td>
                            @If Helpers.GetCurrentUser.Type = 1 OrElse Helpers.GetCurrentUser.Type = 2 Then
                                @<td Class="text-center">
                                    <a Class="btn btn-sm btn-warning" href="@Url.Action("EditFlightData", "FlightData", New With {.id = item.id})">
                                        <span Class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                                    </a>
                                </td>
                                @<td Class="text-center">
                                    @Using Html.BeginForm("RemoveFlightData", "FlightData", FormMethod.Post, New With {.role = "form"})
                                        @<input type="hidden" value="@item.id" name="id" />
                                        @<button type="button" class="btn btn-sm btn-danger btnremove">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                        </button>
                                    End Using
                                </td>
                            End If
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If

</div>
