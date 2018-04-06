<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="tours.aspx.cs" Inherits="Kursovoy.tours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fly_to_dubaiConnectionString %>" SelectCommand="SELECT * FROM [District]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:fly_to_dubaiConnectionString %>" SelectCommand="SELECT [id_tour], [hotel], [people], [feeding], [departure], [arrival], [airport], [cost], [how_much_left] FROM [Tour]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="auth" DataSourceID="SqlDataSource1" DataTextField="name_disctrict" DataValueField="id_district">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList3" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList4" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList5" runat="server" Height="16px">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList6" runat="server">
    </asp:DropDownList>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_tour" DataSourceID="SqlDataSource2" style="margin-top: 0px">
        <Columns>
            <asp:BoundField DataField="id_tour" HeaderText="Номер" ReadOnly="True" SortExpression="id_tour" />
            <asp:BoundField DataField="hotel" HeaderText="Отель" SortExpression="hotel" />
            <asp:BoundField DataField="people" HeaderText="Кол-во человек" SortExpression="people" />
            <asp:BoundField DataField="feeding" HeaderText="Тип питания" SortExpression="feeding" />
            <asp:BoundField DataField="departure" HeaderText="Вылет" SortExpression="departure" DataFormatString="{0:d}" />
            <asp:BoundField DataField="arrival" HeaderText="Прилет" SortExpression="arrival" DataFormatString="{0:d}" />
            <asp:BoundField DataField="airport" HeaderText="Аэропорт" SortExpression="airport" />
            <asp:BoundField DataField="cost" HeaderText="Цена (в $)" SortExpression="cost" />
            <asp:BoundField DataField="how_much_left" HeaderText="Кол-во туров" SortExpression="how_much_left" />
        </Columns>
    </asp:GridView>
</asp:Content>
