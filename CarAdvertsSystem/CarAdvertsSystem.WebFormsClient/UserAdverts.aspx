<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="UserAdverts.aspx.cs"
    Inherits="CarAdvertsSystem.WebFormsClient.UserAdverts" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="UserAdvertsList" runat="server" ItemType="CarAdvertsSystem.Data.Models.Advert">
        <ItemTemplate>
            <div class="jumbotron">
                <div><%#: Item.Title %></div>
                <div><%#: Item.VehicleModel.Name %></div>
                <div><%#: Item.VehicleModel.Manufacturer.Name %></div>
                <div><%#: Item.City.Name  %></div>
                <div><%#: Item.Price %></div>
                <div><%#: Item.Power %></div>
                <div><%#: Item.DistanceCoverage %></div>
                <div><%#: Item.Description %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
