namespace ProfitRobots.FXTS2LuaExecuter
{

    public class IndicatorInstance
    {
        public string Name { get; private set; }

        #region Lua
        public IndicatorProfile profile { get; internal set; }

        /// <summary>
        /// The property returns the parameters of the indicator.
        /// </summary>
        public ProfileParameters parameters { get; internal set; }

        /// <summary>
        /// The property returns the source stream of the indicator.
        /// </summary>
        public TickStream source { get; internal set; }

        /// <summary>
        /// The method sets the name of the indicator instance.
        /// </summary>
        /// <param name="name"></param>
        public void name(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The method adds an output stream to the indicator.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="streamType"></param>
        /// <param name="name"></param>
        /// <param name="label"></param>
        /// <param name="color"></param>
        /// <param name="first"></param>
        public void addStream(string id, int streamType, string name, string label, int color, int first)
        {
            //ignore
        }

        //addCopyStream The method creates a copy of the specified output stream.The copy is shifted against the original stream horizontally and vertically by the specified levels.
        //addInternalStream The method adds an output stream for the indicator internal purposes.

        //addViewBar The method adds a period into the output streams of the the view indicator.
        //createCandleGroup The method groups four or five output streams into a candle.
        //createChannelGroup The method groups two output streams into a channel.
        //createFromToBarGroup The method groups two output streams into a from/to bar.
        //createTextOutput The method adds an text output stream to the indicator.
        //drawOnMainChart The method notifies the host application that the indicator is an owner drawn indicator and it uses the main chart area.
        //initView The method initializes the output stream of a view indicator.
        //ownerDrawn The method notifies the host application that the indicator is an owner drawn indicator.
        //setLabelColor The method sets the color of the indicator label.
        //updateFrom The method forces recalculation of the indicator output streams starting at the specified period.
        #endregion
    }
}
