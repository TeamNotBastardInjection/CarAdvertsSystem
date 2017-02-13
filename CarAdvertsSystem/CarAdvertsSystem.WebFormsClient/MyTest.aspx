<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyTest.aspx.cs" Inherits="CarAdvertsSystem.WebFormsClient.MyTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Advert Form</h1>
    <asp:TextBox runat="server" ID="AdvertTitle" />

    <asp:Button Text="Create" runat="server" ID="CreateAdvert"  OnClick="CreateAdvert_Click"/>



</asp:Content>
