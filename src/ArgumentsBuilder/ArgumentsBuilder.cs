using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rksoftware.ArgumentsBuilder;

public static class ArgumentsBuilder
{
    public static (IReadOnlyList<string> parameters, IReadOnlyDictionary<string, string> options) Parse(string[] args)
    {
        List<string> parameters = new();
        Dictionary<string, string> options = new();
        string optionName = "";

        foreach (var arg in args)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                continue;
            }

            {
                var pre = arg.First();
                if (new[] { '-', '/' }.Contains(pre))
                {
                    optionName = new string(arg.SkipWhile(c => c == pre).ToArray());
                    options.Add(optionName, "");
                    continue;
                }
            }

            if (string.IsNullOrWhiteSpace(optionName))
            {
                parameters.Add(arg);
                continue;
            }

            options[optionName] = arg;
            optionName = "";
        }

        return (parameters, options);
    }

}

