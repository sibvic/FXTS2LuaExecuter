namespace ProfitRobots.FXTS2LuaExecuter
{
    public class FileProfileParameter : ProfileParameter
    {
        public string Value { get; set; }
        public string Default { get; set; }

        public override ProfileParameter Clone()
        {
            var clone = new FileProfileParameter()
            {
                Value = Value,
                Default = Default
            };
            CopyTo(clone);
            return clone;
        }
    }
}
