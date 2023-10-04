<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BankTransaction._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Default.aspx -->
        <style type="text/css">
            .container {
                display: flex;
                flex-direction: row;
                border: 1px solid #ccc; /* Border around the entire container */
            }

            .nav-table {
                text-align: left;
                border-right: 1px solid #ccc; /* Right border for the left column */
                padding: 10px;
            }

            .content-column {
                flex: 1;
                padding: 10px;
            }

            .content-label {
                text-align: right;
                font-weight: bold;
            }
        </style>

        <div class="container">
            <div class="nav-table">
                <table>
                    <tr>
                        <td>
                            <a href="#" onclick="loadContent('ImportPage.aspx'); return false;">Import File</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="ViewImports.aspx" target="content">View Imports</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="#" onclick="loadContent('ReportPage.aspx'); return false;">Report</a>
                        </td>
                    </tr>
                </table>
                <div class="content-label">
                    &lt;Navigation Area&gt;
                </div>
            </div>
            <div class="content-column">
                <div id="contentArea">
                    <!-- Content will be loaded here -->
                </div>
                <div class="content-label">
                    &lt;Content Area&gt;
                </div>
            </div>
        </div>
    </main>



        <!-- Default.aspx -->
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script type="text/javascript">
            function loadContent(pageUrl) {
                $.ajax({
                    url: pageUrl,
                    cache: false,
                    success: function (html) {
                        $("#contentArea").html(html);
                    }
                });
            }
        </script>
    </main>
</asp:Content>
