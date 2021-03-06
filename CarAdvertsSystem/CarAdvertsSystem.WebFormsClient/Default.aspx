﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarAdvertsSystem.WebFormsClient.Default" %>
<%--<%@ OutputCache Duration="60" VaryByParam="none" %>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="search-title">
        <h1>Search For And Advert</h1>
    </div>

    <div class="jumbotron search">
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label Text="Category" runat="server" AssociatedControlID="CategoriesList" />
                <asp:DropDownList ID="CategoriesList" runat="server"
                    DataTextField="Name" DataValueField="Id" AutoPostBack="true"
                    OnSelectedIndexChanged="CategoriesList_SelectedIndexChanged"
                    ValidationGroup="DropDowns"
                    CssClass="dropdown-header">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label Text="Manufacturer:" runat="server" AssociatedControlID="ManufacturersList" />
                <asp:DropDownList ID="ManufacturersList" runat="server" TabIndex="0"
                    DataTextField="Name" DataValueField="Id" AutoPostBack="true"
                    OnSelectedIndexChanged="ManufacturersList_SelectedIndexChanged"
                    ValidationGroup="DropDowns"
                    CssClass="dropdown-header">
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="CategoriesList" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <br />

        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label Text="Model:" runat="server" AssociatedControlID="ModelsList" />
                <asp:DropDownList ID="ModelsList" runat="server"
                    DataTextField="Name" DataValueField="Id" CssClass="dropdown-header">
                </asp:DropDownList>
                <asp:Label runat="server" ID="ModelListValidator" Visible="False"/>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ManufacturersList" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <br />

        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label runat="server" Text="City: " AssociatedControlID="CitiesList" />
                <asp:DropDownList runat="server" ID="CitiesList" DataTextField="Name" DataValueField="Id" CssClass="dropdown-header" />
                <asp:Label runat="server" ID="PriceValidator" Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Label Text="Min Price:" ID="MinPriceLabel" runat="server" AssociatedControlID="MinPrice" />
        <asp:TextBox ID="MinPrice" runat="server" />
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldValidator1"
            ForeColor="Red" Display="Dynamic"
            ErrorMessage="Maximum Price is Required!!!"
            ControlToValidate="MinPrice"
            SetFocusOnError="True" />
        <br />
        <asp:Label Text="Max Price:" runat="server" AssociatedControlID="MaxPrice" />
        <asp:TextBox ID="MaxPrice" runat="server" />
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldValidatorMaxPriceInput"
            ForeColor="Red" Display="Dynamic"
            ErrorMessage="Minimum Price is Required!!!"
            ControlToValidate="MaxPrice" 
            SetFocusOnError="True"/>
        <br />

        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label Text="Year from:" runat="server" AssociatedControlID="YearFrom" />
                <asp:DropDownList ID="YearFrom" runat="server" AutoPostBack="true" OnSelectedIndexChanged="YearFrom_SelectedIndexChanged" CssClass="dropdown-header">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label Text="to:" runat="server" AssociatedControlID="YearTo" />
                <asp:DropDownList ID="YearTo" runat="server" AutoPostBack="true" CssClass="dropdown-header">
                </asp:DropDownList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="YearFrom" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <br />

        <asp:Button ID="Search" Text="Search" runat="server" CssClass="btn" OnClick="Search_Click"/>
    </div>

</asp:Content>
