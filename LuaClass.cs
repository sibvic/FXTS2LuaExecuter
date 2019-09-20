using Neo.IronLua;
using System;

namespace ProfitRobots.FXTS2LuaExecuter
{
    public class LuaClass : IDisposable
    {
        protected readonly dynamic _env;
        protected LuaClass()
        {
            _env = _lua.CreateEnvironment();
        }

        readonly Lua _lua = new Lua();

        bool _disposed = false;
        public virtual void Dispose()
        {
            if (_disposed)
                return;
            _disposed = true;
            _lua.Dispose();
        }
    }
}
