namespace ProfitRobots.FXTS2LuaExecuter
{

    public class ToolProfile : Profile
    {
        /// <summary>
        /// Associate a custom icon with the tool
        /// </summary>
        /// <param name="path"></param>
        public void icon(string path)
        {

        }

        /// <summary>
        /// Returns the instance of the creation strategy table.
        /// </summary>
        public ToolCreationSrategy creationStrategy { get; set; } = new ToolCreationSrategy();
    }
}
