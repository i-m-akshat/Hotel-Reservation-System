<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HotelReservationSystem_Part1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basera</title>
    <meta charset="UTF-8" />
    <meta name="description" content="Basera Hotel Booking App" />
    <meta name="author" content="Akshat Dwivedi" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="icon" type="image/x-icon" href="Assets/Image/logo/favicon.ico" />
    <link rel="stylesheet" href="Assets/Bootstrap/css/bootstrap.min.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Kalam:wght@300;400;700&display=swap" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Space+Grotesk:wght@300..700&display=swap" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
        href="https://fonts.googleapis.com/css2?family=Comfortaa:wght@300..700&family=Space+Grotesk:wght@300..700&display=swap"
        rel="stylesheet" />
    <link rel="stylesheet" href="Assets/css/index.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid SignUpBody">

          <%--  <div class="SignUpGlass">--%>
                <div class="col-md-12">
                    <div class="row px-3">
                        <div class="col-md-6">
                            <h1 class="textMainLoginHead py-5 text-white">Basera - Where every journey feels like home</h1>
                            <p class="text-justify text-white textSubLogin">Find the comfort of home amenities, in every city - Choose Basera.</p>
                        </div>
                        <div class="col-md-6">
                            <div class="card">
                                <h3 class="text-start py-2 text-white mt-2 px-3 text-card-head">SignUp</h3>
                                <div class="card-body px-2 mx-2">



                                    <div class="row justify-content-center align-items-center">
                                        <div class="col-md-6">
                                            <div class="form-floating mb-3 text-white" style="background: none;">
                                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control form-control-sm" placeholder="Full Name" BackColor="Transparent" ForeColor="White"></asp:TextBox>
                                                <asp:RequiredFieldValidator ControlToValidate="txtFullName" ID="btnReqFullName" runat="server" ErrorMessage="Please Enter the FullName" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <label for="txtFullName" class="mx-3">Full Name</label>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-floating mb-3 text-white" style="background: none;">
                                                <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control form-control-sm" placeholder="User ID" BackColor="Transparent" ForeColor="White"></asp:TextBox>
                                                <asp:RequiredFieldValidator ControlToValidate="txtUserID" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter the UserID" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <label for="txtUserID" class="mx-3">UserID</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row justify-content-center align-items-center mx-2">
                                    <div class="col-md-6">
                                        <div class="form-floating mb-3 text-white" style="background: none;">
                                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control form-control-sm" placeholder="Name@example.com" runat="server" BackColor="Transparent" ForeColor="White"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter the Email id" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <label for="txtEmail">Email address</label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-floating mb-3 text-white" style="background: none;">
                                            <asp:TextBox ID="txtPhoneNo" TextMode="Phone" CssClass="form-control form-control-sm" placeholder="Phone Number" runat="server" BackColor="Transparent" ForeColor="White"></asp:TextBox>
                                            <label for="txtPhoneNo">Phone number</label>
                                            <asp:RequiredFieldValidator ControlToValidate="txtPhoneNo" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter the Phoen Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row justify-content-center align-items-center mx-2">
                                    <div class="col-md-4">
                                        <div class="form-floating mb-3 text-white" style="background: none;">
                                            <asp:DropDownList ID="ddlCountry" CssClass="form-control form-control-sm" placeholder="Country" runat="server" BackColor="Transparent" ForeColor="White"></asp:DropDownList>
                                            <label for="ddlCountry">Country</label>
                                           <%-- <asp:RequiredFieldValidator ControlToValidate="ddlCountry" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select the Country" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-floating mb-3 text-white" style="background: none;">
                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control form-control-sm" placeholder="State" BackColor="Transparent" ForeColor="White"></asp:DropDownList>
                                            <label for="ddlState">State</label>
                                            <%--<asp:RequiredFieldValidator ControlToValidate="ddlState" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select the State" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-floating mb-3 text-white" style="background: none;">
                                            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control form-control-sm" placeholder="City" BackColor="Transparent" ForeColor="White"></asp:DropDownList>
                                            <label for="ddlCity">City</label>
                                            <%--<asp:RequiredFieldValidator ControlToValidate="ddlCity" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Select the City" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row justify-content-center align-items-center mx-2">
                                    <div class="col-md-6">
                                        <div class="form-floating mb-3 text-white" style="background: none;">
                                            <asp:TextBox ID="txtPassword" TextMode="Password"  runat="server" CssClass="form-control form-control-sm" BackColor="Transparent" ForeColor="White" BorderColor="White"></asp:TextBox>
                                            <label for="txtPassword">Password</label>
                                            <asp:RequiredFieldValidator ControlToValidate="txtPassword" ID="RequiredFieldValidator6" runat="server"></asp:RequiredFieldValidator>
<%--<asp:RegularExpressionValidator 
    ID="regPassword" 
    runat="server" 
    ControlToValidate="txtPassword" 
    ValidationExpression="^(?=.*[A-Z])(?=.*[a-z])[A-Za-z]{2}\d{4,}$" 
    ErrorMessage="Password should be at least 6 characters, contain exactly 2 letters (one uppercase and one lowercase), and the rest must be numbers.">
</asp:RegularExpressionValidator>--%>

                                        </div>
                                    </div>
                                    <%--<div class="col-md-6">
                                        <div class="form-floating mb-3" style="background: none;">
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                            <label for="txtConfirmPassword">Re Enter Password</label>
                                            <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" ID="RequiredFieldValidator7" runat="server"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConfirmPassword" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password should contain eight characters, at least one letter and one number"></asp:RegularExpressionValidator>
                                            <asp:CompareValidator ID="cmprPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password does not match" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class="row justify-content-center align-items-center mx-2">
                                    
                                    
                                        <div class="form-floating mb-3 text-white" style="background: none;">
                                            <asp:TextBox ID="txtAddress" CssClass="form-control form-control-sm" placeholder="Address" runat="server" BackColor="Transparent" ForeColor="White"></asp:TextBox>
                                            <label for="txtAddress">Address</label>
                                            <asp:RequiredFieldValidator ControlToValidate="txtAddress" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter the Address" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                   
                                </div>
                                <div class="col-12 my-3 text-center">

                                    <asp:Button class="btn btn-outline-light" ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register"></asp:Button>
                                </div>
                                <div class="col-md-12">
                                    <div class="row d-flex">
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <span class="text-white d-flex-inline" style="font-size: 14px;"></span>
                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <span class="text-white" style="font-size: 14px;">Already an User ? Please Click on<a class="btnClick" href="Login.aspx" role="button">&nbsp;Login</a></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
           <%-- </div>--%>

            <!-- <div class="row mx-2">
                    <div class="col-md-6">
                        <h1 class="textMainLoginHead py-5 text-white">Basera - Where every journey feels like home</h1>
                        <p class="text-justify text-white textSubLogin">Find the comfort of home amenities, in every city - Choose Basera.</p>
                    </div>
                    <div class="col-md-6">
                        <div class="card px-2">
                            <h3 class="text-start py-2 text-white mt-2 px-3 text-card-head">Login/SignUp</h3>
                            <div class="card-body">
                               
                                <div class="form-floating mb-3" style="background: none;">
                                    <input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
                                    <label for="floatingInput">Email address</label>
                                  </div>
                                  <div class="form-floating">
                                    <input type="password" class="form-control" id="floatingPassword" placeholder="Password">
                                    <label for="floatingPassword">Password</label>
                                  </div>
                                  <div class="col-12 my-3 text-center">
                                    
                                    <button class="btn btn-outline-light">Login</button>
                                  </div>
                                  <div class="col-md-12">
                                    <div class="row d-flex">
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <span class="text-white d-flex-inline" style="font-size: 14px;">Forgot Password ? <a class="btnClick" type="button">&nbsp;Click here.</a></span>
                                            </div>
                                            
                                        </div>
                                        <div class="col-md-6">
                                            <span class="text-white" style="font-size: 14px;">New User ? Please Click on<a class="btnClick" type="button">&nbsp;Register</a></span>
                                        </div>
                                    </div>
                                  </div>
                            </div>
                        </div>
                    </div>
                </div> -->
        </div>
    </form>
    <script src="Assets/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="Assets/Jquery/jquery-3.6.4.min.js"></script>
</body>
</html>
