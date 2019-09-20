using System;

namespace ProfitRobots.FXTS2LuaExecuter
{
    public class IndicatorProfile : Profile
    {
        #region Lua
        /// <summary>
        /// Gets the type of the required source of the indicator.
        /// </summary>
        /// <param name="requiredSource"></param>
        public void requiredSource(int requiredSource)
        {
            //ignore
        }

        /// <summary>
        /// Creates a new instance of the indicator.
        /// </summary>
        /// <param name="souce">The stream of prices or the output stream of other (not this) indicator. 
        /// You must pass either an instance of the bar_stream table in case the indicator requires 
        /// the core.Bar source (see the profile:requiredSource() method) or an instance of 
        /// the tick_stream table in the other case.</param>
        /// <param name="parameters">The instance of the parameters table. The table must be previously returned 
        /// by the profile:parameters() method and must be filled by the proper parameter's value. 
        /// Please note that each set of the parameters may be used for creating only one instance of the indicator.</param>
        public IndicatorInstance createInstance(TickStream souce, ProfileParameters parameters)
        {
            throw new NotImplementedException();
        }

        // profileLanguage Gets the language of the profile (Lua, JavaScript, C++ for Windows).
        // profileType Gets the type of the profile(Indicator, Strategy).
        #endregion
    }
}
