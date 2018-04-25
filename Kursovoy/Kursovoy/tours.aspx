<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="tours.aspx.cs" Inherits="Kursovoy.tours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fly_to_dubaiConnectionString %>" SelectCommand="SELECT [name_district], [id_district] FROM [District]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:fly_to_dubaiConnectionString %>" SelectCommand="SELECT DISTINCT [id_hotel], [stars] FROM [Hotel]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:fly_to_dubaiConnectionString %>" SelectCommand="SELECT [feeding_type], [id_feeding] FROM [Feeding]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:fly_to_dubaiConnectionString %>" SelectCommand="SELECT [id_airport], [name_airport] FROM [Airport]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:fly_to_dubaiConnectionString %>" SelectCommand="SELECT DISTINCT [departure] FROM [Tour]"></asp:SqlDataSource>
    <asp:Label ID="Label2" runat="server" CssClass="cabinet_link" Text="Район: "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name_district" DataValueField="id_district" style="margin-bottom: 0px" AutoPostBack="True" CssClass="dropdown">
    </asp:DropDownList>
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="🔍" />
    <asp:Label ID="Label3" runat="server" CssClass="cabinet_link" Text="Кол-во звёзд:"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="dropdown">
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button5" runat="server" Text="🔍" OnClick="Button5_Click" Height="25px"/>
    <asp:Label ID="Label4" runat="server" CssClass="cabinet_link" Text="Тип питания:"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="feeding_type" DataValueField="id_feeding" AutoPostBack="True" CssClass="dropdown">
    </asp:DropDownList>
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="🔍" />
    <asp:Label ID="Label5" runat="server" CssClass="cabinet_link" Text="Аэропорт:"></asp:Label>
    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" CssClass="dropdown" DataSourceID="SqlDataSource4" DataTextField="name_airport" DataValueField="id_airport">
    </asp:DropDownList>
    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="🔍" />
   
    <asp:Label ID="Label7" runat="server" CssClass="cabinet_link" Text="Цена: от " Width="68px"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="34px"></asp:TextBox>
&nbsp;до
    <asp:TextBox ID="TextBox2" runat="server" Width="34px"></asp:TextBox>
    &nbsp;<asp:Button ID="Button8" runat="server" Text="🔍" OnClick="Button8_Click1" />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" RowHeaderColumn="id_tour">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id_tour" HeaderText="№" ShowHeader="False" />
            <asp:BoundField DataField="name_hotel" HeaderText="Отель" />
            <asp:BoundField DataField="name_district" HeaderText="Район" />
            <asp:BoundField DataField="stars" HeaderText="Звёзды" />
            <asp:BoundField DataField="feeding_type" HeaderText="Питание" />
            <asp:BoundField DataField="people" HeaderText="Кол-во человек" />
            <asp:BoundField DataField="departure" DataFormatString="&quot;{0:d}&quot;" HeaderText="Вылет" />
            <asp:BoundField DataField="arrival" DataFormatString="&quot;{0:d}&quot;" HeaderText="Прилет" />
            <asp:BoundField DataField="name_airport" HeaderText="Аэропорт" />
            <asp:BoundField DataField="cost" HeaderText="Цена(в $)" />
            <asp:BoundField DataField="how_much_left" HeaderText="Осталось" />
            <asp:ButtonField CommandName="Select" Text="Подробнее" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
      
    </asp:GridView>
    <br />
</asp:Content>
