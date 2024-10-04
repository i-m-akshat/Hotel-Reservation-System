<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="HotelReservationSystem_Part1.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid text-black-50" >
       <%-- <div class="loginGlass">--%>
            <div class="col-md-12">
                
                <div class="row mx-2 justify-content-center align-items-center">
                
                    <div class="col-md-8">
                        <%--<h1 class="textMainLoginHead py-5 text-white">Basera - Where every journey feels like home</h1>
                        <p class="text-justify text-white textSubLogin">Find the comfort of home amenities, in every city - Choose Basera.</p>--%>
                        <img src="Assets/Image/About Us - Animation Concept.gif" class="img-fluid d-flex py-5" />
                    </div>
                    <div class="col-md-4">
                        <div class="card px-2" style="background-color:white">
                            <h3 class="text-start py-2 text-black-50 mt-2 px-3 text-card-head">Admin Login</h3>
                            <div class="card-body">
                               
                                <div class="form-floating mb-3" style="background: none;">
                                    <%--<input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">--%>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Please Enter the Username"></asp:TextBox>
                                    <label for="txtUsername">UserName</label>
                                  </div>
                                  <div class="form-floating">
                                    <%--<input type="password" class="form-control" id="floatingPassword" placeholder="Password">--%>
                                      <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Please Enter the Password"></asp:TextBox>
                                    <label for="txtPassword">Password</label>
                                  </div>
                                  <div class="col-12 my-3 text-center">
                                    
                                    <asp:Button CssClass="btn btn-sm btn-outline-dark" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login"></asp:Button>
                                  </div>
                                 <%-- <div class="col-md-12">
                                    <div class="row d-flex">
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <span class="text-white d-flex-inline" style="font-size: 14px;">Forgot Password ? <a class="btnClick" role="button">&nbsp;Click here.</a></span>
                                            </div>
                                            
                                        </div>
                                        <div class="col-md-6">
                                            <span class="text-white" style="font-size: 14px;">New User ? Please Click on<a class="btnClick" id="btnRegister" runat="server"   onserverclick="btnRegister_ServerClick" role="button">&nbsp; Register</a></span>
                                        </div>
                                    </div>
                                  </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
          
        <%--</div>--%>
    </div>

</asp:Content>
