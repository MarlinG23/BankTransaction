<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewImports.aspx.cs" Inherits="BankTransaction.ViewImports" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Imports</title>
    <!-- Add any necessary CSS or JavaScript libraries -->

    <!-- Add the JavaScript function -->
    <script>
        function loadImports() {
            var container = document.getElementById('<%= importsContainer.ClientID %>');
            container.style.display = (container.style.display === 'none') ? 'block' : 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <a href="#" id="viewImportsLink" onclick="loadImports(); return false;">View Imports</a>
        <div id="importsContainer" runat="server" style="display:none;">
            <h2>Master Grid</h2>
            <asp:GridView ID="gvMaster" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="SelectMasterRecord">
                <Columns>
                    <asp:BoundField DataField="AccountHolder" HeaderText="Account Holder" />
                    <asp:BoundField DataField="BranchCode" HeaderText="Branch Code" />
                    <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                    <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
                </Columns>
            </asp:GridView>

            <h2>Detail Grid</h2>
            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="EffectiveStatusDate" HeaderText="Effective Status Date" />
                    <asp:TemplateField HeaderText="Time Breached">
                        <ItemTemplate>
                            <%# CalculateTimeBreached((DateTime)Eval("TransactionDate"), (DateTime)Eval("EffectiveStatusDate")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
