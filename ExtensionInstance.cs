
namespace ProfitRobots.FXTS2LuaExecuter
{
    public class ExtensionInstance : LuaClass
    {
        internal ExtensionInstance(Core core, IndicatorProfile profile)
        {
            _env.core = core;
            _env.instance = new IndicatorInstance()
            {
                profile = profile
            };
            //subscribe to profile
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="FXTS2ExtensionException"></exception>
        public void Prepare()
        {
            _env.Prepare(false);
        }

        public override void Dispose()
        {
            base.Dispose();
            //unsubscribe from profile
        }
    }
}
