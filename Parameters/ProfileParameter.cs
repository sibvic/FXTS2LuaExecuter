namespace ProfitRobots.FXTS2LuaExecuter
{
    public class ProfileParameter
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public ParameterFlag Flag { get; internal set; } = ParameterFlag.NoFlag;
    }
}
