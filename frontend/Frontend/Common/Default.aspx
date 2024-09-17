<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelReservationSystem_Part1.Common.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
         <section class="heroSection">
                <div class="heroGlass">

                    <div class="heroText">
                        <h3 class="heroHead">
                            Welcome to the Basera
                        </h3>
                        <p class="heroDescription">
                            Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has
                            been the industry's standard dummy text ever since the 1500s.
                        </p>
                        <div class="col-md-12 mt-2d heroBox">
                            <div class="row justify-content-center align-items-center form-group">
                                <div class="col-md-5">
                                    <input class="form-control form-control-sm mt-1"
                                        placeholder="Please Select the Location"></input>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control form-control-sm mt-1" type="date"></input>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control form-control-sm mt-1" type="date"></input>
                                </div>
                                <div class="col-md-1">
                                    <button class="btn btn-outline-success btn-light mt-1" type="submit">Search</button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </section>
            <section class="col-md-12 py-5">
                <h1 class="text-center py-3">Some Heading</h1>
                <p class="text-center py-3">Here are the sub Description</p>
                <div class="row py-3">
                    <div class="col-md-6 align-items-stretch d-flex">
                        <div class="textBox">
                            <h3 class="text-center py-3">
                                Our Hotel Booking website Advantage
                            </h3>
                            <p class="text-center py-3">
                                Book hotels that welcome your furry companions with open arms (and treats!). This
                                website can filter hotels based on pet-friendly amenities and even connect you with pet
                                sitting services at your destination.
                            </p>

                            <button class="text-center btn btn-outline-dark">Check Now</button>

                        </div>

                    </div>
                    <div class="col-md-6">
                        <img src="../Assets/Image/lights-the-evening-netherlands-holland-zaandam-hd-wallpaper-preview.jpg"
                            class="d-flex img-fluid" style="border-radius: 30px;" />
                    </div>
                </div>
            </section>
            <section class="col-md-12 py-5">
                <h1 class="text-center py-3">Here Are the Rooms</h1>
                <p class="text-center py-3">Here are the sub heroDescription</p>
                <div class="row mt-2 py-2">
                    <div class="col-md-4 align-items-stretch d-flex py-3">
                        <div class="card">
                            <img src="../Assets/Image/images.jpeg" class="card-img-top" alt="...">
                            <div class="card-body d-flex flex-column">
                                <h5 class="card-title py-3 text-center">Card title</h5>
                                <p class="card-text">Some quick example text to build on the card title and make up the
                                    bulk of the card's content.</p>
                                <div class="col-12  mb-0 mt-auto" style="text-align: center;">
                                    <a href="#" class="btn btn-outline-dark">Go somewhere</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 align-items-stretch d-flex py-3">
                        <div class="card">
                            <img src="../Assets/Image/images (1).jpeg" class="card-img-top" alt="...">
                            <div class="card-body d-flex flex-column">

                                <h5 class="card-title py-3 text-center">Card title</h5>
                                <p class="card-text">Some quick example text to build on the card title and make up the
                                    bulk of the card's content.</p>
                                <div class="col-12  mb-0 mt-auto" style="text-align: center;">
                                    <a href="#" class="btn btn-outline-dark">Go somewhere</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 align-items-stretch d-flex py-3">
                        <div class="card">
                            <img src="../Assets/Image/homestay-hotel.jpg" class="card-img-top" alt="...">
                            <div class="card-body d-flex flex-column">
                                <h5 class="card-title py-3 text-center">Card title</h5>
                                <p class="card-text">Some quick example text to build on the card title and make up the
                                    bulk of the card's content.</p>
                                <div class="col-12  mb-0 mt-auto" style="text-align: center;">
                                    <a href="#" class="btn btn-outline-dark">Go somewhere</a>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="col-md-12 py-5 my-2">
                <h1 class="text-center py-3">Here is another heading</h1>
                <p class="text-center py-3">Here are the Sub Description</p>
                <div class="row">
                    <div class="col-md-6 d-flex align-items-stretch">
                        <img src="../Assets/Image/Jeffrey-Beers-International-Park-Hyatts-Manhattan-Sky-Suite-1.jpg"
                            class="d-flex img-fluid" style="border-radius: 30px;" />
                    </div>
                    <div class="col-md-6 d-flex align-items-stretch">
                        <div class="textBox">
                            <h3 class="text-center py-3">
                                Our Hotel Booking website Advantage
                            </h3>
                            <p class="text-center py-3">
                                Book hotels that welcome your furry companions with open arms (and treats!). This
                                website can filter hotels based on pet-friendly amenities and even connect you with pet
                                sitting services at your destination.
                            </p>

                            <button class="text-center btn btn-outline-dark">Check Now</button>

                        </div>
                    </div>
                </div>
            </section>
    </div>
</asp:Content>
