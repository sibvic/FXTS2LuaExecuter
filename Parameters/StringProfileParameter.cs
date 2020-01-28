namespace ProfitRobots.FXTS2LuaExecuter
{
    public class StringProfileParameter : ProfileParameter
    {
        public string Value { get; set; }
        public string Default { get; set; }

        public override ProfileParameter Clone()
        {
            var clone = new StringProfileParameter()
            {
                Value = Value,
                Default = Default
            };
            CopyTo(clone);
            return clone;
        }
    }
}
