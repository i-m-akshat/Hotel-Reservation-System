<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="HotelImage.aspx.cs" Inherits="Frontend.Admin.HotelImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function bindHotelImages() {
            __doPostBack('<%=rptHotelImageList.UniqueID %>', '');
        }
    </script>
    <div class="container-fluid mt-5">
        <div class="row justify-content-between align-items-stretch">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title mb-0">Add Hotel Images</h5>
                    </div>
                    <div class="card-body">
                        <div class="col-12" style="font-size: 12px">
                            <div class="form-floating mb-3" style="background: none">
                                <asp:DropDownList ID="ddlHotel" runat="server" CssClass="form-control" placeholder="Please select the Hotel"></asp:DropDownList>
                                <label for="ddlHotel">Hotel</label>
                            </div>
                            <div class="form-floating mb-3" style="background: none">
                                <asp:FileUpload ID="btnUploadImages" AllowMultiple="true"  runat="server" CssClass="form-control form-control-sm" placeholder="Please select any image" />
                               <label for="img_BannerIMG" class="mb-4">Image</label>
                               <%-- <asp:Repeater ID="rptImagelist" runat="server">
                                    <ItemTemplate>
                                         <asp:Image ID="img_HotelIMG" runat="server" Visible="false" Height="250" Width="250" CssClass="form-control form-control-sm" />
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                                <asp:Image ID="img_HotelIMG" runat="server" Visible="false" Height="250" Width="250" CssClass="form-control form-control-sm mt-5" ImageAlign="AbsBottom" />
                                <%--<asp:PlaceHolder ID="pnl_Images" runat="server"></asp:PlaceHolder>--%>
                            </div>



                            <div class="d-flex justify-content-between">
                                <asp:Button ID="btnAddHotelImage" runat="server" OnClick="btnAddHotelImage_Click" CssClass="btn btn-outline-dark" Text="Add" />
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
                            <asp:Repeater ID="rptHotelImageList" runat="server">
                                <headertemplate>
                                    <table class="table table-sm table-hover text-sm-center table-striped">
                                        <thead>
                                            <tr>
                                                <th>Sr.No.</th>
                                                <th>Hotel Name</th>
                                                <th>Hotel Image Name</th>
                                                <th>Actions</th>
                                            </tr>

                                        </thead>

                                        <tbody>
                                </headertemplate>
                                <itemtemplate>
                                    <tr>
                                        <td>
                                            <%# Container.ItemIndex + 1 %>
                                        </td>
                                        <td><%#Eval("HotelName")%></td>
                                        <td><%#Eval("ImageName")%></td>
                                        <td>
                                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("HotelImageId") %>' CssClass="btn btn-sm btn-outline-dark my-2" ID="btnView" OnClick="btnView_Click">View</asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-sm btn-outline-dark my-2" ID="btnEdit" runat="server" OnClick="btnEdit_Click" CommandArgument='<%#Bind("HotelImageId") %>'>Edit</asp:LinkButton>
                                            <asp:LinkButton
                                                CssClass="btn btn-sm btn-outline-dark my-2"
                                                ID="btnDelete"
                                                runat="server"
                                                Text="Delete"
                                                CommandArgument='<%# Eval("HotelImageId") %>'
                                                OnClick="btnDelete_Click" />
                                    </tr>
                                </itemtemplate>


                                <footertemplate>
                                    </tbody>
</table>
                                  
                                    
                                </footertemplate>

                            </asp:Repeater>
                              <asp:LinkButton ID="btnPrev" OnClick="btnPrev_Click" runat="server" CssClass="btn btn-sm btn-secondary" Text="Prev"></asp:LinkButton>
  <asp:LinkButton ID="btnNext" OnClick="btnNext_Click" runat="server" CssClass="btn btn-sm btn-secondary" Text="Next"></asp:LinkButton>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
