<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Frontend.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mx-2 px-2">
        <h1 class="mb-2 pb-2" style="font-size: 30px !important; font-weight: 600 !important; color: black !important; /*font-family: 'Doto', sans-serif !important; */
font-optical-sizing: auto !important;">Dashboard</h1>
        <section id="topCard" class="row justify-content-center align-items-stretch text-white d-flex mt-3">
            <div class="col-md-3 d-flex">
                <div class="card flex-fill py-2 px-2" style="box-shadow: 0 4px 12px 0 rgba(255, 79, 30, 0.4) !important; background-color: #ff4f1e !important; color: white !important; border-radius: 20px !important;">
                    <div class="card-body d-flex flex-column">
                        <div class="row align-items-center">
                            <div class="col-2 px-2 py-2 justify-content-center" style="background-color: white !important; color: #ff4f1e; border-radius: 20px;">
                                <div class="row justify-content-center align-items-center">
                                    <i class="fa-solid fa-building-circle-check"></i>
                                </div>
                            </div>
                            <div class="col-8">
                                <p class="text-center " style="font-size: 20px !important; font-weight: 600 !important; color: white !important; font-family: 'Doto', sans-serif !important; font-optical-sizing: auto !important; text-align: center !important;">
                                    1000
                                </p>
                            </div>
                        </div>
                        <p class="text-center mt-auto" style="font-size: 15px">Total Check In's</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3 d-flex">
                <div class="card flex-fill py-2 px-2" style="box-shadow: 0 4px 12px 0 rgba(109, 210, 142, 0.4) !important; background-color: #6dd28e !important; color: white !important; border-radius: 20px !important;">
                    <div class="card-body d-flex flex-column">
                        <div class="row align-items-center">
                            <div class="col-2 px-2 py-2 justify-content-center" style="background-color: white !important; color: #6dd28e; border-radius: 20px;">
                                <div class="row justify-content-center align-items-center">
                                    <i class="fa-solid fa-calendar"></i>
                                </div>
                            </div>
                            <div class="col-8">
                                <p class="text-center " style="font-size: 20px !important; font-weight: 600 !important; color: white !important; font-family: 'Doto', sans-serif !important; font-optical-sizing: auto !important; text-align: center !important;">
                                    23232
                                </p>
                            </div>
                        </div>
                        <p class="text-center mt-auto" style="font-size: 15px">Total Reservations</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3 d-flex">
                <div class="card flex-fill py-2 px-2" style="box-shadow: 0 4px 12px 0 rgba(89, 115, 255, 0.3) !important; background-color: #5973ff !important; color: white !important; border-radius: 20px !important;">
                    <div class="card-body d-flex flex-column">
                        <div class="row align-items-center">
                            <div class="col-2 px-2 py-2 justify-content-center" style="background-color: white !important; color: #5973ff; border-radius: 20px;">
                                <div class="row justify-content-center align-items-center">
                                    <i class="fa-solid fa-credit-card"></i>
                                </div>
                            </div>
                            <div class="col-8">
                                <p class="text-center " style="font-size: 20px !important; font-weight: 600 !important; color: white !important; font-family: 'Doto', sans-serif !important; font-optical-sizing: auto !important; text-align: center !important;">
                                    23232
                                </p>
                            </div>
                        </div>
                        <p class="text-center mt-auto" style="font-size: 15px">Total Payments</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3 d-flex">
                <div class="card flex-fill py-2 px-2" style="box-shadow: 0 4px 12px 0 rgba(56, 179, 255, 0.3) !important; background-color: #38b3ff !important; color: white !important; border-radius: 20px !important;">
                    <div class="card-body d-flex flex-column">
                        <div class="row align-items-center">
                            <div class="col-2 px-2 py-2 justify-content-center" style="background-color: white !important; color: #38b3ff; border-radius: 20px;">
                                <div class="row justify-content-center align-items-center">
                                    <i class="fa-solid fa-money-bill-trend-up"></i>
                                </div>
                            </div>
                            <div class="col-8">

                                <p class="text-center" style="font-size: 20px !important; font-weight: 600 !important; color: white !important; font-family: 'Doto', sans-serif !important; font-optical-sizing: auto !important; text-align: center !important;">
                                    ₹ 100023232
                                </p>
                            </div>
                        </div>
                        <p class="text-center mt-auto" style="font-size: 15px">Total Earnings</p>
                    </div>
                </div>
            </div>
        </section>
        <section id="topChart" class="row justify-content-center align-items-stretch text-white d-flex my-2">

            <h2 class="text-center px-2 py-3">Today's Report </h2>
            <div class="col-6 d-flex">
                <div class="card flex-fill">
                    <div class="card-body d-flex flex-column">
                        <div id="Barchart" class="text-black">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-6 d-flex">
                <div class="card flex-fill">
                    <div class="card-body d-flex flex-column">
                        <div id="pieChart"></div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var options_bar = {
                chart: {
                    type: 'bar'
                },
                series: [{
                    name: 'sales',
                    data: [30, 40, 45, 50, 49, 60, 70, 91, 125],
                }],
                xaxis: {
                    categories: ['1991', '1992', '1993', '1994', '1995', '1996', '1997', '1998', '1999'], // Labels for each bar
                },
                plotOptions: {
                    bar: {
                        distributed: true, // Ensures that each bar gets a different color
                    }
                },
                colors: ['#ff4f1e', '#6dd28e', '#5973ff', '#38b3ff', '#ff6347', '#7b68ee', '#20b2aa', '#ff1493', '#ff4500'], // Individual colors for each bar
                dataLabels: {
                    enabled: true,
                    formatter: function (val, opts) {
                        return val; // Optional: shows the value on top of each bar
                    }
                }
            }

            var chart_bar = new ApexCharts(document.querySelector("#Barchart"), options_bar);
            chart_bar.render();

            // Pie Chart
            var optionsPie = {
                chart: {
                    type: 'pie',
                },
                series: [300, 50, 100],
                labels: ['Red', 'Blue', 'Yellow', 'Dunno'],
                colors: ['#ff4f1e', '#5973ff', '#6dd28e', '#38b3ff']
                //title: {
                //    text: 'Pie Chart Example',
                //    align: 'center',
                //},
            }

            var pieChart = new ApexCharts(document.querySelector("#pieChart"), optionsPie);
            pieChart.render();
        })
    </script>
</asp:Content>
