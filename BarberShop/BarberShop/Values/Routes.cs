namespace BarberShop.Values
{
    public static class Routes
    {
        public static string LoginApiRoute = "http://localhost:2525/api/login";
        public static string RegisterApiRoute = "http://localhost:2525/api/User";
        public static string UpdateApiRoute = "http://localhost:2525/api/User/ChangeInformation";
        public static string UpdatePasswordApiRoute = "http://localhost:2525/api/user/ChangePassword";
        public static string GetOrderTypes = "http://localhost:2525/api/OrderType";
        public static string GetEmployeeList = "http://localhost:2525/api/User";
        public static string GetScheme = "http://localhost:2525/api/Booking";
        public static string PostOrder = "http://localhost:2525/api/Booking";
        public static string GetLatestOrderInfoRoute = "http://localhost:2525/api/Order/GetLatestOrders";
        public static string DeleteOrder = "http://localhost:2525/api/Order";
        public static string GetAllOrderInfoRoute = "http://localhost:2525/api/Order/GetAllOrders";
        public static string GetAllSchedulesRoute = "http://localhost:2525/api/Schedule";
        public static string PostNewScheduleRoute = "http://localhost:2525/api/Schedule";
        public static string GetAllAbsencesFromSchedule = "http://localhost:2525/api/Absence";
        public static string PostNewAbsence = "http://localhost:2525/api/Absence";
        public static string GetAllAbsenceTypes = "http://localhost:2525/api/AbsenceType";
        public static string GetOrdersByDate = "http://localhost:2525/api/Order/GetOrdersByDate";

    }
}