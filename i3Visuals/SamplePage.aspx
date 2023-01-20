<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplePage.aspx.cs" Inherits="i3Visuals.SamplePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Chart ID="Chart1" runat="server" Width="488px">
                <Titles>
                    <asp:Title ShadowOffset="3" Name="Items" />
                </Titles>
                <Legends>
                    <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                        LegendStyle="Row" />
                </Legends>
                <Series>
                    <asp:Series Name="Year"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:Chart ID="Chart2" runat="server" BorderlineColor="Orange">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </form>
</body>
</html>
