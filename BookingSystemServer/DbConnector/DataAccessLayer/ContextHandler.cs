namespace DbConnector.DataAccessLayer
{
    public class ContextHandler
    {
        public object GetContext()
        {
            return new BookingContext();
        } 
    }
}