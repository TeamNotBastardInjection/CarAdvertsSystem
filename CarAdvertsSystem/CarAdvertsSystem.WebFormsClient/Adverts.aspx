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
                    <asp:HyperLink NavigateUrl='<%# $"~/advertdetailview.aspx?id={Item.Id}" %>' runat="server" Text="<%#: Item.Title %>" />
                    Price: <%#: $"{Item.Price:c}" %>
                    <%--<asp:Image ImageUrl="~/Uploaded_Files/1.jpg" runat="server" Width="150px"/>--%>
                    <asp:Image ImageUrl="<%#: GetFirstPicturePathByAdvertId(Item.Id) %>" runat="server" Width="150px" />
                </div>
            </ItemTemplate>
        </asp:ListView>

        <asp:DataPager ID="DataPagerAdverts" runat="server"
            PagedControlID="ListViewAdverts" PageSize="2"
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
