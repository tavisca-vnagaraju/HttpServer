namespace HttpServer
{
    public class LeapYear
    {
        public bool IsLeapYear(int year)
        {
            if (year % 4 ==0 && year % 100 == 0)
            {
                return true;
            }
            else if (year % 400 == 0)
            {
                return true;
            }
            return false;
        }
    }
}