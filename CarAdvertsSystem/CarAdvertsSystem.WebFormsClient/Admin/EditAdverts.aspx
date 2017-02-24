<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    ValidateRequest="false"
    AutoEventWireup="true" CodeBehind="EditAdverts.aspx.cs" Inherits="CarAdvertsSystem.WebFormsClient.Admin.EditAdverts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-responsive">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:ListView ID="ListView1" runat="server" ItemType="CarAdvertsSystem.Data.Models.Advert"
                    SelectMethod="ListView1_GetData"
                    DeleteMethod="ListView1_DeleteItem"
                    UpdateMethod="ListView1_UpdateItem"
                    DataKeyNames="Id">
                    <LayoutTemplate>
                        <table class="table table-bordered" id="MainContent_GridViewCategories">
                            <tbody>
                                <tr>
                                    <th scope="col">
                                        <asp:LinkButton Text="Advert Title" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Title" />
                                    </th>
                                    <th scope="col">
                                        <asp:LinkButton Text="Model" runat="server" ID="LinkButton1" CommandName="Sort" CommandArgument="VehicleModel.Name" />
                                    </th>
                                    <th scope="col">
                                        <asp:LinkButton Text="Manufacturer" runat="server" ID="LinkButton2" CommandName="Sort" CommandArgument="VehicleModel.Manufacturer.Name" />
                                    </th>
                                    <th scope="col">
                                        <asp:LinkButton Text="City" runat="server" ID="LinkButton3" CommandName="Sort" CommandArgument="City.Name" />
                                    </th>
                                    <th scope="col">
                                        <asp:LinkButton Text="Price" runat="server" ID="LinkButton4" CommandName="Sort" CommandArgument="Price" />
                                    </th>
                                    <th scope="col">
                                        <asp:LinkButton Text="Horse Power" runat="server" ID="LinkButton5" CommandName="Sort" CommandArgument="Power" />
                                    </th>
                                    <th scope="col">
                                        <asp:LinkButton Text="Distance Coverage" runat="server" ID="LinkButton6" CommandName="Sort" CommandArgument="DistanceCoverage" />
                                    </th>
                                    <th scope="col">
                                        <asp:LinkButton Text="Description" runat="server" ID="LinkButton7" CommandName="Sort" CommandArgument="Description" />
                                    </th>
                                </tr>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                                <tr>
                                    <td colspan="2">
                                        <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="5">
                                            <Fields>
                                                <asp:NumericPagerField />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.Title %></td>
                            <td><%#: Item.VehicleModel.Name %></td>
                            <td><%#: Item.VehicleModel.Manufacturer.Name %></td>
                            <td><%#: Item.City.Name %></td>
                            <td><%#: Item.Price %></td>
                            <td><%#: Item.Power %></td>
                            <td><%#: Item.DistanceCoverage %></td>
                            <td><%#: Item.Description %></td>
                            <td>
                                <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" />
                                <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Title %>" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" Enabled="False" ID="TextBox5" Text="<%#: BindItem.VehicleModel.Name %>" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" Enabled="False" ID="TextBox6" Text="<%#: BindItem.VehicleModel.Manufacturer.Name %>" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" Enabled="False" ID="TextBox7" Text="<%#: BindItem.City.Name %>" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="TextBox1" Width="70px" Text="<%#: BindItem.Price %>" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="TextBox2" Width="70px" Text="<%#: BindItem.Power %>" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="TextBox3" Width="70px"  Text="<%#: BindItem.DistanceCoverage %>" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="TextBox4" Text="<%#: BindItem.Description %>" TextMode="MultiLine" />
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                                <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                            </td>
                        </tr>
                    </EditItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
