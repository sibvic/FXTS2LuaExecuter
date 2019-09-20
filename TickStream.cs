namespace ProfitRobots.FXTS2LuaExecuter
{
    public class TickStream
    {
        //barSize The method returns the time frame of the stream periods.
        //date The method returns the date and time of the specified period.
        //first The method returns the index of the first period that contains data in the stream.
        //getDisplayPrecision The method returns the precision (a number of digits after the decimal point) of the stream values for displaying on a chart.
        //getPrecision The method returns the precision (a number of digits after the decimal point) of the stream values.
        //hasData The method checks whether the specified period of the stream has data.
        //instrument The method returns the name of the instrument the prices of which the stream provides.
        //isAlive The method checks whether the stream is subscribed for the updates, i.e.the stream is "alive".
        //isBar The method checks whether the stream is a bar stream.
        //isBid The method checks which prices (bid or ask) the stream provides.
        //name The method returns the name of the stream.
        //pipSize The method returns the smallest possible change of the instrument price.
        //serial The method returns the unique identifier of the specified period.
        //size The method returns the number of periods in the stream.
        //tick The method returns the value of the specified period.
    }
}
