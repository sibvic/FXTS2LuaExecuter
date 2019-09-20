namespace ProfitRobots.FXTS2LuaExecuter
{
    public class Profile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }

        public ProfileParameters Parameters => parameters;

        #region Lua
        /// <summary>
        /// Gets the name of the indicator.
        /// </summary>
        /// <param name="name"></param>
        public void name(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the unique identifier of the indicator.
        /// </summary>
        /// <returns></returns>
        public string id()
        {
            return Id;
        }

        /// <summary>
        /// Sets the type of the indicator.
        /// </summary>
        /// <param name="type"></param>
        public void type(int type)
        {
            //ignore
        }

        /// <summary>
        /// Gets the description of the indicator.
        /// </summary>
        /// <param name="description"></param>
        public void description(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Sets the tag value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void setTag(string id, string value)
        {
            //ignore
        }

        /// <summary>
        /// Gets a set of the parameters.
        /// </summary>
        public ProfileParameters parameters { get; set; } = new ProfileParameters();
        #endregion
    }
}
