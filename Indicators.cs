namespace ProfitRobots.FXTS2LuaExecuter
{
    public class Indicators
    {
        string _path;
        public Indicators(string path)
        {
            _path = path;
        }

        //create Creates an instance of the indicator.

        /// <summary>
        /// Gets the indicator profile by the identifier.
        /// </summary>
        /// <param name="id">The indicator identifier.
        /// The indicator identifier is capitalized file name of the indicator without extension.
        /// For example, identifier of the indicator stored in file MyIndi.lua is "MYINDI".</param>
        /// <returns></returns>
        public IndicatorProfile findIndicator(string id)
        {
            var indicatorPath = System.IO.Path.Combine(_path, "indicators", "custom", id + ".lua");
            if (System.IO.File.Exists(indicatorPath))
                return new IndicatorProfile();
            return null;
        }
    }
}
