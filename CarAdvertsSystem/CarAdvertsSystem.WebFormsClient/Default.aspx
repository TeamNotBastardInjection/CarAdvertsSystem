<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarAdvertsSystem.WebFormsClient.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Searh Form For Vehcikle</h1>
    <br />

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label Text="Category" runat="server" AssociatedControlID="CategoriesList" />
            <asp:DropDownList ID="CategoriesList" runat="server"
                DataTextField="Name" DataValueField="Id" AutoPostBack="true"
                OnSelectedIndexChanged="CategoriesList_SelectedIndexChanged">
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label Text="Manufacturer:" runat="server" AssociatedControlID="ManufacturersList" />
            <asp:DropDownList ID="ManufacturersList" runat="server" TabIndex="0"
                DataTextField="Name" DataValueField="Id" AutoPostBack="true"
                OnSelectedIndexChanged="ManufacturersList_SelectedIndexChanged">
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
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ManufacturersList" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:Label Text="Min Price:" runat="server" AssociatedControlID="MinPrice" />
    <asp:TextBox ID="MinPrice" runat="server" />

    <asp:Label Text="Max Price:" runat="server" AssociatedControlID="MaxPrice" />
    <asp:TextBox ID="MaxPrice" runat="server" />
    <br />

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label Text="Year from:" runat="server" AssociatedControlID="YearFrom" />
            <asp:DropDownList ID="YearFrom" runat="server" AutoPostBack="true" OnSelectedIndexChanged="YearFrom_SelectedIndexChanged">
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label Text="to:" runat="server" AssociatedControlID="YearTo" />
            <asp:DropDownList ID="YearTo" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="YearFrom" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <br />

    <asp:Button ID="Search" Text="Search" runat="server" OnClick="Search_Click" />

    <asp:DropDownList ID="ResultAdverts" runat="server" Visible="false">
    </asp:DropDownList>

</asp:Content>
