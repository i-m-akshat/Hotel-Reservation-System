<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="HotelReservationSystem_Part1.Error404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" style="height:550px">
        <div class="row justify-content-center align-items-center h-100">
            <img src="Assets/Image/Gif/ConnectionError.gif" class="d-flex img-fluid col-md-12" style="height:300px;width:300px" />
            <h5 class="text-center col-md-12">Oops! Something went wrong</h5>
            <p class="text-black-50 text-center col-md-12">We couldn't find the page you were looking for.<br />
                Why not try back to the <a class="text-decoration-none text-black" href="Common/Default.aspx">homepage</a>.
            </p>
        </div>
    </div>
</asp:Content>
