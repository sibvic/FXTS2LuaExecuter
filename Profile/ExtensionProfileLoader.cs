using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfitRobots.FXTS2LuaExecuter
{
    public static class ExtensionProfileLoader
    {
        /// <summary>
        /// Loads extension from file
        /// </summary>
        /// <exception cref="FXTS2ExtensionException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <param name="file"></param>
        /// <param name="indicoreRootPath">Path to indicore root</param>
        /// <returns>Valid profile</returns>
        public static ExtensionProfile Load(string file, string indicoreRootPath, int? id)
        {
            if (!File.Exists(file))
                throw new ArgumentOutOfRangeException();

            var code = File.ReadAllText(file);
            var formattedCode = FormatLuaCode(code);

            var core = new Core(indicoreRootPath);
            var strategy = new ExtensionProfile(core, Path.GetFileNameWithoutExtension(file).ToUpper())
            {
                Hash = GetHash(formattedCode),
                Id = id ?? GetId(code),
                Trades = code.Contains("terminal:execute")
            };
            strategy.Load(code);
            strategy.Init();
            return strategy;
        }

        /// <summary>
        /// Loads extension from code
        /// </summary>
        /// <exception cref="FXTS2ExtensionException"></exception>
        /// <param name="code">Code to load</param>
        /// <param name="indicoreRootPath">Path to indicore root</param>
        /// <returns>Valid profile</returns>
        public static ExtensionProfile LoadFromCode(string code, string name, string indicoreRootPath)
        {
            var formattedCode = FormatLuaCode(code);

            var core = new Core(indicoreRootPath);
            var strategy = new ExtensionProfile(core, name.ToUpper())
            {
                Hash = GetHash(formattedCode),
                Id = GetId(code),
                Trades = code.Contains("terminal:execute")
            };
            strategy.Load(code);
            strategy.Init();
            return strategy;
        }

        private static int GetId(string code)
        {
            Regex idPattern = new Regex("-- ?Id: ?(\\d+)");
            var idMatch = idPattern.Match(code);
            if (!idMatch.Success)
                return 0;

            if (!int.TryParse(idMatch.Groups[1].Value, out int id))
                return 0;

            return id;
        }

        private static string GetHash(string code)
        {
            using (var sha512 = System.Security.Cryptography.SHA512.Create())
            {
                var data = Encoding.UTF8.GetBytes(code);
                var hash = sha512.ComputeHash(data);
                return Convert.ToBase64String(hash);
            }
        }

        private static string FormatLuaCode(string code)
        {
            return code;
        }
    }
}
