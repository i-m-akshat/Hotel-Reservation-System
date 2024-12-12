<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Frontend.Admin.Admin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function bindAdmins() {
            /*window.location.reload();*/
            __doPostBack('<%=rptAdminList.UniqueID %>', '');
        }
        function OnBlur() {
            document.getElementById('<%=lnkHidden.ClientID %>').click();
        };
    </script>
    <div class="col-md-12">
        <div class="row justify-content-between align-items-stretch">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Add Admin</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-12" style="font-size: 12px">
                            <div class="form-floating mb-3" style="background: none">
                                <asp:TextBox ID="txtAdminName" runat="server" onblur="OnBlur();" CssClass="form-control form-control-sm" placeholder="Please enter the admin Name "></asp:TextBox>
                                <label for="txtAdminName">Admin Name</label>
                                <asp:LinkButton id="lnkHidden" runat="server" OnClick="txtName_LostFocus"></asp:LinkButton>
                                <asp:Label ID="lblAdminName_message" runat="server" ForeColor="#ff3300"></asp:Label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control form-control-sm" placeholder="Please enter the Full Name "></asp:TextBox>
                                <label for="txtFullName">Full Name</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-sm" placeholder="Please enter the Address"></asp:TextBox>
                                <label for="txtAddress">Address</label>
                            </div>
                             <div class="form-floating mb-3" style="background: none">
                                 <asp:FileUpload ID="btnImgUpload" runat="server" CssClass="form-control form-control-sm" placeholder="Please select any image" />
     <asp:Image ID="img_AdminIMG" runat="server" Visible="false" Height="250" Width="250" CssClass="form-control form-control-sm" />
     <label for="img_AdminIMG">Image</label>
 </div>
                                                        <div class="form-floating mb-3" style="background: none">
   <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control form-control-sm" placeholder="Please enter the mobile no"></asp:TextBox>
    <label for="txtMobileNo">Mobile No</label>
</div>
                                                                                    <div class="form-floating mb-3" style="background: none">
   <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control form-control-sm" placeholder="Please enter your email id"></asp:TextBox>
    <label for="txtEmailId">Email</label>
</div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" placeholder="Please select the Country"></asp:DropDownList>
                                <label for="ddlCountry">Country</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" placeholder="Please select the State"></asp:DropDownList>
                                <label for="ddlState">State</label>
                            </div>
                           

                            <div class="form-floating mb-3" style="background: none;">
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" placeholder="Please select the City"></asp:DropDownList>
                                <label for="txtCityName">City</label>
                            </div>
                            <div class="d-flex justify-content-between">
                                <asp:Button ID="btnAddAdmin" runat="server" OnClick="btnAddAdmin_Click" CssClass="btn btn-outline-dark" Text="Add" />
                                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-outline-dark" Text="Clear" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Admin List</h5>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                                                    <asp:Repeater ID="rptAdminList" runat="server">
                            <HeaderTemplate>
                                <table class="table table-responsive table-hover table-striped">
                                    <thead>
                                        <tr>
                                            <th>Sr.No.</th>
                                            <th>Username</th>
                                            <th>Full Name</th>
                                            <th>Address</th>
                                            <th>Mobile No</th>
                                            <th>Email</th>
                                            <th>City</th>
                                            <th>State</th>
                                            <th>Country</th>
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
                                    <td><%#Eval("AdminName")%></td>
                                    <td><%#Eval("FullName")%></td>
                                    <td><%#Eval("Address")%></td>
                                    <td><%#Eval("PhoneNumber")%></td>
                                    <td><%#Eval("EmailId")%></td>
                                    <td><%#Eval("CityName")%></td>
                                    <td><%#Eval("StateName")%></td>
                                    <td><%#Eval("CountryName")%></td>
                                    <td>
                                        <asp:LinkButton runat="server" CommandArgument='<%#Eval("AdminId") %>' CssClass="btn btn-sm btn-outline-dark my-2" ID="btnView" OnClick="btnView_Click">View</asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-sm btn-outline-dark my-2" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Bind("AdminId") %>'>Edit</asp:LinkButton>
                                        <asp:LinkButton
                                            CssClass="btn btn-sm btn-outline-dark my-2"
                                            ID="btnDelete"
                                            runat="server"
                                            Text="Delete"
                                            CommandArgument='<%# Eval("AdminId") %>'
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
    </div>
</asp:Content>
