﻿<%@ Page Title="" Language="C#" MasterPageFile="~/general.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SharedAgenda.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    onload=function(){
    var e=document.getElementById("refreshed");
    if(e.value=="no")e.value="yes";
    else{e.value="no";location.reload();}
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="refreshed" value="no" >
    <div class="contentWhole">
        <div id="loginEntryBorder">
            <div id="contentHeaderContainer">
                <div class="contentHeader">
                <h1 class="loginHeader">Login</h1>
                </div>
            </div>
        <div id="loginRowsContainer">
        <div id="loginRow1" class="loginRow">
            <div id="loginRow1Label" class="loginLabel loginRowElementInline">
                <asp:Label runat="server" Text="Email:"></asp:Label>
            </div>
            <div id="loginRow1Box" class="loginRowElementInline">
                <asp:TextBox runat="server" ID="emailBox" CssClass="loginTextBox"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="FieldValidator1" ControlToValidate="emailBox" ValidationGroup="ValidLogin">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div id="loginRow2" class="loginRow">
            <div id="loginRow2Label" class="loginLabel loginRowElementInline">
                <asp:Label runat="server" Text="Password:"></asp:Label>
            </div>
            <div id="loginRow2Box" class="loginRowElementInline">
                <asp:TextBox runat="server" ID="passwordBox" EnableViewState="false" TextMode="Password" CssClass="loginTextBox"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="FieldValidator2" ControlToValidate="passwordBox" ValidationGroup="ValidLogin">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div id="loginRow3" class="loginRow">
            <div id="loginRow3Label" class="loginLabel loginRowElementInline">
            </div>
            <div id="loginRow2Button" class="loginRowElementInline">
                <asp:Button runat="server" ID="loginButton" OnClick="loginButton_Click" Text="Anmelden" CssClass="loginButton" 
                CausesValidation="true" ValidationGroup="ValidLogin" ValidateRequestMode="Enabled" />
            </div>
        </div>
        </div>
        </div>
    </div>
</asp:Content>
