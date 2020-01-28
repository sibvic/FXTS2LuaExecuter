namespace ProfitRobots.FXTS2LuaExecuter
{
    public class ColorProfileParameter : ProfileParameter
    {
        public int Value { get; set; }

        public int Default { get; set; }

        public override ProfileParameter Clone()
        {
            var clone = new ColorProfileParameter()
            {
                Value = Value,
                Default = Default
            };
            CopyTo(clone);
            return clone;
        }
    }
}
