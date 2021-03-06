﻿namespace ProfitRobots.FXTS2LuaExecuter
{
    public class DateProfileParameter : ProfileParameter
    {
        public double Value { get; set; }
        public double Default { get; set; }

        public override ProfileParameter Clone()
        {
            var clone = new DateProfileParameter()
            {
                Value = Value,
                Default = Default
            };
            CopyTo(clone);
            return clone;
        }
    }
}
