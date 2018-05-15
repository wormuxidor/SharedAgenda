<%@ Page Language="C#" MasterPageFile="~/general.Master" AutoEventWireup="true" CodeBehind="NewEvent.aspx.cs" Inherits="SharedAgenda.NewEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Neuer Event</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Event">
        <asp:Label runat="server" CssClass="Text_Event" Text="Fach"></asp:Label><br />
        <asp:DropDownList runat="server" ID="subject_db" CssClass="subject_db generalInputBox"></asp:DropDownList><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Datum"></asp:Label><br />
        <asp:Calendar runat="server" id="calender" CssClass="calender generalInputBox"></asp:Calendar><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Kurzbeschreibung"></asp:Label><br />
        <asp:TextBox runat="server" ID="tb_kBeschreibung" CssClass="tb_kBeschreibung generalInputBox"></asp:TextBox><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Eventtype"></asp:Label><br />
        <asp:RadioButtonList runat="server" ID="rb_eventtype" CssClass="rb_eventtype generalInputBox"></asp:RadioButtonList><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Beschreibung"></asp:Label><br />
        <asp:TextBox runat="server" ID="tb_Beschreibung" CssClass="tb_Beschreibung generalInputBox"></asp:TextBox><br />
        <asp:Button runat="server" CssClass="submit_btn generalButton" ID="submit_btn" Text="Hinzufügen" OnClick="submit_btn_Click" />
        <asp:Button runat="server" CssClass="cancel_btn generalButton" ID="cancel_btn" Text="Abbrechen" OnClick="cancel_btn_Click" />
    </div>
</asp:Content>
