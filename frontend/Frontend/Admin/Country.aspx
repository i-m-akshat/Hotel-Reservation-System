<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="Frontend.Admin.Country" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <div class="row justify-content-center align-items-stretch">
                <div class="col-md-4">
                    <div class="card">
    <div class="card-header">
        <h5 class="card-title mb-0">Add Country</h5>
    </div>
    <div class="card-body">
        <div class="col-12" style="font-size:12px">
             <div class="form-floating mb-3" style="background: none;">
     <%--<input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">--%>
     <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control" placeholder="Please Enter the Country Name"></asp:TextBox>
     <label for="txtCountryName">Country</label>
   </div>
            <div class="d-flex justify-content-between">
                <asp:Button ID="btnAddCountry" runat="server" OnClick="btnAddCountry_Click" CssClass="btn btn-outline-dark" Text="Add" />
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-outline-dark" Text="Clear" />
            </div>
        </div>
    </div>
    </div>
                </div>
                <div class="col-md-8">
                    <div class="card">
    <div class="card-header">
        <h5 class="card-title mb-0">Country List</h5>
    </div>
    <div class="card-body">
        <asp:GridView ID="grdCountryList" AutoGenerateColumns="false" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                 <asp:TemplateField HeaderText="Sr. No">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %> <!-- Display row index -->
            </ItemTemplate>
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Country Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
    </div>
                </div>
            </div>
     
            </div>
    </div>
</asp:Content>
