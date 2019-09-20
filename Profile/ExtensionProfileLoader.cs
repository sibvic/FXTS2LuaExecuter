using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfitRobots.FXTS2LuaExecuter
{
    public static class ExtensionProfileLoader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="FXTS2ExtensionException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns>Valid profile</returns>
        public static ExtensionProfile Load(string file, string path)
        {
            if (!File.Exists(file))
                throw new ArgumentOutOfRangeException();

            var code = File.ReadAllText(file);
            var formattedCode = FormatLuaCode(code);

            var core = new Core(path);
            var strategy = new ExtensionProfile(core, Path.GetFileNameWithoutExtension(file).ToUpper())
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
