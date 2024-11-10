<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="City.aspx.cs" Inherits="Frontend.Admin.City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="row justify-content-between align-items-stretch">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Add City</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-12" style="font-size: 12px">
                            <div class="form-floating mb-3" style="background: none">
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" placeholder="Please select the Country"></asp:DropDownList>
                                <label for="ddlCountry">Country</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" placeholder="Please select the State"></asp:DropDownList>
                                <label for="ddlState">State</label>
                            </div>
                         <%--   <div class="form-floating mb-3" style="background: none">
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" placeholder="Please select the city"></asp:DropDownList>
                                <label for="ddlCity">City</label>
                            </div>--%>

                            <div class="form-floating mb-3" style="background: none;">
                                <%--<input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">--%>
                                <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control" placeholder="Please Enter the City Name"></asp:TextBox>
                                <label for="txtCityName">City</label>
                            </div>
                            <div class="d-flex justify-content-between">
                                <asp:Button ID="btnAddCity" runat="server" OnClick="btnAddCity_Click" CssClass="btn btn-outline-dark" Text="Add" />
                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-outline-dark" Text="Clear" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">City List</h5>
                    </div>
                    <div class="card-body">
                        <asp:Repeater ID="rptCityList" runat="server">
                            <HeaderTemplate>
                                <table class="table table-responsive table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>Sr.No.</th>
                                            <th>City</th>
                                            <th>State</th>
                                           
                                            <th>Actions</th>
                                        </tr>

                                    </thead>

                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex + 1 %>
                                    </td>
                                     <td><%#Eval("CityName")%></td>
                                    <td><%#Eval("StateName")%></td>
                                    
                                    <td>
                                        <asp:LinkButton runat="server" CommandArgument='<%#Eval("CityId") %>' CssClass="btn btn-sm btn-outline-dark" ID="btnView" OnClick="btnView_Click">View</asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-sm btn-outline-dark" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Bind("CityId") %>'>Edit</asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-sm btn-outline-dark" ID="btnDelete" runat="server" Text="Delete" OnClientClick="return alertConfirm('Are you sure?', 'You won\'t be able to revert this!', 'Yes, delete it!', '<%= btnDelete.UniqueID %>');" OnClick="btnDelete_Click" />


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
</asp:Content>
