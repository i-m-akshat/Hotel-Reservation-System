<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HotelReservationSystem_Part1.Login" Title="Login" Culture="hi-IN" uiCulture="en-IN" %>

<!DOCTYPE html>
<html>
<head runat="server">
   <title>Basera</title>
    <meta charset="UTF-8">
    <meta name="description" content="Basera Hotel Booking App">
    <meta name="author" content="Akshat Dwivedi">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href="../Assets/Image/logo/Basera.png">
    <link rel="stylesheet" href="../Assets/Bootstrap/css/bootstrap.min.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Space+Grotesk:wght@300..700&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link
        href="https://fonts.googleapis.com/css2?family=Comfortaa:wght@300..700&family=Space+Grotesk:wght@300..700&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="../Assets/css/index.css">
    <link href="../Assets/FontAwesome/css/all.min.css" rel="stylesheet" />
</head>

<body>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid loginBody" >
        <div class="loginGlass">
            <div class="col-md-12">
                
                <div class="row mx-2">
                
                    <div class="col-md-8">
                        <h1 class="textMainLoginHead py-5 text-white">Basera - Where every journey feels like home</h1>
                        <p class="text-justify text-white textSubLogin">Find the comfort of home amenities, in every city - Choose Basera.</p>
                    </div>
                    <div class="col-md-4">
                        <div class="card px-2">
                            <h3 class="text-start py-2 text-white mt-2 px-3 text-card-head">Login/SignUp</h3>
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
                                    
                                    <asp:Button CssClass="btn btn-outline-light" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login"></asp:Button>
                                  </div>
                                  <div class="col-md-12">
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
                                  </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
          
        </div>
    </div>
        </form>
</body>
    </html>