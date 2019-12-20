using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfitRobots.FXTS2LuaExecuter
{

    public class ProfileParameters : IEnumerable<ProfileParameter>
    {
        public List<ProfileParameter> Parameters { get; private set; } = new List<ProfileParameter>();

        public string Hash
        {
            get
            {
                var code = GetCode();
                using (var sha512 = System.Security.Cryptography.SHA512.Create())
                {
                    var data = Encoding.UTF8.GetBytes(code);
                    var hash = sha512.ComputeHash(data);
                    return Convert.ToBase64String(hash);
                }
            }
        }

        private string GetCode()
        {
            var code = new StringBuilder();
            var first = true;
            foreach (var param in Parameters)
            {
                if (!first)
                {
                    code.Append(";");
                }
                switch (param)
                {
                    case DoubleProfileParameter doubleParam:
                        code.Append(param.Id);
                        if (doubleParam.Value % 1 != 0 || doubleParam.Value != doubleParam.Default)
                        {
                            code.Append("=" + doubleParam.Value.ToString().Replace(",", "."));
                        }
                        break;
                    case BooleanProfileParameter boolParam:
                        code.Append(param.Id);
                        if (boolParam.Value != boolParam.Default)
                        {
                            code.Append("=" + boolParam.Value.ToString());
                        }
                        break;
                    case ColorProfileParameter colorParam:
                        code.Append(param.Id);
                        if (colorParam.Value != colorParam.Default)
                        {
                            code.Append("=" + colorParam.Value.ToString());
                        }
                        break;
                    case DateProfileParameter dateParam:
                        code.Append(param.Id);
                        if (dateParam.Value != dateParam.Default)
                        {
                            code.Append("=" + dateParam.Value.ToString());
                        }
                        break;
                    case FileProfileParameter fileParam:
                        code.Append(param.Id);
                        if (fileParam.Value != fileParam.Default)
                        {
                            code.Append("=" + fileParam.Value.ToString());
                        }
                        break;
                    case IntegerProfileParameter integerParam:
                        code.Append(param.Id);
                        if (integerParam.Value != integerParam.Default)
                        {
                            code.Append("=" + integerParam.Value.ToString());
                        }
                        break;
                    case StringProfileParameter stringParam:
                        code.Append(param.Id);
                        if (stringParam.Value != stringParam.Default)
                        {
                            code.Append("=" + stringParam.Value.ToString());
                        }
                        break;
                }
                first = false;
            }
            return code.ToString();
        }

        /// <summary>
        /// Adds a new string parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="value"></param>
        public void addString(string id, string name, string desc, string value)
        {
            Parameters.Add(new StringProfileParameter()
            {
                Id = id,
                Name = name,
                Description = desc,
                Value = value
            });
        }

        /// <summary>
        /// Adds a new boolean parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="value"></param>
        public void addBoolean(string id, string name, string desc, bool value)
        {
            Parameters.Add(new BooleanProfileParameter()
            {
                Id = id,
                Name = name,
                Description = desc,
                Value = value
            });
        }

        /// <summary>
        /// Adds a new color parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="value"></param>
        public void addColor(string id, string name, string desc, int value)
        {
            Parameters.Add(new ColorProfileParameter()
            {
                Id = id,
                Name = name,
                Description = desc,
                Value = value
            });
        }

        /// <summary>
        /// Adds a date or date/time parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="value"></param>
        public void addDate(string id, string name, string desc, double value)
        {
            Parameters.Add(new DateProfileParameter()
            {
                Id = id,
                Name = name,
                Description = desc,
                Value = value
            });
        }

        /// <summary>
        /// Adds a new double parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="value"></param>
        public void addDouble(string id, string name, string desc, double value)
        {
            Parameters.Add(new DoubleProfileParameter()
            {
                Id = id,
                Name = name,
                Description = desc,
                Value = value
            });
        }

        public void addDoubleAlternative(string id, string name, string desc, double value)
        {
            //do nothing
        }

        /// <summary>
        /// Adds a file parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="value"></param>
        public void addFile(string id, string name, string desc, string value)
        {
            Parameters.Add(new FileProfileParameter()
            {
                Id = id,
                Name = name,
                Description = desc,
                Value = value
            });
        }

        /// <summary>
        /// Adds a new integer parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="value"></param>
        public void addInteger(string id, string name, string desc, int value)
        {
            Parameters.Add(new IntegerProfileParameter()
            {
                Id = id,
                Name = name,
                Description = desc,
                Value = value
            });
        }

        /// <summary>
        /// Starts the group of the parameters.
        /// </summary>
        /// <param name="name"></param>
        public void addGroup(string name)
        {
            //do nothing
        }

        /// <summary>
        /// Sets the parameter's flag
        /// </summary>
        /// <param name="id"></param>
        /// <param name="flag"></param>
        public void setFlag(string id, int flag)
        {
            var parameter = Parameters.Where(p => p.Id == id).First();
            parameter.Flag = (ParameterFlag)flag;
        }

        /// <summary>
        /// Adds an alternative for the integer parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="value"></param>
        public void addIntegerAlternative(string id, string name, string description, int value)
        {
            //ignore
        }

        /// <summary>
        /// Adds an alternative for the string parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="value"></param>
        public void addStringAlternative(string id, string name, string description, string value)
        {
            //ignore
        }

        public IEnumerator<ProfileParameter> GetEnumerator()
        {
            return Parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Parameters.GetEnumerator();
        }

        //new Creates a new instance of a parameters table.
        //getBoolean Gets a boolean value of the indicator parameter.
        //getColor Gets a color value of the indicator parameter.
        //getCustomParameters Gets information about the parameters set associated with this parameter.
        //getDouble Gets a real number value of the indicator parameter.
        //getFile Gets a file name value of the indicator parameter.
        //getInteger Gets an integer value of the indicator parameter.
        //getString Gets a string value of the indicator parameter.
        //setBoolean Sets a boolean value of the indicator parameter.
        //setColor Sets a color value of the indicator parameter.
        //setDouble Sets a real number value of the indicator parameter.
        //setInteger Sets an integer value of the indicator parameter.
        //setString Sets a string value of the indicator parameter.
    }
}
