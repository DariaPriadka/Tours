<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="Kursovoy.booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" CssClass="auth" ForeColor="#333333" GridLines="None" Height="50px" Width="744px">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="name_hotel" HeaderText="Отель" />
            <asp:BoundField DataField="stars" HeaderText="Кол-во звёзд" />
            <asp:BoundField DataField="name_district" HeaderText="Район" />
            <asp:BoundField DataField="people" HeaderText="Кол-во людей" />
            <asp:BoundField DataField="feeding_type" HeaderText="Тип питания" />
            <asp:BoundField DataField="departure" HeaderText="Дата вылета" DataFormatString="&quot;{0:d}&quot;" />
            <asp:BoundField DataField="arrival" HeaderText="Дата прилета" DataFormatString="&quot;{0:d}&quot;" />
            <asp:BoundField DataField="name_airport" HeaderText="Аэропорт" />
            <asp:BoundField DataField="info" HeaderText="О туре" />
            <asp:BoundField DataField="cost" HeaderText="Стоимость (в $)" />
            <asp:BoundField DataField="how_much_left" HeaderText="Осталось" />
            <asp:ImageField DataImageUrlField="image1" HeaderText="Фото">
            </asp:ImageField>
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
</asp:Content>
