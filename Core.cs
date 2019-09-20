using System;
using System.Collections.Generic;
using System.Text;

namespace ProfitRobots.FXTS2LuaExecuter
{

    public class Core
    {
        private readonly string _path;
        private readonly Colors _colors;
        public Core(string path)
        {
            _path = path;
            indicators = new Indicators(path);
            _colors = new Colors();
        }

        #region For indicator:requiredSource
        /// <summary>
        /// The type of the indicator required source or of the output.
        /// </summary>
        public int Bar { get; set; } = 0;
        /// <summary>
        /// The type of the indicator required source.
        /// </summary>
        public int Tick { get; set; } = 1;
        #endregion

        #region For indicator:type
        /// <summary>
        /// The type of the indicator.
        /// </summary>
        public int Indicator { get; set; } = 0;

        /// <summary>
        /// The type of the indicator.
        /// </summary>
        public int Oscillator { get; set; } = 1;

        /// <summary>
        /// The type of the indicator.
        /// </summary>
        public int View { get; set; } = 2;
        #endregion

        /// <summary>
        /// Gets the path to lua5.1.dll
        /// </summary>
        public string app_path()
        {
            return _path;
        }

        #region Parameters flag
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_ALLOW_TRADE => (int)ParameterFlag.AllowTrade;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_BARPERIODS => (int)ParameterFlag.BarPeriods;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_BARPERIODS_EDIT => (int)ParameterFlag.BarPeriodsEdit;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_BIDASK => (int)ParameterFlag.BidAsk;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_DATE => (int)ParameterFlag.Date;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_DATE_OR_NULL => (int)ParameterFlag.DateOrNull;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_DATETIME => (int)ParameterFlag.DateTime;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_DATETIME_OR_NULL => (int)ParameterFlag.DateOrNull;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_EMAIL => (int)ParameterFlag.Email;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_INDICATOR => (int)ParameterFlag.Indicator;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_INSTRUMENTS => (int)ParameterFlag.Instruments;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_LEVEL_STYLE => (int)ParameterFlag.LevelStyle;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_LINE_STYLE => (int)ParameterFlag.LineStyle;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_ONLYINDICATORS => (int)ParameterFlag.OnlyIndicators;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_ONLYOSCILLATORS => (int)ParameterFlag.OnlyOscillators;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_ORDER => (int)ParameterFlag.Order;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_PERIODS => (int)ParameterFlag.Periods;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_PERIODS_EDIT => (int)ParameterFlag.PeriodsEdit;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_PRICE => (int)ParameterFlag.Price;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_SOUND => (int)ParameterFlag.Sound;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_STRATEGY => (int)ParameterFlag.Strategy;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_TRADE => (int)ParameterFlag.Trade;
        /// <summary>
        /// The parameter behavior flag.
        /// </summary>
        public int FLAG_ACCOUNT => (int)ParameterFlag.Account;
        #endregion

        #region For strategy:type
        /// <summary>
        /// The type of the strategy.
        /// </summary>
        public int Signal => 1;
        /// <summary>
        /// The type of the strategy.
        /// </summary>
        public int Strategy => 2;
        /// <summary>
        /// The type of the strategy.
        /// </summary>
        public int Both => 3;
        #endregion

        /// <summary>
        /// Creates the color from the red, green, and blue components.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int rgb(int r, int g, int b)
        {
            return 0;
        }

        /// <summary>
        /// The indicator manager.
        /// </summary>
        public Indicators indicators { get; private set; }

        /// <summary>
        /// Creates an color table
        /// </summary>
        public Colors colors()
        {
            return _colors;
        }

        /// <summary>
        /// Click creation pattern
        /// </summary>
        public int Click => 1;
        /// <summary>
        /// DoubleClick creation pattern
        /// </summary>
        public int DoubleClick => 2;

        /// <summary>
        /// DragClick creation pattern
        /// </summary>
        public int DragClick => 3;

        /// <summary>
        /// Returns the current local date and time.
        /// </summary>
        /// <returns></returns>
        public double now()
        {
            return DateTime.Now.ToOADate();
        }

        public class DateTable
        {
            public int month { get; set; }
            public int day { get; set; }
            public int year { get; set; }
            public int hour { get; set; }
            public int min { get; set; }
            public int sec { get; set; }
            public int wday { get; set; }
        }

        /// <summary>
        /// Converts the date with a number format into the table.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTable dateToTable(double date)
        {
            var fulldate = DateTime.FromOADate(date);
            return new DateTable()
            {
                year = fulldate.Year,
                month = fulldate.Month,
                day = fulldate.Day,
                hour = fulldate.Hour,
                min = fulldate.Minute,
                sec = fulldate.Second,
                wday = (int)fulldate.DayOfWeek
            };
        }

        //host The host application.
        //crosses Checks whether one stream crosses the other stream in any direction at the specified position.
        //crossesOver Checks whether one stream crosses over the other stream at the specified position.
        //crossesOverOrTouch Checks whether one stream crosses over or touches the other stream at the specified position.
        //crossesUnder Checks whether one stream crosses under the other stream at the specified position.
        //crossesUnderOrTouch Checks whether one stream crosses under or touches the other stream at the specified position.
        //date Creates date value.
        //datetime Creates date and time value.
        //drawLine Draws the line in the output stream.
        //eraseStream Sets no data to the specified range of the output stream.
        //findDate Searches in the price stream for the specified date.
        //formatDate Formats date/time into a string.
        //getcandle Gets the begin and end of the candle to which the specified date belongs.
        //isnontrading Checks whether the specified date and time is the regular non-trading hours.
        //makeHttpLoader Creates an HTTP reader.
        //parseCsv Parses comma-separated values.
        //range Creates the range table for the statistics methods using the 'from' and 'to' indexes.
        //rangeFrom Creates the range table for the statistics methods using the 'from' index and the size of the range.
        //rangeTo Creates the range table for the statistics methods using the 'to' index and the size of the range.
        //requires Checks whether the version of indicator core is correct.
        //tableToDate Converts the table into the date with a number format.
        //touches Checks whether one stream touches the other stream at the specified position.
        //valuemap Creates a value map.
        //version Returns the version of indicator => 0;//
        //ASYNC_REDRAW The flag indicating that the indicator must be redrawn after async notification.
        //COLOR_BACKGROUND The identifier of the color (default color of chart background)
        //COLOR_CUSTOMLEVEL The identifier of the color(default color of custom level lines)
        //COLOR_DOWNCANDLE The identifier of the color(default color of descending candles)
        //COLOR_LABEL The identifier of the color(default color of labels)
        //COLOR_LINE The identifier of the color(default color of lines)
        //COLOR_UPCANDLE The identifier of the color(default color of ascending candles)
        //CR_BOTTOM The type of the label coordinate.
        //CR_CENTER The type of the label coordinate.
        //CR_CHART The type of the label coordinate.
        //CR_LEFT The type of the label coordinate.
        //CR_RIGHT The type of the label coordinate.
        //CR_TOP The type of the label coordinate.
        //Dot The type of the indicator output.
        //H_Center The horizonal alignment of a label.
        //H_Left The horizonal alignment of a label.
        //H_Right The horizonal alignment of a label.
        //ILanguageServiceIndicator The type of the profile(Indicator).
        //ILanguageServiceJs The language of the profile(JavaScript).
        //ILanguageServiceLua The language of the profile(Lua).
        //ILanguageServiceNativeWin The language of the profile(C++ for Windows).
        //ILanguageServiceStrategy The type of the profile(Strategy).
        //ILanguageServiceUnknownLanguage The language of the profile(Undefined).
        //ILanguageServiceUnknownType The type of the profile(Undefined).
        //Line The type of the indicator output.
        //LINE_DASH The line style (dashed line).
        //LINE_DASHDOT The line style (dash-dotted line).
        //LINE_DOT The line style(dotted line).
        //LINE_NONE The line style(invisible line).
        //LINE_SOLID The line style(solid line).
        //OWNER_ADDITIONAL_AREA The indicator is applied on an additional area.
        //OWNER_INTERNAL The indicator is included in another indicator or strategy.
        //OWNER_MAIN_AREA The indicator is applied on the main chart area.
        //OWNER_UNKNOWN The owner is unknown e.g.the command is executed in the Prepare() function while the indicator is not added on a chart yet.
        //TZ_EST Time zone (New York time).
        //TZ_FINANCIAL The financial time time zone.
        //TZ_GMT Time zone (Universal Coordinated Time).
        //TZ_LOCAL The user local time zone.
        //TZ_SERVER The time zone of the server.
        //TZ_TS The time zone chosen to show dates in the host application.
        //UpdateAll Indicator update mode.
        //UpdateLast Indicator update mode.
        //UpdateNew Indicator Update mode.
        //V_Bottom The vertical alignment of a label.
        //V_Center The vertical alignment of a label.
        //V_Top The vertical alignment of a label.
    }
}
