<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="HotelReservationSystem_Part1.Common.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var options_bar = {
                chart: {
                    type: 'bar'
                },
                series: [{
                    name: 'sales',
                    data: [30, 40, 45, 50, 49, 60, 70, 91, 125],
                    colors: ['#008FFB', '#00E396', '#FEB019', '#FF4560', '#775DD0', '#19D8F0', '#F2711C']
                }],
                xaxis: {
                    categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999]
                },
                
            }

            var chart_bar = new ApexCharts(document.querySelector("#Barchart"), options_bar);

            chart_bar.render();
            // Pie Chart
            var optionsPie = {
                chart: {
                    type: 'pie',
                },
                series: [300, 50, 100],
                labels: ['Red', 'Blue', 'Yellow'],
                colors: ['#FF6384', '#36A2EB', '#FFCE56'],
                //title: {
                //    text: 'Pie Chart Example',
                //    align: 'center',
                //},
            }

            var pieChart = new ApexCharts(document.querySelector("#pieChart"), optionsPie);
            pieChart.render();
        })
    </script>
    <div class="container-fluid my-5">
        <div class="row justify-content-center align-items-stretch">
            <!-- First Card -->
            <div class="col-md-6 mb-3">
                <div class="card h-100">
                    <div class="card-body">
                        <div class="row justify-content-center align-items-center py-3">
                            <div class="col-md-12">
                                <div class="d-flex flex-column">
                                    <div class="col-md-12">
                                       <center><img src="../Assets/Image/logo/Basera.png" class="border-1 d-flex shadow-lg"
                                            style="border-radius: 50%; height: 200px; width: 200px;" /></center> 
                                    </div>
                                    <div class="col-md-12 pt-5 mt-1">
                                        <h4 class="text-center" style="text-align
    :center
    ">Akshat Dwivedi</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="pt-5 px-5" style="text-align: justify">
                            <!-- Card details here -->
                            <div class="row">
                                <div class="col-md-6">
                                    <h5 class="text-start" style="font-size: 16px">Email</h5>
                                </div>
                                <div class="col-md-6">
                                    <asp:label CssClass="form-label text-start text-black-50" runat="server" ID="lblEmail" style="font-size: 16px">
                                       
                                    </asp:label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <h5 class="text-start" style="font-size: 16px">Phone No</h5>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label CssClass="form-label text-start text-black-50" ID="lblMobileNo" runat="server" style="font-size: 16px">
                                      
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <h5 class="text-start" style="font-size: 16px">City</h5>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label  CssClass="form-label text-start text-black-50" ID="lblCity" runat="server" style="font-size: 16px"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <h5 class="text-start" style="font-size: 16px">State</h5>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblState" runat="server" class="form-label text-start text-black-50" style="font-size: 16px"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <h5 class="text-start" style="font-size: 16px">Address</h5>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblAddress" runat="server" class="form-label text-start text-black-50" style="font-size: 16px"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Second Card -->
            <div class="col-md-6 mb-3">
                <div class="h-100">
                    <div class="card-body">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row p-3">
                                        <h5 class="text-center">Booking History</h5>
                                    </div>
                                    <div class="row p-5">
                                        <div class="col-12">
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th scope="col">SrNo</th>
                                                        <th scope="col">First</th>
                                                        <th scope="col">Last</th>
                                                        <th scope="col">Handle</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <th scope="row">1</th>
                                                        <td>Mark</td>
                                                        <td>Otto</td>
                                                        <td>@mdo</td>
                                                    </tr>
                                                    <tr>
                                                        <th scope="row">2</th>
                                                        <td>Jacob</td>
                                                        <td>Thornton</td>
                                                        <td>@fat</td>
                                                    </tr>
                                                    <tr>
                                                        <th scope="row">3</th>
                                                        <td colspan="2">Larry the Bird</td>
                                                        <td>@twitter</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-md-6">
                                    <div class="card h-100">
                                        <div class="card-body">
                                            <h5 class="text-center">
                                                Basera
                                            </h5>
                                           <div id="Barchart">

                                           </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="card h-100">
                                        <div class="card-body">
                                            <h5 class="text-center">Overview</h5>
                                            <div class="col-md-12">
                                                <div class="row">
     <div id="pieChart"></div>
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
        </div>
    </div>


</asp:Content>
