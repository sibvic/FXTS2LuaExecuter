namespace ProfitRobots.FXTS2LuaExecuter
{
    public class DoubleProfileParameter : ProfileParameter
    {
        public double Value { get; set; }
        public double Default { get; set; }

        public override ProfileParameter Clone()
        {
            var clone = new DoubleProfileParameter()
            {
                Value = Value,
                Default = Default
            };
            CopyTo(clone);
            return clone;
        }
    }
}
