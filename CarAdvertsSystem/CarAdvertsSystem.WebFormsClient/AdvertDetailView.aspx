﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="AdvertDetailView.aspx.cs" 
    Inherits="CarAdvertsSystem.WebFormsClient.AdvertDetailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="AdvertDetailsView" AutoGenerateRows="false" ItemType="CarAdvertsSystem.Data.Models.Advert">
        <ItemTemplate>
            <div class="jumbotron">
                <p><h2>Advert Title: </h2><%#: Item.Title %></p>
                <p><h2>Model: </h2><%#: Item.VehicleModel.Name %></p>
                <p><h2>Manufacturer: </h2><%#: Item.VehicleModel.Manufacturer.Name %></p>
                <p><h2>City: </h2><%#: Item.City.Name %></p>
                <p><h2>Price: </h2><%#: Item.Price %></p>
                <p><h2>Horse Power: </h2><%#: Item.Power %></p>
                <p><h2>Distance Coverage: </h2><%#: Item.DistanceCoverage %></p>
                <p><h2>Description: </h2><%#: Item.Description %></p>
                <asp:Repeater runat="server" ID="RepeaterImages" ItemType="CarAdvertsSystem.Data.Models.Picture">
                    <ItemTemplate>
                        <asp:Image runat="server" ID="Image" ImageUrl=""/>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
