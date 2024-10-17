<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="State.aspx.cs" Inherits="HotelReservationSystem_Part1.Admin.State" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="row justify-content-between align-items-stretch">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Add State</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-12" style="font-size: 12px">
                            <div class="form-floating mb-3" style="background: none">
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" placeholder="Please select the country"></asp:DropDownList>
                                <label for="ddlCountry">Country</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none;">
                                <%--<input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">--%>
                                <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control" placeholder="Please Enter the State Name"></asp:TextBox>
                                <label for="txtStateName">State</label>
                            </div>
                            <div class="d-flex justify-content-between">
                                <asp:Button ID="btnAddState" runat="server" OnClick="btnAddState_Click" CssClass="btn btn-outline-dark" Text="Add" />
                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-outline-dark" Text="Clear" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">State List</h5>
                    </div>
                    <div class="card-body">
                        <asp:Repeater ID="rptStateList" runat="server">
                            <HeaderTemplate>
                        <table class="table table-responsive table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Sr.No.</th>
                                    <th>State</th>
                                    <th>Country </th>
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
        <td><%#Eval("StateName")%></td>
        <td><%#Eval("CountryName")%></td>
                                                  <td>
      <asp:LinkButton runat="server" CommandArgument='<%#Eval("StateId") %>' CssClass="btn btn-sm btn-outline-dark" ID="btnView" OnClick="btnView_Click"
          >View</asp:LinkButton>
      <asp:LinkButton CssClass="btn btn-sm btn-outline-dark" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Bind("StateId") %>'>Edit</asp:LinkButton>
      <asp:LinkButton CssClass="btn btn-sm btn-outline-dark" ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Bind("StateId") %>'>Delete</asp:LinkButton></td>
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
