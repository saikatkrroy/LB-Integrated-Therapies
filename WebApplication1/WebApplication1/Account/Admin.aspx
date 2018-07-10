<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Account.Admin" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
      
        <hr />
        <div class="form-group">
                    <div class="col-md-10">
                        <asp:GridView ID="GridView1" runat="server">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>      
        </div>        
</asp:Content>
