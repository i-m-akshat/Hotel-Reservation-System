<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Frontend.Admin.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .form-control {
        background-color: transparent !important;
        border-style:none !important;
        /*color:black !important;*/
    }
        
    </style>
    <div class="col-12" style=" border-radius: 20px">
        <section class="row justify-content-center align-items-stretch d-flex mx-2 px-2 py-2">
            <div class="col-5 d-flex flex-column">
                <div class="card" style="background-color: #7500ff;border-radius:10% !important;box-shadow: 0 4px 10px rgba(117, 0, 255, 0.3), 0 2px 5px rgba(117, 0, 255, 0.5);
">
                    <div class="card-body">
                        <div class="col-12 my-2 px-2 mx-2">
    <div class="d-flex flex-column align-items-center">
        <!-- Image and Name aligned at the start -->
        <img class="d-flex mb-2" src="../Assets/Image/Gif/Greetings from Japan.gif" height="200" width="200" style="border-radius: 50%" />
        <h3 class="text-center text-white mt-2" style="font-weight: 1000;font-size:30px">Akshat Dwivedi</h3>
        <h5 class="text-start text-white mt-1" style="font-weight: 400;font-size:20px">Software Developer</h5>

        <div class="col-12 mt-4">
            <div class="row justify-content-center align-items-center mt-3">
                <div class="col-4">
                    <div class="row">
                        <div class="col-12 mb-3">
                            <label class="text-white mb-0 text-center">Age</label>
                        </div>
                        <div class="col-12 mb-3">
                            <label class="text-white mb-0 text-center">Email</label>
                        </div>
                        <div class="col-12 mb-3">
                            <label class="text-white mb-0 text-center">Country</label>
                        </div>
                        <div class="col-12 mb-3">
                            <label class="text-white mb-0 text-center">Phone</label>
                        </div>
                        <div class="col-12 mb-3">
                            <label class="text-white mb-0 text-center">Address</label>
                        </div>
                    </div>
                </div>
                <div class="col-8">
                    <div class="row">
                        <div class="col-12 mb-3">
                            <p class="text-white mb-0 text-end">12</p>
                        </div>
                        <div class="col-12 mb-3">
                            <p class="text-white mb-0 text-end text-wrap">akshatdwivedi59941@gmail.com</p>
                        </div>
                        <div class="col-12 mb-3">
                            <p class="text-white mb-0 text-end">India</p>
                        </div>
                        <div class="col-12 mb-3">
                            <p class="text-white mb-0 text-end">123-456-7890</p>
                        </div>
                        <div class="col-12 mb-3">
                            <p class="text-white mb-0 text-end">123 Street, City, State</p>
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
            <div class="col-7 d-flex flex-column my-2 px-2">
    <div class="row justify-content-between align-items-stretch">
        <!-- First Row -->
        <div class="col-6">
     <div class="card h-100" style="border-radius: 10%; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
         <img src="../Assets/Image/Gif/Happy Friday!.gif" class="card-img-top" style="object-fit: cover; width: 100%; height: 100%;">
     </div>
 </div>
 <div class="col-6">
     <div class="card h-100  " style="border-radius: 10%; overflow: hidden; box-shadow: 0 4px 10px rgba(255, 77, 153, 0.3), 0 2px 5px rgba(255, 77, 153, 0.5);
background-color:#FF4D99;">
         <div class="card-body">
             <div class="row d-flex align-items-center">
    <div class="col-auto">
        <h4 class="text-start text-white">Edit Information</h4>
    </div>
    <div class="col-auto ms-auto">
        <asp:LinkButton CssClass="btn btn-sm btn-outline-light" ID="btnEditInfo" runat="server" 
ToolTip="To Edit the Information"
style="width: 40px; height: 40px; padding: 0; border-radius: 50%; display: flex; justify-content: center; align-items: center;">
<i class="fa-solid fa-user-pen"></i></asp:LinkButton>
    </div>
</div>

             <div class="col-12 pt-4">
                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control text-white">Akshat Dwivedi</asp:TextBox>
             </div>
             <div class="col-12 mt-2">
                 <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control text-white">akshatdwivedi@gmail.com</asp:TextBox>
             </div>
             <div class="col-12 mt-2">
                 <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control text-white">12312412</asp:TextBox>
             </div>
             <div class="col-12 mt-2">
                 <asp:TextBox ID="TextBox16" runat="server" CssClass="form-control text-white">Parsawan khud, milkipur</asp:TextBox>
             </div>
         </div>
     </div>
 </div>
    </div>
    
    <div class="row justify-content-between align-items-stretch mt-3">
        <!-- Second Row -->
        <div class="col-6">
    <div class="card h-100" style="border-radius: 10%; overflow: hidden; box-shadow: 0 4px 10px rgba(0, 207, 255, 0.3), 0 2px 5px rgba(0, 207, 255, 0.5);background-color:#00CFFF;">
        <div class="card-body">
                    <div class="row d-flex align-items-center">
<div class="col-auto">
        <h4 class="text-start mb-0 text-wrap text-white" style="line-height: 40px;">Address</h4> <!-- Ensuring line-height matches the button height -->
    </div>
   <div class="col-auto ms-auto">
        <asp:LinkButton 
            CssClass="btn btn-sm btn-outline-light" 
            ID="btnEditAddInfo" 
            runat="server" 
            ToolTip="To Edit the Information"
            style="width: 40px; height: 40px; padding: 0; border-radius: 50%; display: flex; justify-content: center; align-items: center;">
            <i class="fa-solid fa-user-pen"></i>
        </asp:LinkButton>
    </div>
</div>


            
            <div class="col-12 pt-4">
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control text-white">Milkipur</asp:TextBox>
            </div>
            <div class="col-12 mt-2">
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control text-white">Ayodhya</asp:TextBox>
            </div>
            <div class="col-12 mt-2">
                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control text-white">Uttar Pradesh</asp:TextBox>
            </div>
            <div class="col-12 mt-2">
                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control text-white">India</asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div class="col-6">
    <div class="card h-100" style="border-radius: 10%; overflow: hidden; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
        <img src="../Assets/Image/Gif/Peace.gif" class="card-img-top" style="object-fit: cover; width: 100%; height: 100%;">
    </div>
</div>
    </div>
</div>


        </section>

    </div>

</asp:Content>

