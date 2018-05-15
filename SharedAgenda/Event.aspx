<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="SharedAgenda.Event" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="styles/stylesEvent.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Event</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Event">
        <asp:Label runat="server" CssClass="Text_Event" Text="Fach"></asp:Label><br />
        <asp:Label runat="server" CssClass="subject_txt" Text="subject"></asp:Label><br /><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Datum"></asp:Label><br />
        <asp:Label runat="server" CssClass="calender_txt" Text="date"></asp:Label><br /><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Kurzbeschreibung"></asp:Label><br />
        <asp:Label runat="server" CssClass="kBeschreibung_txt" Text="kBeschreibung"></asp:Label><br /><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Eventtype"></asp:Label><br />
        <asp:RadioButtonList runat="server" CssClass="rb_eventtype_txt" Enabled="false" ID="rb_eventtype"></asp:RadioButtonList><br /><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Beschreibung"></asp:Label><br />
        <asp:TextBox runat="server" CssClass="tb_Beschreibung_txt" Enabled="false" ID="tb_Beschreibung"></asp:TextBox><br /><br />
        <asp:Button runat="server" CssClass="edit_btn" ID="edit_btn" Text="Bearbeiten" OnClick="edit_btn_Click" />
        <asp:Button runat="server" CssClass="delete_btn" ID="delete_btn" Text="Löschen" OnClick="delete_btn_Click" />
        <asp:Button runat="server" CssClass="cancel_btn" ID="cancel_btn" Text="Abbrechen" OnClick="cancel_btn_Click" />
    </div>
    </form>
</body>
</html>
