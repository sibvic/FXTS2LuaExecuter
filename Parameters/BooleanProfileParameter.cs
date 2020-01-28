namespace ProfitRobots.FXTS2LuaExecuter
{
    public class BooleanProfileParameter : ProfileParameter
    {
        public bool Value { get; set; }

        public bool Default { get; set; }

        public override ProfileParameter Clone()
        {
            var clone = new BooleanProfileParameter()
            {
                Value = Value,
                Default = Default
            };
            CopyTo(clone);
            return clone;
        }
    }
}
