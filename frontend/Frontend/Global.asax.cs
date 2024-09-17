using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace HotelReservationSystem_Part1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute(
                "Default",
                "Default.aspx",
                "~/Common/Default.aspx"
                );
            RouteTable.Routes.MapPageRoute(
                "HotelDetails",
                "HotelDetails.aspx",
                "~/Common/HotelDetails.aspx"
                );
            RouteTable.Routes.MapPageRoute(
                "AllHotels",
                "AllHotels.aspx",
                "~/Common/AllHotels.aspx");

            
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}