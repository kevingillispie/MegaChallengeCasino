<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageMap ID="reelsImageMap1" runat="server" Height="150px">
            </asp:ImageMap>
            <asp:ImageMap ID="reelsImageMap2" runat="server" Height="150px">
            </asp:ImageMap>
            <asp:ImageMap ID="reelsImageMap3" runat="server" Height="150px">
            </asp:ImageMap>
            <br />
            <br />
            Your bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" Text="Pull the Lever!" OnClick="leverButton_Click" />
            <br />
            <br />
            <asp:Label ID="winOrLoseLabel" runat="server"></asp:Label>
            <br />
            <br />
            Player&#39;s Money: $
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - 2x Your Bet<br />
            2 Cherries - 3x Your Bet<br />
            3 Cherries - 4x Your Bet<br />
            <br />
            3 7s - JACKPOT! - 100x Your Bet<br />
            <br />
            HOWEVER<br />
            <br />
            If there&#39;s even one BAR you win nothing :(<br />
            <br />
        </div>
    </form>
</body>
</html>
