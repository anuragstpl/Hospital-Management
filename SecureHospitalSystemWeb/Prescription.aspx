<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="Prescription.aspx.cs" Inherits="DoctorAppointmentWeb.Prescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add Patient Prescription
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Patient</a></li>
                    <li class="active">Add Prescription</li>
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
                                <address>
                                    <asp:Label runat="server" ID="lblDocName" Text="DocName"></asp:Label><br>
                                    <asp:Label runat="server" ID="lblSpeciality" Text="Speciality"></asp:Label><br>
                                </address>
                                <address>
                                    <strong>Address</strong><br>
                                    <asp:Label runat="server" ID="lblAddress" Text="Address Label"></asp:Label><br />
                                    <asp:Label runat="server" ID="lblEmail" Text="Email"></asp:Label>
                                    <br />
                                    <h3>Rx</h3>
                                    <br>
                                </address>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Enter Medicine*</label>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Select Frequency*</label>

                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label></label>
                                    <asp:TextBox runat="server" ID="txtMedicine1" CssClass="form-control" placeholder="Enter Medicine"></asp:TextBox>
                                </div>
                                </div>
                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" ID="ddlFrequency"  CssClass="form-control">
                                        <asp:ListItem>Once in a Day</asp:ListItem>
                                        <asp:ListItem>Twice in a Day</asp:ListItem>
                                        <asp:ListItem>Thrice in a Day</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label></label>
                                    <asp:TextBox runat="server" ID="txtMedicine2" CssClass="form-control" placeholder="Enter Medicine"></asp:TextBox>
                                </div>
                                </div>

                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" ID="ddlFrequency2"  CssClass="form-control">
                                        <asp:ListItem>Once in a Day</asp:ListItem>
                                        <asp:ListItem>Twice in a Day</asp:ListItem>
                                        <asp:ListItem>Thrice in a Day</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                              <div class="col-md-6">
                                <div class="form-group">
                                    <label></label>
                                    <asp:TextBox runat="server" ID="txtMedicine3" CssClass="form-control" placeholder="Enter Medicine"></asp:TextBox>
                                </div>
                                </div>
                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" ID="ddlFrequency3"  CssClass="form-control">
                                        <asp:ListItem>Once in a Day</asp:ListItem>
                                        <asp:ListItem>Twice in a Day</asp:ListItem>
                                        <asp:ListItem>Thrice in a Day</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                              <div class="col-md-6">
                                <div class="form-group">
                                    <label></label>
                                    <asp:TextBox runat="server" ID="txtMedicine4" CssClass="form-control" placeholder="Enter Medicine"></asp:TextBox>
                                </div>
                                </div>
                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" ID="ddlFrequency4"  CssClass="form-control">
                                        <asp:ListItem>Once in a Day</asp:ListItem>
                                        <asp:ListItem>Twice in a Day</asp:ListItem>
                                        <asp:ListItem>Thrice in a Day</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                              <div class="col-md-6">
                                <div class="form-group">
                                    <label></label>
                                    <asp:TextBox runat="server" ID="txtMedicine5" CssClass="form-control" placeholder="Enter Medicine"></asp:TextBox>
                                </div>
                                </div>
                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" ID="ddlFrequency5"  CssClass="form-control">
                                        <asp:ListItem>Once in a Day</asp:ListItem>
                                        <asp:ListItem>Twice in a Day</asp:ListItem>
                                        <asp:ListItem>Thrice in a Day</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            
                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnSavePrescription" Text="Save Presecription" CssClass="btn btn-block btn-success" OnClick="btnSavePrescription_Click"/>
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
</asp:Content>
