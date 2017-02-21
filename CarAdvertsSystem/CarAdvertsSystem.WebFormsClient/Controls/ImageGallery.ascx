<%@ Control Language="C#"
     AutoEventWireup="false"
     CodeBehind="ImageGallery.ascx.cs"
     Inherits="CarAdvertsSystem.WebFormsClient.Controls.ImageGallery" %>

<div class="imagegallery">
  <asp:Literal ID="top" runat="server" />
  <asp:Repeater runat="server" ID="dlPictures">
	  <HeaderTemplate>
	    <ul>
		</HeaderTemplate>
    <ItemTemplate>
      <li><%# Container.DataItem %></li>
    </ItemTemplate>
		<FooterTemplate>
	  </ul>
		</FooterTemplate>
  </asp:Repeater>
	<div class="cleared"> </div>
</div>