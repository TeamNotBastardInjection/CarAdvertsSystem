<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdvertCreator.aspx.cs" Inherits="CarAdvertsSystem.WebFormsClient.AdvertCreator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Advert Form</h1>
    <div class="jumbotron">
    <asp:Label Text="Title: " runat="server" AssociatedControlID="AdvertTitle"/>
    <asp:TextBox runat="server" ID="AdvertTitle" TextMode="MultiLine"/>
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldAdvertTitleValidator"
            ForeColor="red" Display="Dynamic"
            ErrorMessage="Title must be between 3 and 30 Symbols Long"
            ControlToValidate="AdvertTitle"/>
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
            <asp:Label Text="VechisleModel: " runat="server" AssociatedControlID="VechisleModel" />
            <asp:DropDownList runat="server" ID="VechisleModel"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList>
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
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldPriceValidator"
            ForeColor="Red" Display="Dynamic"
            ErrorMessage="You need to enter a Price!!!"
            ControlToValidate="Price"/>
    <br />
    <asp:Label Text="Power: " runat="server" AssociatedControlID="Power" />
    <asp:TextBox runat="server" ID="Power" TextMode="Number" />
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldPowerValidator"
            ForeColor="Red" Display="Dynamic"
            ErrorMessage="Power must be between 10 and 5000 HP!"
            ControlToValidate="Power"/>
    <br />

    <asp:Label Text="Distance Covarage: " runat="server" AssociatedControlID="DistanceCovarage" />
    <asp:TextBox runat="server" ID="DistanceCovarage" TextMode="Number" />
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFielDistanceCoveragedValidator"
            ForeColor="Red" Display="Dynamic"
            ErrorMessage="Distance Coverage must be up to 1million kms!!!"
            ControlToValidate="DistanceCovarage"/>
    <br />
    <asp:Label Text="Description: " runat="server" AssociatedControlID="Description" />
    <asp:TextBox runat="server" ID="Description" TextMode="MultiLine" />
        <asp:RequiredFieldValidator runat="server"
            ID="RequiredFieldDescriptionValidator"
            ForeColor="red" Display="Dynamic"
            ErrorMessage="Description must be up to 500 symbols!"
            ControlToValidate="Description"/>
    <br />
        <div>Upload one or many files.</div>
        <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="true" />
        <asp:Label ID="listofuploadedfiles" runat="server" />

    <asp:Button Text="Create" runat="server" ID="CreateAdvert" OnClick="CreateAdvert_Click" />
    </div>
</asp:Content>
