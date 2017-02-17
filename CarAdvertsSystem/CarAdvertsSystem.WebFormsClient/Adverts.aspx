<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Adverts.aspx.cs"
    Inherits="CarAdvertsSystem.WebFormsClient.Adverts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:Repeater runat="server" ID="ReapeaterAdverts" ItemType="CarAdvertsSystem.Data.Models.Advert" SelectMethod="Reapeater_GetData">
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
    </asp:Repeater>--%>
    <asp:ListView ID="ListViewAdverts" runat="server" SelectMethod="Reapeater_GetData"
            ItemType="CarAdvertsSystem.Data.Models.Advert" >
            <LayoutTemplate>
                <h3>Adverts</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <div>
                    <h4><%#: Item.Title %></h4>
                    Price: <%#: String.Format("{0:c}", Item.Price) %>
                </div>
            </ItemTemplate>
        </asp:ListView>

        <asp:DataPager ID="DataPagerAdverts" runat="server"
            PagedControlID="ListViewAdverts" PageSize="1"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>

    <div>
        <a href="/default">Back to search</a>
    </div>
</asp:Content>
