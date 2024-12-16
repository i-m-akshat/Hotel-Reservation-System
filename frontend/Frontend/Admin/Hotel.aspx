<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Hotel.aspx.cs" Inherits="Frontend.Admin.Hotel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>
        function bindAdmins() {
            /*window.location.reload();*/
            __doPostBack('<%=rptHotelList.UniqueID %>', '');
        }
        <%--function OnBlur() {
            document.getElementById('<%=lnkHidden.ClientID %>').click();
        };--%>
        </script>
    <div class="col-md-12">
        <div class="row justify-content-between align-items-stretch">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Add Hotels</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-12" style="font-size: 12px">
                            <div class="form-floating mb-3" style="background: none">
                                <asp:TextBox ID="txtHotelName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                <label for="txtHotelName">Hotel Name</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                               <asp:TextBox ID="txtHotelDescription" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                <label for="txtHotelDescription">Description</label>
                                                            </div>
                           
                            <div class="form-floating mb-3" style="background: none">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-sm" placeholder="Please enter the Address"></asp:TextBox>
                                <label for="txtAddress">Address</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:FileUpload ID="btnIconImgUpload" runat="server" CssClass="form-control form-control-sm" placeholder="Please select any image" />
                                <asp:Image ID="img_IconIMG" runat="server" Visible="false" Height="250" Width="250" CssClass="form-control form-control-sm" />
                                <label for="img_IconIMG">Icon Image</label>
                            </div>
                             <div class="form-floating mb-3" style="background: none">
     <asp:FileUpload ID="btnBannerImgUpload" runat="server" CssClass="form-control form-control-sm" placeholder="Please select any image" />
     <asp:Image ID="img_BannerIMG" runat="server" Visible="false" Height="250" Width="250" CssClass="form-control form-control-sm" />
     <label for="img_BannerIMG">Banner Image</label>
 </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control form-control-sm" placeholder="Please enter the longitude"></asp:TextBox>
                                <label for="txtLongitude">Longitude</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:TextBox ID="txtLattitude" runat="server" CssClass="form-control form-control-sm" placeholder="Please enter the lattitude"></asp:TextBox>
                                <label for="txtLattitude">Lattitude</label>
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
                        <h5 class="card-title mb-0">Hotel List</h5>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:Repeater ID="rptHotelList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-responsive table-hover table-striped">
                                        <thead>
                                            <tr>
                                                <th>Sr.No.</th>
                                                <th>Hotel Name</th>
                                                <th>Address</th>
                                                <th>Longitude</th>
                                                <th>Lattitude</th>
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
                                        <td><%#Eval("HotelName")%></td>
                                        <td><%#Eval("Address")%></td>
                                        <td><%#Eval("Longitude")%></td>
                                        <td><%#Eval("Lattitude")%></td>
                                        <td><%#Eval("CityName")%></td>
                                        <td><%#Eval("StateName")%></td>
                                        <td><%#Eval("CountryName")%></td>
                                        <td>
                                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("HotelId") %>' CssClass="btn btn-sm btn-outline-dark my-2" ID="btnView" OnClick="btnView_Click">View</asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-sm btn-outline-dark my-2" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Bind("HotelId") %>'>Edit</asp:LinkButton>
                                            <asp:LinkButton
                                                CssClass="btn btn-sm btn-outline-dark my-2"
                                                ID="btnDelete"
                                                runat="server"
                                                Text="Delete"
                                                CommandArgument='<%# Eval("HotelId") %>'
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
