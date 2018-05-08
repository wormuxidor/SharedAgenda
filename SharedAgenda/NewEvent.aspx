<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEvent.aspx.cs" Inherits="SharedAgenda.NewEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="styles/stylesEvent.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Neuer Event</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Event">
        <asp:Label runat="server" CssClass="Text_Event" Text="Fach"></asp:Label><br />
        <asp:DropDownList runat="server" CssClass="subject_db"></asp:DropDownList><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Datum"></asp:Label><br />
        <asp:Calendar runat="server" CssClass="calender"></asp:Calendar><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Kurzbeschreibung"></asp:Label><br />
        <asp:TextBox runat="server" CssClass="tb_kBeschreibung"></asp:TextBox><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Eventtype"></asp:Label><br />
        <asp:RadioButtonList runat="server" CssClass="rb_eventtype"></asp:RadioButtonList><br />
        <asp:Label runat="server" CssClass="Text_Event" Text="Beschreibung"></asp:Label><br />
        <asp:TextBox runat="server" CssClass="tb_Beschreibung"></asp:TextBox><br />
        <asp:Button runat="server" CssClass="submit_btn" ID="submit_btn" Text="Hinzufügen" OnClick="submit_btn_Click" />
        <asp:Button runat="server" CssClass="cancel_btn" ID="cancel_btn" Text="Abbrechen" OnClick="cancel_btn_Click" />

    </div>
    </form>
</body>
</html>
