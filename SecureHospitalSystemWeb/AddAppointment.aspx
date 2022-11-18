<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="AddAppointment.aspx.cs" Inherits="DoctorAppointmentWeb.AddAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-1.9.0.js"></script>
      <link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker.css">
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker3.css">
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="../../plugins/iCheck/all.css">
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="../../plugins/colorpicker/bootstrap-colorpicker.min.css">
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="../../plugins/timepicker/bootstrap-timepicker.min.css">
    <!-- Select2 -->
    <link rel="stylesheet" href="/plugins/select2/select2.min.css">
    <script src="Scripts/jquery.dynDateTime.min.js"></script>
    <script src="Scripts/calendar-en.min.js"></script>
    <link href="Content/calendar-blue.css" rel="stylesheet" />
     <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add Patient
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Patient</a></li>
                    <li class="active">Add Patient</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">General Info</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Subject*</label>
                                    <asp:TextBox runat="server" ID="txtSubject" CssClass="form-control" placeholder="Enter Subject" required ></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Select Patient*</label>
                                    <asp:DropDownList runat="server" ID="drpPatient" CssClass="form-control">
                                        
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Start Date*</label>
                                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control" placeholder="Select Start Date"  required ></asp:TextBox>
                                    <img src="calender.png" />
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>End Date*</label>
                                    <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control" placeholder="Select End Date" required ></asp:TextBox>
                                    <img src="calender.png" />
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Description*</label>
                                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescription" Rows="5" CssClass="form-control" placeholder="Enter Description" required ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Button runat="server" ID="btnAddAppointment" Text="Add Appointment" CssClass="btn btn-block btn-success" OnClick="btnAddAppointment_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>
            <!-- /.content -->
            <!-- General Info -->
            
            <!-- /.content -->
        </div>

    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtStartDate").dynDateTime({
            showsTime: true,
            ifFormat: "%Y/%m/%d %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
            });
            $("#ContentPlaceHolder1_txtEndDate").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m, %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
    });
</script>
</asp:Content>
