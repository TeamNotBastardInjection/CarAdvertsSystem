﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdvertCreator.aspx.cs" Inherits="CarAdvertsSystem.WebFormsClient.AdvertCreator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="search-title">
        <h1>Create an Advert</h1>
    </div>
    <div class="jumbotron">
    <asp:Label Text="Title: " runat="server" AssociatedControlID="AdvertTitle"/>
    <asp:TextBox runat="server" ID="AdvertTitle" TextMode="MultiLine"/>
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldAdvertTitleValidator"
            ForeColor="red" Display="Dynamic"
            ErrorMessage="Title must be between 3 and 30 Symbols Long"
            ControlToValidate="AdvertTitle"
            ValidationGroup="Validation"
            SetFocusOnError="True"/>
    <br />
    <asp:Label Text="City: " runat="server" AssociatedControlID="City" />
    <asp:DropDownList runat="server" ID="City"
        DataTextField="Name" DataValueField="Id">
    </asp:DropDownList>
    <br />
    <asp:Label Text="Category: " runat="server" AssociatedControlID="Category" />
    <asp:DropDownList runat="server" ID="Category"
        DataTextField="Name" DataValueField="Id" AutoPostBack="true"
        OnSelectedIndexChanged="Category_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label Text="Manufacturer: " runat="server" AssociatedControlID="Manufacturer" />
            <asp:DropDownList runat="server" ID="Manufacturer" AutoPostBack="true" OnSelectedIndexChanged="Manufacturer_SelectedIndexChanged"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Category" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Label Text="Vehicle Model: " runat="server" AssociatedControlID="VehicleModel" />
            <asp:DropDownList runat="server" ID="VehicleModel"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList>
            <asp:Literal runat="server" ID="VehicleModelValidator" Visible="False"></asp:Literal>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Manufacturer" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <asp:Label Text="Year: " runat="server" AssociatedControlID="Year" />
    <asp:DropDownList ID="Year" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label Text="Price: " runat="server" AssociatedControlID="Price" />
    <asp:TextBox runat="server" ID="Price"  TextMode="Number"/>
        <asp:RangeValidator runat="server"
            ID="RangeValidatorPrice"
            Type="Integer"
            MinimumValue="0"
            MaximumValue="10000000"
            ForeColor="Red"
            ErrorMessage="Price must be a Valid Positive Number!!!"
            ControlToValidate="Price"
            ValidationGroup="Validation"
            SetFocusOnError="True"/>
    <br />
    <asp:Label Text="Power: " runat="server" AssociatedControlID="Power" />
    <asp:TextBox runat="server" ID="Power" TextMode="Number" />
        <asp:RangeValidator runat="server"
            ID="RangeValidatorPower"
            Type="Integer"
            MinimumValue="0"
            MaximumValue="6000"
            ForeColor="Red"
            ErrorMessage="Power must be a Valid Positive Number!!!"
            ControlToValidate="Power"
            ValidationGroup="Validation"
            SetFocusOnError="True"/>
    <br />

    <asp:Label Text="Distance Coverage: " runat="server" AssociatedControlID="DistanceCovarage" />
    <asp:TextBox runat="server" ID="DistanceCovarage" TextMode="Number" />
        <asp:RangeValidator runat="server"
            ID="RangeValidatorDistanceCoverage"
            Type="Integer"
            MinimumValue="0"
            MaximumValue="1000000"
            ForeColor="Red"
            ErrorMessage="Distance Coverage must be a Valid Positive Number!!!"
            ControlToValidate="DistanceCovarage"
            ValidationGroup="Validation"
            SetFocusOnError="True"/>
    <br />
    <asp:Label Text="Description: " runat="server" AssociatedControlID="Description" />
    <asp:TextBox runat="server" ID="Description" TextMode="MultiLine" />
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldDescriptionValidator"
            ForeColor="red" Display="Dynamic"
            ErrorMessage="Description must be up to 500 symbols!"
            ControlToValidate="Description"
            ValidationGroup="Validation"
            SetFocusOnError="True"/>
    <br />
        
        <asp:Label ID="ListOfPictures" runat="server" Visible="False" />
        <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="true" />

    <asp:Button Text="Create" runat="server" ID="CreateAdvert" CssClass="btn" OnClick="CreateAdvert_Click" ValidationGroup="Validation"/>
    </div>
</asp:Content>
