<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prueba_1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Prueba Técnica.&nbsp;&nbsp; ASP.NET</h1>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="BtnListarUsuarios" runat="server" Text="Listar usuarios" OnClick="Button1_Click" CssClass="info" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="10" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" CellSpacing="8" Height="100%" HorizontalAlign="Left" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" BorderStyle="None" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                
            </asp:GridView>
        </div>
    </div> 
    <div class="row">
        <div class="col-md-12">
            <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" Enabled="False" ReadOnly="True" Width="100%" Wrap="False" Font-Bold="True" ForeColor="#FF6666"></asp:TextBox>
        </div>
    </div>

</asp:Content>
