<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="AllHotels.aspx.cs" Inherits="HotelReservationSystem_Part1.Common.AllHotels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container-fluid h-100">
            <div class="col-md-12 mt-3 py-3 ">
                <div class="row justify-content-center align-items-center d-flex flex-row ">
                    <div class="col-md-3">
                        <input type="text" class="form-control " placeholder="Please Enter the location" />
                    </div>
                    <div class="col-md-2">
                        <input type="date" class="form-control " placeholder="check in date" />
                    </div>
                    <div class="col-md-2">
                        <input type="date" class="form-control " placeholder="Check out Date" />
                    </div>
                    <div class="col-md-3">
                        <div class="dropdown">
                            <button type="button" class="btn btn-outline-dark btn-sm dropdown-toggle my-2 py-2"
                                data-bs-toggle="dropdown" aria-expanded="false" data-bs-auto-close="outside">
                                No Of Guests
                            </button>
                            <div class="dropdown-menu p-4">
                                <div class="mb-3">
                                    <label for="exampleDropdownFormEmail2" class="form-label">Adult</label>
                                    <input type="range" class="form-range" min="1" max="5" id="customRange2">
                                </div>
                                <div class="mb-3">
                                    <label for="exampleDropdownFormPassword2" class="form-label">Children</label>
                                    <input type="range" class="form-range" min="1" max="5" id="customRange3">
                                </div>

                                <center><button type="submit"
                                        class="btn btn-outline-dark text-center my-2 py-2">Add</button>
                                </center>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <button class="btn btn-outline-dark " type="submit">Search</button>
                    </div>
                </div>
            </div>

        </div>
        <section class="col-md-12 mt-3">

            <div class="row d-flex align-items-stretch py-3">
                <div class="col-md-4 py-2 col-lg-3 filter-col">
                    <h3 class="text-center">Filters</h3>
                    <div class="col-md-12 my-2">
                        <div class="row justify-content-center align-items-center pt-4">
                            <div class="col-md-6 offset-md-6">
                                <a class="text-danger text-decoration-none" type="button">Clear All</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 my-2">
                        <div class="row justify-content-center align-items-center">
                            <div class="col-md-6 form-floating ">
                                <input class="form-control" min="0" id="floatingMin" type="number" />
                                <label for="floatingMin">Min price</label>
                            </div>
                            <div class="col-md-6 form-floating ">
                                <input class="form-control" min="0" id="floatingMax" type="number" />
                                <label for="floatingMax">Max price</label>
                            </div>
                        </div>
                        <div class="row my-2">
                            <p class="text-start py-2 text-black-50" style="font-weight: 900;">Categories</p>
                            <div class="col-md-12 border-bottom py-2">
                                <div class="form-check ">
                                    <input class="form-check-input" type="checkbox" value="" id="">
                                    <label class="form-check-label" for="">
                                        Luxury Rooms
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        Budget Rooms
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        Deluxe Rooms
                                    </label>
                                </div>
                            </div>

                        </div>
                        <div class="row my-2">
                            <p class="text-start py-2 text-black-50" style="font-weight: 900;">Accomdation Type</p>
                            <div class="col-md-12 border-bottom py-2">
                                <div class="form-check ">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        Dorms
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label" for="flexCheckChecked">
                                        Eco Hotel
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        Hostel
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        Suite
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked">
                                    <label class="form-check-label">
                                        Inn
                                    </label>
                                </div>
                            </div>

                        </div>
                        <div class="row my-2">
                            <p class="text-start py-2 text-black-50" style="font-weight: 900;">Hotel Facilities</p>
                            <div class="col-md-12 border-bottom py-2">
                                <div class="form-check ">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        WIFI
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label" for="flexCheckChecked">
                                        TV
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        AC
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="">
                                    <label class="form-check-label">
                                        Single bed
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked">
                                    <label class="form-check-label">
                                        Parking
                                    </label>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-md-8 col-lg-9 col-sm-12 main-col">
                    <div class="col-md-12 mt-3 py-2">
                        <div class="row justify-content-center align-items-center">
                            <!--sort by-->
                            <div class="col-md-12">
                                <div class="row justify-content-center align-items-center ">
                                    <div class="col-md-5 pt-1">
                                        <h5 class="text-start text-bold">Total 6 Basera's in Ayodhya</h5> 
                                     </div>
                                    <div class="col-md-1 pt-1">
                                        <div class="row">
                                            <div class="col-md-12 mt-3 offcanvas-filter">
                                                <button class="btn btn-outline-dark" type="button"
                                                    data-bs-toggle="offcanvas"
                                                    data-bs-target="#offcanvasWithBothOptions"
                                                    aria-controls="offcanvasWithBothOptions">Filters</button>

                                                <div class="offcanvas offcanvas-start" data-bs-scroll="true"
                                                    tabindex="-1" id="offcanvasWithBothOptions"
                                                    aria-labelledby="offcanvasWithBothOptionsLabel">
                                                    <div class="offcanvas-header">
                                                        <h3 class="offcanvas-title text-center"
                                                            id="offcanvasWithBothOptionsLabel">Filters</h3>
                                                        <button type="button" class="btn-close"
                                                            data-bs-dismiss="offcanvas" aria-label="Close"></button>
                                                    </div>
                                                    <div class="offcanvas-body">

                                                        <div class="col-md-12 my-2">
                                                            <div
                                                                class="row justify-content-center align-items-center pt-4">
                                                                <div class="col-md-6 offset-md-6">
                                                                    <a class="text-danger text-decoration-none"
                                                                        type="button">Clear All</a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 my-2">
                                                            <div
                                                                class="row justify-content-center align-items-center py-2">
                                                                <div class="col-md-6 form-floating">
                                                                    <input class="form-control " id="floatingMin"
                                                                        type="number" />
                                                                    <label for="floatingMin">Min price</label>
                                                                </div>
                                                                <div class="col-md-6 form-floating">
                                                                    <input class="form-control" id="floatingMax"
                                                                        type="number" />
                                                                    <label for="floatingMax">Max price</label>
                                                                </div>
                                                            </div>
                                                            <div class="row my-2">
                                                                <p class="text-start py-2 text-black-50"
                                                                    style="font-weight: 900;">Categories</p>
                                                                <div class="col-md-12 border-bottom py-2">
                                                                    <div class="form-check ">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="" id="">
                                                                        <label class="form-check-label" for="">
                                                                            Luxury Rooms
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            Budget Rooms
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            Deluxe Rooms
                                                                        </label>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="row my-2">
                                                                <p class="text-start py-2 text-black-50"
                                                                    style="font-weight: 900;">Accomdation Type</p>
                                                                <div class="col-md-12 border-bottom py-2">
                                                                    <div class="form-check ">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            Dorms
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label"
                                                                            for="flexCheckChecked">
                                                                            Eco Hotel
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            Hostel
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            Suite
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="" id="flexCheckChecked">
                                                                        <label class="form-check-label">
                                                                            Inn
                                                                        </label>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="row my-2">
                                                                <p class="text-start py-2 text-black-50"
                                                                    style="font-weight: 900;">Hotel Facilities</p>
                                                                <div class="col-md-12 border-bottom py-2">
                                                                    <div class="form-check ">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            WIFI
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label"
                                                                            for="flexCheckChecked">
                                                                            TV
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            AC
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="">
                                                                        <label class="form-check-label">
                                                                            Single bed
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-check">
                                                                        <input class="form-check-input" type="checkbox"
                                                                            value="" id="flexCheckChecked">
                                                                        <label class="form-check-label">
                                                                            Parking
                                                                        </label>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                   
                                    <div class="col-md-6 pt-1">
                                        <div class="row offset-md-10">
                                            <div class="dropdown">
                                                <button class="btn btn-outline-dark dropdown-toggle" type="button"
                                                    data-bs-toggle="dropdown" aria-expanded="false">
                                                    Sort By
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li><button class="dropdown-item" type="button">Popularity</button>
                                                    </li>
                                                    <li><button class="dropdown-item" type="button">Ratings</button>
                                                    </li>
                                                    <li><button class="dropdown-item" type="button">Price Low To
                                                            High</button></li>
                                                    <li><button class="dropdown-item" type="button">Price High To
                                                            Low</button></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- <label class="col-md-2 d-flex">Sort By&nbsp;: </label>
                                        <button type="button"
                                            class="btn btn-sm btn-outline-dark col-md-2 my-2 py-2 mx-2">Popularity</button>
                                        <button type="button"
                                            class="btn btn-sm btn-outline-dark col-md-2 my-2 py-2 mx-2">Price Low to
                                            High</button>
                                        <button type="button"
                                            class="btn btn-sm btn-outline-dark col-md-2 my-2 py-2 mx-2">Price High to
                                            Low</button>
                                        <button type="button"
                                            class="btn btn-sm btn-outline-dark col-md-2 my-2 py-2 mx-2">Recommended</button> -->

                                </div>
                            </div>
                        </div>
                    </div>
                    <!--card columns-->
                    <div class="col-md-12 my-3 py-2">
                        <div class="col-md-12 py-2 px-2">
                            <div class="card" id="card1">
                                <div class="row d-flex align-items-stretch ">
                                    <div class="col-md-7">
                                        <div class="row d-flex align-items-stretch g-1 container-images">
                                            <div class="col-md-9 d-flex container-main">
                                                <img src="../Assets/Image/images (1).jpeg"
                                                    class="d-flex img-fluid my-2 mx-2 main-image"
                                                    style="border-radius: 20px;" />
                                            </div>
                                            <div class="col-md-3 container-side">
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images (1).jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images.jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/homestay-hotel.jpg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-5  d-flex flex-column">
                                        <div class="col-md-12 contaier-hotelDetails">
                                            <h5 class="text-center py-2 title-hotel">
                                                Kohinoor Palace
                                            </h5>
                                            <p class="py-2 text-hotel-address">Address of the Hotel with landmark
                                            </p>
                                            <div class="col-md-12 col-sm-12">
                                                <div class="row-badge">
                                                    <div class="col-md-4 col-sm-4 py-3">
                                                        <span class="badge text-bg-success bd-ratings">
                                                            5&nbsp;Ratings
                                                        </span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Rating">
                                                        <p class="text-black-50" style="font-size: 13px;">(1
                                                            Ratings)
                                                        </p>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Condition">
                                                        <p class="text-black-50" style="font-size: 13px;">Condition
                                                            State</p>
                                                    </div>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 mt-auto mb-0 py-3">
                                            <div class="row justify-content-center align-items-center d-flex">
                                                <div class="col-md-4 py-2">
                                                    <h5 class="text-center" style="font-size: 15px;">
                                                        &#8377;&nbsp;20000</h5>
                                                </div>
                                                <div class="col-md-4 py-2 btnViewHotelDetails">
                                                    <button class="btn btn-outline-dark ">View
                                                        Details</button>
                                                </div>
                                                <div class="col-md-4 py-2 btnBookHotel">
                                                    <button class="btn btn-outline-dark ">Book
                                                        Now</button>
                                                </div>
                                                <!-- <div class="col-md-8">
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                               
                                                            </div>
                                                        </div>
                                                    </div> -->

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-12 my-3 py-2">
                        <div class="col-md-12 py-2 px-2">
                            <div class="card" id="card2">
                                <div class="row d-flex align-items-stretch ">
                                    <div class="col-md-7">
                                        <div class="row d-flex align-items-stretch g-1 container-images">
                                            <div class="col-md-9 d-flex container-main">
                                                <img src="../Assets/Image/images (1).jpeg"
                                                    class="d-flex img-fluid my-2 mx-2 main-image"
                                                    style="border-radius: 20px;" />
                                            </div>
                                            <div class="col-md-3 container-side">
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images (1).jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images.jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/homestay-hotel.jpg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-5  d-flex flex-column">
                                        <div class="col-md-12 contaier-hotelDetails">
                                            <h5 class="text-center py-2 title-hotel">
                                                Kohinoor Palace
                                            </h5>
                                            <p class="py-2 text-hotel-address">Address of the Hotel with landmark
                                            </p>
                                            <div class="col-md-12 col-sm-12">
                                                <div class="row-badge">
                                                    <div class="col-md-4 col-sm-4 py-3">
                                                        <span class="badge text-bg-success bd-ratings">
                                                            5&nbsp;Ratings
                                                        </span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Rating">
                                                        <p class="text-black-50" style="font-size: 13px;">(1
                                                            Ratings)
                                                        </p>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Condition">
                                                        <p class="text-black-50" style="font-size: 13px;">Condition
                                                            State</p>
                                                    </div>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 mt-auto mb-0 py-3">
                                            <div class="row justify-content-center align-items-center d-flex">
                                                <div class="col-md-4 py-2">
                                                    <h5 class="text-center" style="font-size: 15px;">
                                                        &#8377;&nbsp;20000</h5>
                                                </div>
                                                <div class="col-md-4 py-2 btnViewHotelDetails">
                                                    <button class="btn btn-outline-dark ">View
                                                        Details</button>
                                                </div>
                                                <div class="col-md-4 py-2 btnBookHotel">
                                                    <button class="btn btn-outline-dark ">Book
                                                        Now</button>
                                                </div>
                                                <!-- <div class="col-md-8">
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                               
                                                            </div>
                                                        </div>
                                                    </div> -->

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-12 my-3 py-2">
                        <div class="col-md-12 py-2 px-2">
                            <div class="card" id="card3">
                                <div class="row d-flex align-items-stretch ">
                                    <div class="col-md-7">
                                        <div class="row d-flex align-items-stretch g-1 container-images">
                                            <div class="col-md-9 d-flex container-main">
                                                <img src="../Assets/Image/images (1).jpeg"
                                                    class="d-flex img-fluid my-2 mx-2 main-image"
                                                    style="border-radius: 20px;" />
                                            </div>
                                            <div class="col-md-3 container-side">
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images (1).jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images.jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/homestay-hotel.jpg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-5  d-flex flex-column">
                                        <div class="col-md-12 contaier-hotelDetails">
                                            <h5 class="text-center py-2 title-hotel">
                                                Kohinoor Palace
                                            </h5>
                                            <p class="py-2 text-hotel-address">Address of the Hotel with landmark
                                            </p>
                                            <div class="col-md-12 col-sm-12">
                                                <div class="row-badge">
                                                    <div class="col-md-4 col-sm-4 py-3">
                                                        <span class="badge text-bg-success bd-ratings">
                                                            5&nbsp;Ratings
                                                        </span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Rating">
                                                        <p class="text-black-50" style="font-size: 13px;">(1
                                                            Ratings)
                                                        </p>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Condition">
                                                        <p class="text-black-50" style="font-size: 13px;">Condition
                                                            State</p>
                                                    </div>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 mt-auto mb-0 py-3">
                                            <div class="row justify-content-center align-items-center d-flex">
                                                <div class="col-md-4 py-2">
                                                    <h5 class="text-center" style="font-size: 15px;">
                                                        &#8377;&nbsp;20000</h5>
                                                </div>
                                                <div class="col-md-4 py-2 btnViewHotelDetails">
                                                    <button class="btn btn-outline-dark ">View
                                                        Details</button>
                                                </div>
                                                <div class="col-md-4 py-2 btnBookHotel">
                                                    <button class="btn btn-outline-dark ">Book
                                                        Now</button>
                                                </div>
                                                <!-- <div class="col-md-8">
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                               
                                                            </div>
                                                        </div>
                                                    </div> -->

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-12 my-3 py-2">
                        <div class="col-md-12 py-2 px-2">
                            <div class="card" id="card4">
                                <div class="row d-flex align-items-stretch ">
                                    <div class="col-md-7">
                                        <div class="row d-flex align-items-stretch g-1 container-images">
                                            <div class="col-md-9 d-flex container-main">
                                                <img src="../Assets/Image/images (1).jpeg"
                                                    class="d-flex img-fluid my-2 mx-2 main-image"
                                                    style="border-radius: 20px;" />
                                            </div>
                                            <div class="col-md-3 container-side">
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images (1).jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images.jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/homestay-hotel.jpg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-5  d-flex flex-column">
                                        <div class="col-md-12 contaier-hotelDetails">
                                            <h5 class="text-center py-2 title-hotel">
                                                Kohinoor Palace
                                            </h5>
                                            <p class="py-2 text-hotel-address">Address of the Hotel with landmark
                                            </p>
                                            <div class="col-md-12 col-sm-12">
                                                <div class="row-badge">
                                                    <div class="col-md-4 col-sm-4 py-3">
                                                        <span class="badge text-bg-success bd-ratings">
                                                            5&nbsp;Ratings
                                                        </span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Rating">
                                                        <p class="text-black-50" style="font-size: 13px;">(1
                                                            Ratings)
                                                        </p>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Condition">
                                                        <p class="text-black-50" style="font-size: 13px;">Condition
                                                            State</p>
                                                    </div>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 mt-auto mb-0 py-3">
                                            <div class="row justify-content-center align-items-center d-flex">
                                                <div class="col-md-4 py-2">
                                                    <h5 class="text-center" style="font-size: 15px;">
                                                        &#8377;&nbsp;20000</h5>
                                                </div>
                                                <div class="col-md-4 py-2 btnViewHotelDetails">
                                                    <button class="btn btn-outline-dark ">View
                                                        Details</button>
                                                </div>
                                                <div class="col-md-4 py-2 btnBookHotel">
                                                    <button class="btn btn-outline-dark ">Book
                                                        Now</button>
                                                </div>
                                                <!-- <div class="col-md-8">
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                               
                                                            </div>
                                                        </div>
                                                    </div> -->

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-12 my-3 py-2">
                        <div class="col-md-12 py-2 px-2">
                            <div class="card" id="card5">
                                <div class="row d-flex align-items-stretch ">
                                    <div class="col-md-7">
                                        <div class="row d-flex align-items-stretch g-1 container-images">
                                            <div class="col-md-9 d-flex container-main">
                                                <img src="../Assets/Image/images (1).jpeg"
                                                    class="d-flex img-fluid my-2 mx-2 main-image"
                                                    style="border-radius: 20px;" />
                                            </div>
                                            <div class="col-md-3 container-side">
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images (1).jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/images.jpeg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                                <div class="col-md-12 py-1">
                                                    <img src="../Assets/Image/homestay-hotel.jpg" class="side-img"
                                                        style="border-radius: 20px;" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-5  d-flex flex-column">
                                        <div class="col-md-12 contaier-hotelDetails">
                                            <h5 class="text-center py-2 title-hotel">
                                                Kohinoor Palace
                                            </h5>
                                            <p class="py-2 text-hotel-address">Address of the Hotel with landmark
                                            </p>
                                            <div class="col-md-12 col-sm-12">
                                                <div class="row-badge">
                                                    <div class="col-md-4 col-sm-4 py-3">
                                                        <span class="badge text-bg-success bd-ratings">
                                                            5&nbsp;Ratings
                                                        </span>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Rating">
                                                        <p class="text-black-50" style="font-size: 13px;">(1
                                                            Ratings)
                                                        </p>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 py-3 txt-Condition">
                                                        <p class="text-black-50" style="font-size: 13px;">Condition
                                                            State</p>
                                                    </div>


                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 mt-auto mb-0 py-3">
                                            <div class="row justify-content-center align-items-center d-flex">
                                                <div class="col-md-4 py-2">
                                                    <h5 class="text-center" style="font-size: 15px;">
                                                        &#8377;&nbsp;20000</h5>
                                                </div>
                                                <div class="col-md-4 py-2 btnViewHotelDetails">
                                                    <button class="btn btn-outline-dark ">View
                                                        Details</button>
                                                </div>
                                                <div class="col-md-4 py-2 btnBookHotel">
                                                    <button class="btn btn-outline-dark ">Book
                                                        Now</button>
                                                </div>
                                                <!-- <div class="col-md-8">
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                               
                                                            </div>
                                                        </div>
                                                    </div> -->

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!--columns-->
                </div>
            </div>

        </section>
   <script type="text/javascript">
       const setImageMain = (cardID, newImageSrc) => {
           const mainImage = document.querySelector(`#${cardID} .main-image`);
           console.log(mainImage);
           if (mainImage) {
               mainImage.src = newImageSrc;
           }
       };

       document.querySelectorAll('.side-img').forEach(sideImage => {
           sideImage.addEventListener('click', function () {
               const cardID = this.closest('.card').id;
               const newImageSrc = this.src;
               console.log(cardID);
               setImageMain(cardID, newImageSrc);
           });
       });
   </script>
</asp:Content>
