<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ListDoctors.aspx.cs" Inherits="DoctorAppointmentWeb.ListDoctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lstDoctors" runat="server" ItemPlaceholderID="groupPlaceHolder1"  OnItemCommand="lstDoctors_ItemCommand" OnPagePropertiesChanging="lstDoctors_PagePropertiesChanging" >
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width:84%">
                        <div class="box" style="margin-left:220px;">
                            <div class="box-header">
                                <h3 class="box-title">Doctors</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>Username</th>
                                            <th>Name</th>
                                            <th>Speciality</th>
                                            <th>Address</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
                                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="6">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstDoctors" PageSize="10">
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
            <td><%# Eval("Username") %></td>
            <td><%# Eval("Name") %></td>
            <td><%# Eval("Speciality") %></td>
            <td><%# Eval("Address") %></td>
            <td>
                <asp:LinkButton runat="server" ID="LinkButton1" CssClass="fa fa-calendar" CommandArgument='<%# Eval("UserID") %>' ToolTip="Set Appointment" CommandName="Appointment"></asp:LinkButton>
            </td>
                </tr>
        </ItemTemplate>


    </asp:ListView>
</asp:Content>
