<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Adverts.aspx.cs"
    Inherits="CarAdvertsSystem.WebFormsClient.Adverts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
    </div>

    <asp:Repeater runat="server" ID="ReapeaterAdverts" ItemType="CarAdvertsSystem.Data.Models.Advert" SelectMethod="Reapeater_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <div><%#: Item.Title %></div>
                <div><%#: Item.Id %></div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <div class="back-link">
        <a href="/default">Back to search</a>
    </div>
</asp:Content>
