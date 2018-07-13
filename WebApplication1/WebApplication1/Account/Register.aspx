<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Register for a Session</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ContactNumber" CssClass="col-md-2 control-label">Contact Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ContactNumber" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ContactNumber"
                    CssClass="text-danger" ErrorMessage="The contact number field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email address field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SessionDate" CssClass="col-md-2 control-label">Date</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="SessionDate" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
                    <DayStyle BorderStyle="None" />
                </asp:Calendar>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The Session Date field is required." /><br/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="Time" AssociatedControlID="SessionTime" CssClass="col-md-2 control-label">Time</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="SessionTime" runat="server" OnSelectedIndexChanged="SessionTime_SelectedIndexChanged">
                    <asp:ListItem>7:00</asp:ListItem>
                    <asp:ListItem>8:00</asp:ListItem>
                    <asp:ListItem>9:00</asp:ListItem>
                    <asp:ListItem>10:00</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="SessionTime"
                    CssClass="text-danger" ErrorMessage="The Session Time field is required." /><br/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="Label2" AssociatedControlID="Duration" CssClass="col-md-2 control-label">Duration(Minutes)</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Duration" runat="server">
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>60</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Duration"
                    CssClass="text-danger" ErrorMessage="The Duration field is required." /><br/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="Loc" AssociatedControlID="Location" CssClass="col-md-2 control-label">Location</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Location" runat="server">
                    <asp:ListItem>Dockland</asp:ListItem>
                    <asp:ListItem>Melbourne CBD</asp:ListItem>
                    <asp:ListItem>South Yarra</asp:ListItem>
                    <asp:ListItem>Abbotsford</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Location"
                    CssClass="text-danger" ErrorMessage="The Location field is required." /><br/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

</asp:Content>
