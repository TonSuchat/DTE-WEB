@ModelType Entities.TransactionDetail

@Code
    ViewData("Title") = "รายละเอียด-SO"
End Code

<div class="row">
    @If IsNothing(Model) Then

    Else
        @<div>

            <div class="row">
                <div class="col-md-offset-2 col-md-8">
                    <h2>รายละเอียด-SO</h2>
                </div>
            </div>

            <div class="row">
                <div Class="col-md-offset-2 col-md-8 border form-horizontal">

                    <div class="form-group">
                        <label class="col-md-3 control-label">Station: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.Station</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">Air Carrier: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.AircraftCarrier</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">Flight No: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.FlightNo</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">Aircraft Type: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.AircraftType</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">Aircraft Reg: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.AircraftReg</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">Aircraft STA: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.ETA</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">Aircraft STD: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.ETD</p>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-md-3 control-label">Gate No: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.GateNo</p>
                        </div>
                    </div>

                </div>
            </div>

            <div class="row">
                <div class="col-md-offset-2 col-md-8 border form-horizontal">
                    <div class="form-group">
                        <label class="col-md-3 control-label">Signature-Start</label>
                        <div class="col-md-9">
                            <img class="img-responsive" src="@Model.CustSignStart" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">Signature-Stop</label>
                        <div class="col-md-9">
                            <img class="img-responsive" src="@Model.CustSignStop" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-offset-2 col-md-8 border form-horizontal">
                    <h2 class="text-center"><u>PCA,GPU</u></h2>
                    <div class="form-group">
                        <label class="col-md-3 control-label">1 Hose: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.PCA1</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">2 Hose: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.PCA2</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">PCA-TotalTime: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.PCATotalMin</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">1 Plug: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.GPU1</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">2 Plug: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.GPU2</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">GPU-TotalTime: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.GPUTotalMin</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-offset-2 col-md-8 border form-horizontal">
                    <h2 class="text-center"><u>Operated By</u></h2>
                    <div class="form-group">
                        <label class="col-md-3 control-label">Create ID No: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.CreateBy</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">Name: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.CreatedByName</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">Updated ID No: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.UpdateBy</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">Update-Name: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.UpdatedByName</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">Condition of charge: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.CondOfCharge</p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">Remark: </label>
                        <div class="col-md-9">
                            <p class="form-control-static">@Model.Remark</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div Class="col-md-offset-2 col-md-8 border form-horizontal">
                    <h2 class="text-center"><u>Upload Images</u></h2>
                    @For Each img In Model.UploadImages
                        @<img class="img-thumbnail" src="@img" />
                    Next
                </div>
            </div>
        </div>
    End If
</div>
