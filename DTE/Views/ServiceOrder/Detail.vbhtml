@ModelType Entities.TransactionDetail

@Code
    ViewData("Title") = "รายละเอียด-SO"
    Dim imgIndex As Integer = 0
End Code

@section scripts
    <style type="text/css">
        #lightbox .modal-content {
            display: inline-block;
            text-align: center;   
            margin-top:20px;
        }

        #lightbox .close {
            opacity: 1;
            color: rgb(255, 255, 255);
            background-color: rgb(25, 25, 25);
            padding: 5px 8px;
            border-radius: 30px;
            border: 2px solid rgb(255, 255, 255);
            position: absolute;
            top: -15px;
            right: -55px;
            z-index:1032;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            var $lightbox = $('#lightbox');

            $('[data-target="#lightbox"]').on('click', function (event) {
                var $img = $(this).find('img'),
                    src = $img.attr('src'),
                    alt = $img.attr('alt'),
                    css = {
                        'maxWidth': $(window).width() - 250,
                        'maxHeight': $(window).height() - 250
                    };

                $lightbox.find('.close').addClass('hidden');
                $lightbox.find('img').attr('src', src);
                $lightbox.find('img').attr('alt', alt);
                $lightbox.find('img').css(css);
            });

            $lightbox.on('shown.bs.modal', function (e) {
                var $img = $lightbox.find('img');

                $lightbox.find('.modal-dialog').css({ 'width': $img.width() });
                $lightbox.find('.close').removeClass('hidden');
            });
        })
    </script>
End Section

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
                        <label class="col-md-3 control-label">Airline: </label>
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
                        <label class="col-md-3 control-label">PCA-Start: </label>
                        <div class="col-md-9">
                            @If Not String.IsNullOrEmpty(Model.PCAStart) Then
                                @<p Class="form-control-static">
                                    @Helpers.ConvertDateTimeDTEFormat(Model.PCAStart).ToString("dd/MM/yyyy HH:mm:ss")
                                </p>
                            Else
                                @<p Class="form-control-static">-</p>
                            End If
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label">PCA-Stop: </label>
                        <div class="col-md-9">
                            @If Not String.IsNullOrEmpty(Model.PCAEnd) Then
                                @<p Class="form-control-static">
                                    @Helpers.ConvertDateTimeDTEFormat(Model.PCAEnd).ToString("dd/MM/yyyy HH:mm:ss")
                                </p>
                            Else
                                @<p Class="form-control-static">-</p>
                            End If
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
                        <label class="col-md-3 control-label">GPU-Start: </label>
                        <div class="col-md-9">
                            @If Not String.IsNullOrEmpty(Model.GPUStart) Then
                                @<p Class="form-control-static">
                                    @Helpers.ConvertDateTimeDTEFormat(Model.GPUStart).ToString("dd/MM/yyyy HH:mm:ss")
                                </p>
                            Else
                                @<p Class="form-control-static">-</p>
                            End If
                        </div>
                    </div>
                    <div Class="form-group">
                        <Label Class="col-md-3 control-label">GPU-Stop: </Label>
                        <div Class="col-md-9">
                           @If Not String.IsNullOrEmpty(Model.GPUEnd) Then
                                @<p Class="form-control-static">
                                    @Helpers.ConvertDateTimeDTEFormat(Model.GPUEnd).ToString("dd/MM/yyyy HH:mm:ss")
                                </p>
                           Else
                                @<p Class="form-control-static">-</p>
                           End If
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
                    @for Each item In Model.UploadImages
                        @<div Class="col-xs-6 col-sm-3">
                            <a href="#" Class="thumbnail" data-toggle="modal" data-target="#lightbox"> 
                                <img src = "@item" alt="">
                            </a>
                        </div>
                    Next
                </div>
            </div>

             <div id = "lightbox" Class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                 <div Class="modal-dialog">
                     @*<Button type = "button" Class="close hidden" data-dismiss="modal" aria-hidden="true">×</button>*@
                     <div Class="modal-content">
                         <div Class="modal-body">
                             <img src = "" alt="" />
                         </div>
                     </div>
                 </div>
             </div>

        </div>
    End If
</div>
