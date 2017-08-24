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
            $('#tblFlight').DataTable({ "bSort": false });

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
        <a class="btn btn-lg btn-warning" href="@Url.Action("ImportExcel", "FlightData")">Import-Excel</a>
        <a class="btn btn-lg btn-success" href="@Url.Action("AddFlightData", "FlightData")">เพิ่มข้อมูล</a>
    </div>

    @If IsNothing(Model) OrElse Model.Count = 0 Then
        @Html.Partial("NotFoundData")
    Else
        @<div class="row">
            <table id="tblFlight" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th cla ss="text-center">Flight No.</th>
                        <th class="text-center">AC-Type</th>
                        <th class="text-center">AC-Carrier</th>
                        <th class="text-center">AC-Reg</th>
                        <th class="text-center">STA</th>
                        <th class="text-center">STD</th>
                        <th class="text-center">Gate No.</th>
                        <th class="text-center">CreateDate</th>
                        <th class="text-center">แก้ไข</th>
                        <th class="text-center">ลบ</th>
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
                        <td class="text-center">
                            <a class="btn btn-sm btn-warning" href="@Url.Action("EditFlightData", "FlightData", New With {.id = item.id})">
                                <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                            </a>
                        </td>
                        <td class="text-center">
                            @using Html.BeginForm("RemoveFlightData", "FlightData", FormMethod.Post, New With {.role = "form"})
                        @<input type="hidden" value="@item.id" name="id" />
                        @<button type="button" class="btn btn-sm btn-danger btnremove">
                            <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                        </button>
                            End Using
                        </td>
                    </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If

</div>
