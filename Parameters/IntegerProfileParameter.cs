namespace ProfitRobots.FXTS2LuaExecuter
{
    public class IntegerProfileParameter : ProfileParameter
    {
        public int Value { get; set; }
        public int Default { get; set; }

        public override ProfileParameter Clone()
        {
            var clone = new IntegerProfileParameter()
            {
                Value = Value,
                Default = Default
            };
            CopyTo(clone);
            return clone;
        }
    }
}
