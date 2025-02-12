﻿#region usings
using System.Text.Json.Serialization;
using Gccg.Core.Exceptions;
#endregion

namespace Gccg.Core.Elements;

public class Package
{
    public Dictionary<string, string> Variables { get; set; } = new();

    [JsonIgnore]
    public string this[string variableName]
    {
        get
        {
            switch (variableName)
            {
                case "GeneratedTime":
                    return DateTime.Now.ToString();

                case "BeginOnView":
                case "BeginOnNoCache":
                case "BeginOnVoidReturn":
                    return "/*";

                case "EndOnView":
                case "EndOnNoCache":
                case "EndOnVoidReturn":
                    return "*/";
            }

            if (Variables.TryGetValue(variableName, out var variable))
                return variable;

            throw new VariableNotExistException(variableName);
        }
    }
}