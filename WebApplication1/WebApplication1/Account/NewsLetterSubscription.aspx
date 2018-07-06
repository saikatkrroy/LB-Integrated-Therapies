<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsLetterSubscription.aspx.cs" Inherits="WebApplication1.Account.NewsLetterSubscription" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
      
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
            <asp:Label runat="server" AssociatedControlID="EmailID" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="EmailID" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailID"
                    CssClass="text-danger" ErrorMessage="The Email Address field is required." />
            </div>
        </div>
       
        <div class="form-group">
            
                <asp:Button ID="Subscribe" runat="server" Text="Subscribe" OnClick="Search_Click" />
           
        </div>
           
    </div>
</asp:Content>