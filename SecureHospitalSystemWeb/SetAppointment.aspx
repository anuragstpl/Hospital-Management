<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="SetAppointment.aspx.cs" Inherits="DoctorAppointmentWeb.SetAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/jquery-ui.min.css" rel="stylesheet" />
    <link href="plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" />
        <link href="Content/jquery.qtip.min.css" rel="stylesheet" />
    <style type='text/css'>
        /*body {
            margin-top: 40px;
            text-align: center;
            font-size: 14px;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
        }*/

        #calendar {
            width: 1000px;
            margin-left: 300px;

        }
        /* css for timepicker */
        .ui-timepicker-div dl {
            text-align: left;
        }

            .ui-timepicker-div dl dt {
                height: 25px;
            }

            .ui-timepicker-div dl dd {
                margin: -25px 0 10px 65px;
            }

        .style1 {
            width: 100%;
        }

        /* table fields alignment*/
        .alignRight {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
        }

        .alignLeft {
            text-align: left;
            padding-bottom: 10px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="calendar" >
    </div>
    <div id="updatedialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px; display: none;"
        title="Update or Delete Event">
        <table class="style1">
            <tr>
                <td class="alignRight">Name:</td>
                <td class="alignLeft">
                    <input id="eventName" type="text" size="33" /><br />
                </td>
            </tr>
            <tr>
                <td class="alignRight">Description:</td>
                <td class="alignLeft">
                    <textarea id="eventDesc" cols="30" rows="3"></textarea></td>
            </tr>
            <tr>
                <td class="alignRight">Start:</td>
                <td class="alignLeft">
                    <span id="eventStart"></span></td>
            </tr>
            <tr>
                <td class="alignRight">End: </td>
                <td class="alignLeft">
                    <span id="eventEnd"></span>
                    <input type="hidden" id="eventId" /></td>
            </tr>
        </table>
    </div>
    <div id="addDialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px;" title="Add Event">
        <table class="style1">
            <tr>
                <td class="alignRight">Name:</td>
                <td class="alignLeft">
                    <input id="addEventName" type="text" size="33" /><br />
                </td>
            </tr>
            <tr>
                <td class="alignRight">Description:</td>
                <td class="alignLeft">
                    <textarea id="addEventDesc" cols="30" rows="3"></textarea></td>
            </tr>
            <tr>
                <td class="alignRight">Start:</td>
                <td class="alignLeft">
                    <span id="addEventStartDate"></span></td>
            </tr>
            <tr>
                <td class="alignRight">End:</td>
                <td class="alignLeft">
                    <span id="addEventEndDate"></span></td>
            </tr>
        </table>

    </div>
    <div runat="server" id="jsonDiv" />
    <input type="hidden" id="hdClient" runat="server" />
    <script src="plugins/daterangepicker/moment.min.js"></script>
    <script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <script src="plugins/jQueryUI/jquery-ui.min.js"></script>
    <script src="Scripts/fullcalendar/jquery.qtip.min.js"></script>
    <script src="Scripts/fullcalendar/fullcalendar.js"></script>
    <%--<script src="Scripts/fullcalendar/fullcalendar.min.js"></script>--%>
    <script src="Scripts/calendarscript.js"></script>
</asp:Content>
