<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="Frontend.Admin.Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
    function bindCity() {
        /*window.location.reload();*/
       __doPostBack('<%=rptRoleList.UniqueID %>', '');
    }
    </script>
        <div class="col-md-12">
        <div class="row justify-content-between align-items-stretch">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Add Role</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-12" style="font-size: 12px">
                            <div class="form-floating mb-3" style="background: none;">
                                
                                <asp:TextBox ID="txtRoleName" runat="server" CssClass="form-control" placeholder="Please Enter the Role Name"></asp:TextBox>
                                <label for="txtRoleName">Role</label>
                            </div>
                            <div class="d-flex justify-content-between">
                                <asp:Button ID="btnAddRole" runat="server" OnClick="btnAddRole_Click" CssClass="btn btn-outline-dark" Text="Add" />
                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-outline-dark" Text="Clear" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Role List</h5>
                    </div>
                    <div class="card-body">
                   
                                <asp:Repeater ID="rptRoleList" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-responsive table-hover table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Sr.No.</th>
                                                  <th>Role</th>
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
                                            <td><%#Eval("RoleName")%></td>
                                          
                                            <td>
                                                <asp:LinkButton runat="server" CommandArgument='<%#Eval("RoleId") %>' CssClass="btn btn-sm btn-outline-dark" ID="btnView" OnClick="btnView_Click">View</asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-sm btn-outline-dark" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Bind("RoleId") %>'>Edit</asp:LinkButton>
                                                <asp:LinkButton
                                                    CssClass="btn btn-sm btn-outline-dark"
                                                    ID="btnDelete"
                                                    runat="server"
                                                    Text="Delete"
                                                    CommandArgument='<%# Eval("RoleId") %>'
                                                    OnClick="btnDelete_Click" />
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

