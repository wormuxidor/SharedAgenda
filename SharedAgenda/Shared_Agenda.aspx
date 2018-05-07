<%@ Page Title="Shared Agenda" Language="C#" MasterPageFile="~/general.Master" AutoEventWireup="true" CodeBehind="Shared_Agenda.aspx.cs" Inherits="SharedAgenda.Shared_Agenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="filter_container">
        <div id="name" class="name">
            <p>Wilkommen,</p>
            <asp:Label runat="server" CssClass="surname" ID="surname" Text="Nachname"></asp:Label>
            ,
            <asp:Label runat="server" CssClass="first_name" ID="first_name" Text="Vorname"></asp:Label>
            (
            <asp:Label runat="server" CssClass="user" ID="user" Text="User"></asp:Label>
            )
        </div>
        <div id="settings" class="settings">
            <p>Board:</p>
            <asp:DropDownList runat="server" CssClass="class_list" ID="class_list"></asp:DropDownList>
            <asp:Button runat="server" CssClass="new_event_button" Text="Neuer Event" OnClick="New_Event_Click"/>
            <br />
            <p>Angezeigte Woche:</p>
            <asp:ListBox runat="server" CssClass="week_selection" ID="week_selection" OnSelectedIndexChanged="week_selection_SelectedIndexChanged"></asp:ListBox>
            <div class="date_mobile">
                <div class="week">
                    <asp:Label runat="server" CssClass="week_label" Text="Woche:"></asp:Label>
                    <asp:DropDownList runat="server" CssClass="week_dp"></asp:DropDownList>
                </div>
                <div class="day">
                    <asp:Label runat="server" CssClass="day_label" Text="Tag:"></asp:Label>
                    <asp:DropDownList runat="server" CssClass="day_dp"></asp:DropDownList>
                </div>
            </div>
            <p>Eventtyp:</p>
            <div class="eventtype" id="eventtype">
                <asp:CheckBoxList runat="server" CssClass="events" ID="events"></asp:CheckBoxList>
            </div>
            <asp:Button runat="server" CssClass="eventtype_button" ID="eventtype_button" Text="Event filtern" />
        </div>
        <div id="log_out" class="log_out">
            <asp:Button runat="server" CssClass="log_out_button" ID="log_out_button" Text="Ausloggen" OnClick="log_out_button_Click" />
        </div>
    </div>

    <div id="time_table" class="time_table">

    </div>
</asp:Content>
