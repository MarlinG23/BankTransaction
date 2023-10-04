<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="BankTransaction.ReportPage" %>

<!DOCTYPE html>

<script type="text/javascript">
    $(document).ready(function () {
        // Load content for ReportPage.aspx when the page loads
        loadContent('ReportPage.aspx');
    });
</script>

<form id="form1" runat="server">
    <asp:GridView ID="gvSummaryReport" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="BranchCode" HeaderText="Branch Code" />
            <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="TotalCount" HeaderText="Total Count" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:C2}" />
        </Columns>
    </asp:GridView>
</form>
