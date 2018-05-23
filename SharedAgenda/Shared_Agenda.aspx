<%@ Page Title="Shared Agenda" Language="C#" MasterPageFile="~/general.Master" AutoEventWireup="true" CodeBehind="Shared_Agenda.aspx.cs" Inherits="SharedAgenda.Shared_Agenda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="mainScriptManager"></asp:ScriptManager>
    <div id="superContainer">
    <div class="filter_container">
        <div id="name" class="name">
            <p class="sansseriflabel">Wilkommen,</p>
            <asp:Label runat="server" CssClass="surname sansseriflabel inlineParagraph" ID="firstname" Text="Vorname"></asp:Label>
            <asp:Label runat="server" CssClass="firstname sansseriflabel inlineParagraph" ID="surname" Text="Nachname"></asp:Label>
        </div>
            <div id="eventContainer">
                <p class="sansseriflabel">Board:</p>
                <div id="eventFlexContainer">
                    <asp:DropDownList runat="server" CssClass="class_list generalInputBox" ID="class_list">
                        
                    </asp:DropDownList>
                <asp:LinkButton runat="server" id="newEventButton" CssClass="new_event_button generalButton" OnClick="New_Event_Click"><i class="glyphicon glyphicon-duplicate"></i><span> Neuer Event</span></asp:LinkButton>
                </div>
            </div>
            <div id="weekContainer">
                <p class="sansseriflabel">Angezeigte Woche:</p>
                <asp:ListBox runat="server" CssClass="week_selection generalInputBox" ID="week_selection" OnSelectedIndexChanged="week_selection_SelectedIndexChanged"></asp:ListBox>
                <div class="date_mobile">
                    <div class="week">
                        <asp:Label runat="server" CssClass="week_label sansseriflabel" Text="Woche:"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="week_dp generalInputBox"></asp:DropDownList>
                    </div>
                    <div class="day">
                        <asp:Label runat="server" CssClass="day_label sansseriflabel" Text="Tag:"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="day_dp generalInputBox"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="eventfilterContainer">
                <p class="sansseriflabel">Eventtyp:</p>
                <div class="eventtype generalInputBox" id="eventtype">
                    <asp:CheckBoxList runat="server" CssClass="events" ID="events">
                        
                    </asp:CheckBoxList>
                </div>
                <asp:Button runat="server" CssClass="eventtype_button generalButton" ID="eventtype_button" Text="Event filtern" />
            </div>
        <div id="log_out" class="log_out">
            <asp:LinkButton runat="server" CssClass="log_out_button generalButton" ID="log_out_button" OnClick="log_out_button_Click"><i class="glyphicon glyphicon-log-out"></i><span> Abmelden</span></asp:LinkButton>
        </div>
        </div>
        
        <div id="time_table" class="time_table generalInputBox">
                <div class="containerDay" id="Monday">
                <div class="containerDayLabel">
                    <h3 class="dayLabel">Montag</h3>
                </div>
            </div>
            <div class="containerDay" id="Tuesday">
                <div class="containerDayLabel">
                    <h3 class="dayLabel">Dienstag</h3>
                </div>
            </div>
            <div class="containerDay" id="Wednesday">
                <div class="containerDayLabel">
                    <h3 class="dayLabel">Mittwoch</h3>
                </div>
            </div>
            <div class="containerDay" id="Thursday">
                <div class="containerDayLabel">
                    <h3 class="dayLabel">Donnerstag</h3>
                </div>
            </div>
            <div class="containerDay" id="Friday">
                <div class="containerDayLabel">
                    <h3 class="dayLabel">Freitag</h3>
                </div>
            </div>
            <div class="containerDay greyedOut" id="Saturday">
                <div class="containerDayLabel">
                    <h3 class="dayLabel">Samstag</h3>
                </div>
            </div>
            <div class="containerDay greyedOut" id="Sunday">
                <div class="containerDayLabel">
                    <h3 class="dayLabel">Sonntag</h3>
                </div>
            </div>
        </div>
        <ajaxToolkit:ModalPopupExtender ID="popupExtender" runat="server" TargetControlID="newEventButton"
            PopupControlID="containerPopup" DropShadow="true" BackgroundCssClass="popupBackground" ></ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" ID="containerPopup" > 
            <iframe width="400" height="700" src="NewEvent.aspx">

            </iframe>
            <asp:LinkButton runat="server"><i class="glyphicon glyphicon-sunglasses"></i><span>Erstellen</span></asp:LinkButton>
        </asp:Panel>
    </div>
</asp:Content>
