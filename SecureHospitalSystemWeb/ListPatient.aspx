<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ListPatient.aspx.cs" Inherits="DoctorAppointmentWeb.ListPatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lstCustomers" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemDeleting="lstCustomers_ItemDeleting" OnItemCommand="lstCustomers_ItemCommand" OnPagePropertiesChanging="lstCustomers_PagePropertiesChanging" >
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width:84%">
                        <div class="box" style="margin-left:220px;">
                            <div class="box-header">
                                <h3 class="box-title">Patients</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>Username</th>
                                            <th>Name</th>
                                            <th>Email</th>
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
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstCustomers" PageSize="10">
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
            <td><%# Eval("Email") %></td>
            <td><%# Eval("Address") %></td>
            <td>
                <asp:LinkButton runat="server" ID="lnkDelete" CssClass="fa fa-fw fa-remove" OnClientClick="javascript:return confirm('Are you sure you want to delete this item?');" CommandArgument='<%# Eval("UserID") %>' ToolTip="Delete Patient" CommandName="Delete"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" ID="lnkEdit" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("UserID") %>' ToolTip="Edit Patient" CommandName="Edit"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" ID="lnkDocs" CssClass="fa fa-fw fa-files-o" CommandArgument='<%# Eval("UserID") %>' ToolTip="Add Health Records" CommandName="Document"></asp:LinkButton>
                &nbsp;<asp:LinkButton runat="server" ID="LinkButton1" CssClass="fa fa-calendar" CommandArgument='<%# Eval("UserID") %>' ToolTip="Set Appointment" CommandName="Appointment"></asp:LinkButton>
                &nbsp;<asp:LinkButton runat="server" ID="LinkButton2" CssClass="fa fa-stethoscope" CommandArgument='<%# Eval("UserID") %>' ToolTip="Prescribe Medicine" CommandName="Prescribe"></asp:LinkButton>
            </td>
                </tr>
        </ItemTemplate>


    </asp:ListView>
</asp:Content>
