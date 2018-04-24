<%@ Page Title="" Language="C#" MasterPageFile="~/general.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SharedAgenda.Login" %>
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
    <div class="contentCentered">
        <div class="contentHeader">
            <h1 class="loginHeader">Login</h1>
        </div>
        <div class="formular1">
            <asp:Label runat="server" Text="Username:" CssClass="sansseriflabel"></asp:Label>
            <asp:Label runat="server" Text="Password:" CssClass="sansseriflabel"></asp:Label>
        </div>
        <div class="formular2">
            <asp:TextBox runat="server" ID="usernameBox" CssClass="formularTextBox"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="FieldValidator1" ControlToValidate="usernameBox" ValidationGroup="ValidLogin">
            </asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="passwordBox" EnableViewState="false" TextMode="Password" CssClass="formularTextBox"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="FieldValidator2" ControlToValidate="passwordBox" ValidationGroup="ValidLogin">
            </asp:RequiredFieldValidator>
        </div>
        <br />
            <asp:Button runat="server" ID="button1" OnClick="button1_Click" Text="Anmelden" CssClass="floatRightButton" 
                CausesValidation="true" ValidationGroup="ValidLogin" ValidateRequestMode="Enabled" />
        <br />
        <div class="clear">
            <asp:Label ID="lblmsgM" runat="server"></asp:Label>
        </div>
        </div>
    </div>
</asp:Content>
