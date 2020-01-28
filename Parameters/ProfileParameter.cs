namespace ProfitRobots.FXTS2LuaExecuter
{
    public abstract class ProfileParameter
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public ParameterFlag Flag { get; internal set; } = ParameterFlag.NoFlag;

        protected void CopyTo(ProfileParameter target)
        {
            target.Id = Id;
            target.Name = Name;
            target.Description = Description;
            target.Flag = Flag;
        }

        public abstract ProfileParameter Clone();
    }
}
