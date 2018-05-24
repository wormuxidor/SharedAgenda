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
                    <asp:DropDownList runat="server" CssClass="class_list generalInputBox" ID="class_list" 
                        OnSelectedIndexChanged="Board_selection_SelectedIndexChanged"
                        AutoPostBack="true"></asp:DropDownList>

                    <asp:LinkButton runat="server" id="newEventButton" CssClass="generalButton newEventButton"><i class="glyphicon glyphicon-duplicate"></i><span> Neuer Event</span></asp:LinkButton>
                    <asp:LinkButton runat="server" id="newEventButtonMobile" CssClass="generalButton newEventButtonMobile" OnClick="New_Event_Click"><i class="glyphicon glyphicon-duplicate"></i></asp:LinkButton>
                    <asp:LinkButton runat="server" id="eventtype_button" CssClass="eventtype_button generalButton" ><i class="glyphicon glyphicon-filter"></i></asp:LinkButton>
                </div>
            </div>
            <div id="weekContainer">
                <p class="sansseriflabel mobileDisplayNone">Angezeigte Woche:</p>
                <asp:ListBox runat="server" CssClass="week_selection generalInputBox" ID="week_selection" OnSelectedIndexChanged="week_selection_SelectedIndexChanged">
                    <asp:ListItem  Text="21 2018" Selected="True"></asp:ListItem>
                </asp:ListBox>
                <div class="date_mobile">
                    <div class="week">
                        <asp:Label runat="server" CssClass="week_label sansseriflabel" Text="Woche:">
                        </asp:Label>
                        <asp:DropDownList runat="server" CssClass="week_dp generalInputBox">
                            <asp:ListItem Text="21" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="day">
                        <asp:Label runat="server" CssClass="day_label sansseriflabel" Text="Tag:"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="day_dp generalInputBox">
                            <asp:ListItem Text="5" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="eventfilterContainer">
                <p class="sansseriflabel mobileDisplayNone">Eventtyp:</p>
                <div class="eventtype generalInputBox" id="eventtype">
                    <asp:CheckBoxList runat="server" CssClass="events" ID="events">
                        
                    </asp:CheckBoxList>
                </div>
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
            PopupControlID="containerPopup" DropShadow="false" BackgroundCssClass="popupBackground" 
            CancelControlID="cancel_btn" OkControlID="submit_btn" ></ajaxToolkit:ModalPopupExtender>
        <asp:Panel runat="server" ID="containerPopup" CssClass="popupPanel" > 
            <div class="popupDiv">
                <div class="popupTitleContainer">
                        <h1 class="popupTitle">Neuen Event erstellen</h1>
                </div>
                <div class="popupSuperContainer">
                    <div class="popupColumn1">
                        <div class="popupSubjectContainer">
                            <asp:Label runat="server" CssClass="Text_Event" Text="Fach"></asp:Label>
                            <asp:DropDownList runat="server" ID="subject_db" CssClass="subject_db generalInputBox"></asp:DropDownList>
                        </div>
                         <div class="popupCalenderContainer">
                            <asp:Label runat="server" CssClass="Text_Event" Text="Datum"></asp:Label>
                            <asp:Calendar runat="server" id="calender" CssClass="calender generalInputBox" OnSelectionChanged="calender_SelectionChanged"></asp:Calendar>
                        </div>
                    </div>
                        <div class="popupColumn2">
                            <div class="popupNewEventTitle">
                            <asp:Label runat="server" CssClass="Text_Event" Text="Eventtitel"></asp:Label>
                            <asp:TextBox runat="server" ID="tb_kBeschreibung" CssClass="tb_kBeschreibung generalInputBox"></asp:TextBox>
                        </div>
                        <div class="popupNewEventType">
                            <asp:Label runat="server" CssClass="Text_Event" Text="Eventtyp"></asp:Label>
                            <asp:RadioButtonList runat="server" ID="rb_eventtype" CssClass="rb_eventtype generalInputBox"></asp:RadioButtonList>
                        </div>
                        <div class="popupNewEventDescription">
                            <asp:Label runat="server" CssClass="Text_Event" Text="Beschreibung"></asp:Label><br />
                            <asp:TextBox runat="server" ID="tb_Beschreibung" CssClass="tb_Beschreibung generalInputBox"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="popupButtonContainer">
                        <asp:LinkButton runat="server" CssClass="submit_btn generalButton" ID="submit_btn" OnClick="submit_btn_Click" ><i class="glyphicon glyphicon-ok-circle"></i><span> Hinzufügen</span></asp:LinkButton>
                        <asp:LinkButton runat="server" CssClass="cancel_btn generalButton" ID="cancel_btn"><i class="glyphicon glyphicon-ban-circle"></i><span> Abbrechen</span></asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
