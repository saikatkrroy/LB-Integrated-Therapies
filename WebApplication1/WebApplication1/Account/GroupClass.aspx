<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GroupClass.aspx.cs" Inherits="WebApplication1.Account.GroupClass" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Register for a Session</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" ID="Label1" AssociatedControlID="SessionDate" CssClass="col-md-2 control-label">Session Date</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="SessionDate" runat="server">
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
</asp:Content>
