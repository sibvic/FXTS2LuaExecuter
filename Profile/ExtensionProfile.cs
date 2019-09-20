using Neo.IronLua;
using System;
using System.Text.RegularExpressions;

namespace ProfitRobots.FXTS2LuaExecuter
{
    public class ExtensionProfile : LuaClass
    {
        readonly IndicatorProfile _indicator = new IndicatorProfile();
        readonly StrategyProfile _strategy = new StrategyProfile();
        readonly ToolProfile _tool = new ToolProfile();
        readonly Core _core;
        internal ExtensionProfile(Core core, string id)
        {
            _core = core;
            _indicator.Id = id;
            _strategy.Id = id;
            _env.indicator = _indicator;
            _env.strategy = _strategy;
            _env.tool = _tool;
            _env.core = core;
            _env.resources = new Resources();
        }

        public Profile Profile
        {
            get
            {
                if (_indicator.Name != null)
                    return _indicator;
                if (_strategy.Name != null)
                    return _strategy;
                return _tool;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="FXTS2ExtensionException"></exception>
        public void Init()
        {
            try
            {
                _env.Init();
            }
            catch (LuaRuntimeException ex)
            {
                throw new FXTS2ExtensionException(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new FXTS2ExtensionException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="FXTS2ExtensionException"></exception>
        /// <returns></returns>
        public ExtensionInstance CreateInstance()
        {
            var instance = new ExtensionInstance(_core, _indicator);
            instance.Prepare();
            return instance;
        }

        Regex _clrPattern = new Regex("([ =+-/*])clr([ =+-/*;])");

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="FXTS2ExtensionException"></exception>
        /// <param name="code"></param>
        internal void Load(string code)
        {
            Code = _clrPattern.Replace(code, "$1___clr___$2");
            try
            {
                _env.dochunk(Code);
            }
            catch (LuaParseException ex)
            {
                throw new FXTS2ExtensionException(ex.Message);
            }
            catch (LuaRuntimeException ex)
            {
                throw new FXTS2ExtensionException(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new FXTS2ExtensionException(ex.Message);
            }
        }

        public string Code { get; internal set; }

        public int Id { get; internal set; }

        /// <summary>
        /// Hash of the extension code.
        /// </summary>
        public string Hash { get; internal set; }

        /// <summary>
        /// Wether extension can trade.
        /// </summary>
        public bool Trades { get; internal set; }
    }
}
