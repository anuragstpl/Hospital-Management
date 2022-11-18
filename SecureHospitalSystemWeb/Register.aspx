<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DoctorAppointmentWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <title>Doctor Appointment System Login</title>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css" />
</head>
<body class="hold-transition skin-blue sidebar-mini" style="background-color: #ecf0f5; margin-top:150px; margin-left:150px;">
    <div>
        <form id="form1" runat="server">
            <div class="content-wrapper">
                <section class="content">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="box box-info">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Doctor Appointment System Registration</h3>
                                </div>
                                <!-- /.box-header -->

                                <div class="box-body">
                                    <div class="form-group">
                                        <label for="txtName" class="col-sm-2 control-label">Name</label>

                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Name" required ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">Username</label>

                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">Email</label>

                                        <div class="col-sm-10">
                                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-sm-2 control-label">Password</label>

                                        <div class="col-sm-10">
                                             <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-sm-2 control-label">Confirm Password</label>

                                        <div class="col-sm-10">
                                             <asp:TextBox runat="server" TextMode="Password" ID="txtConfirmPassword" CssClass="form-control" placeholder="Repeat Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                         <label for="txtSpeciality" class="col-sm-2 control-label">Speciality</label>
                                       <div class="col-sm-10">
                                             <asp:TextBox runat="server" ID="txtSpeciality" CssClass="form-control" placeholder="Speciality"></asp:TextBox>
                                        </div>
                                       </div>
                                    </div>
                                    
                                     <div class="form-group">
                                        <label for="selectUserType" class="col-sm-2 control-label">Registering As</label>

                                        <div class="col-sm-10">
                                             <asp:DropDownList runat="server" CssClass="form-control" ID="drpUserType">
                                                 <asp:ListItem Value="M" >Medical Practioner</asp:ListItem>
                                                 <asp:ListItem Value="D" >Doctor</asp:ListItem>
                                             </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                </div>
                                <!-- /.box-body -->
                                <div class="box-footer">
                                   <a href="Login.aspx">Sign In</a> <asp:Button Visible="false" runat="server" ID="btnSignin" CssClass="btn btn-default" Text="Sign In" OnClick="btnSignin_Click" />
                                    <asp:Button runat="server" ID="btnSignUp" CssClass="btn btn-info pull-right" Text="Sign Up" OnClick="btnSignUp_Click" />
                                </div>
                                <!-- /.box-footer -->
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </form>
    </div>
</body>
</html>
