<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="AssignRoom.aspx.cs" Inherits="DoctorAppointmentWeb.AssignRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Assign Room
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Room</a></li>
                    <li class="active">Assign Room</li>
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
                    <div class="box-header with-border">
                        <h3 class="box-title"><asp:Label runat="server" ID="lblMessage" ></asp:Label></h3>

                       
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Select Patient*</label>
                                    <asp:DropDownList runat="server" ID="ddlPatient" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Select Room*</label>
                                    <asp:DropDownList runat="server" ID="ddlRoom" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Assigned Date*</label>
                                    <asp:TextBox runat="server" ID="txtAssignedDate" CssClass="form-control" required></asp:TextBox>
                                    <img src="calender.png" />
                                </div>
                            </div>
                            <!-- /.col -->



                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAssignRoom" Text="Assign Room" CssClass="btn btn-block btn-success" OnClick="btnAssignRoom_Click" />
                                </div>
                            </div>
                            <div class="col-md-6" style="width:100%;">
                                <asp:ListView ID="lstRoomAssigns" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstRoomAssigns_PagePropertiesChanging">
                                    <LayoutTemplate>
                                        <section class="content">
                                            <div class="row">
                                                <div class="col-xs-12" style="width: 84%">
                                                    <div class="box">
                                                        <div class="box-header">
                                                            <h3 class="box-title">Assigned Rooms</h3>
                                                        </div>
                                                        <!-- /.box-header -->
                                                        <div class="box-body">
                                                            <table id="example2" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Room Assign ID</th>
                                                                        <th>Room Name</th>
                                                                        <th>Patient Name</th>
                                                                        <th>Assign Date</th>
                                                                        <th>Saved Date</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>

                                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                                </tbody>
                                                                <tfoot>
                                                                    <tr>
                                                                        <td colspan="6">
                                                                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstRoomAssigns" PageSize="10">
                                                                                <Fields>
                                                                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                                                        ShowNextPageButton="false" />
                                                                                    <asp:NumericPagerField ButtonType="Link" />
                                                                                    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                                                                </Fields>
                                                                            </asp:DataPager>
                                                                        </td>
                                                                    </tr>
                                                                </tfoot>
                                                            </table>

                                                        </div>
                                                        <!-- /.box-body -->
                                                    </div>
                                                </div>
                                            </div>
                                        </section>
                                    </LayoutTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("RoomAssignID") %></td>
                                            <td><%# Eval("RoomName") %></td>
                                            <td><%# Eval("Name") %></td>
                                            <td><%# Eval("AssignDate") %></td>
                                            <td><%# Eval("Savedon") %></td>

                                        </tr>
                                    </ItemTemplate>


                                </asp:ListView>
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

    <script src="Scripts/jquery-3.1.1.js"></script>
    <link href="Content/calendar-blue.css" rel="stylesheet" />
    <script src="Scripts/jquery.dynDateTime.min.js"></script>
    <script src="Scripts/calendar-en.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtAssignedDate").dynDateTime({
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
