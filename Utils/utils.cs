public static class Utils
{
    public static int DateTimeToInt(DateTime dateTime)
    {
        return (int)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
    }

    public static DateTime IntToDateTime(int secondsSince1970)
    {
        return new DateTime(1970, 1, 1).AddSeconds(secondsSince1970);
    }

}
