<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="Frontend.Admin.Country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
    function bindCountry() {
        /*window.location.reload();*/
       __doPostBack('<%=rptTblCountry.UniqueID %>', '');
    }
    </script>
    <div class="row">
        <div class="col-12">
            <div class="row justify-content-center align-items-stretch">
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title mb-0">Add Country</h5>
                        </div>
                        <div class="card-body">
                            <div class="col-12" style="font-size: 12px">
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

                            <asp:Repeater ID="rptTblCountry" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-responsive table-hover table-striped text-sm-center">
                                        <thead style="font-size: 15px">
                                            <tr>
                                                <th>Serial No</th>
                                                <th>Country</th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody style="font-size: 14px">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1 %></td>
                                        <td><%# Eval("CountryName") %></td>

                                        <td>
                                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("CountryId") %>' CssClass="btn btn-sm btn-outline-dark" ID="btnView" OnClick="btnView_Click"
                                                >View</asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-sm btn-outline-dark" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Bind("CountryId") %>'>Edit</asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-sm btn-outline-dark" ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Bind("CountryId") %>'>Delete</asp:LinkButton></td>

                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
</table>
            
                                </FooterTemplate>

                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
