﻿using System.Text;

namespace Gccg.Tools.RowGenerators;

public class ConstantGenerator : RowGenerator
{
    public ConstantGenerator(string className, Func<List<object>> onLoad, Func<object, int> onGetId,
        Func<object, string> onGetText, Func<object, int> onGetPrefix) : base(className, onLoad, onGetId, onGetText, onGetPrefix)
    {
    }

    public override string FileName => $"{ClassName}.constant.cs";

    public override string Generate()
    {
        StringBuilder builder = new();

        try
        {
            List<object> list = OnLoad();

            foreach (object item in list)
            {
                // public const int _1_재직상태 = 1;
                int id = OnGetId(item);
                int prefix = OnGetPrefix(item);
                string text = OnGetText(item);

                foreach (var charToRemove in CharsToRemove)
                    text = text.Replace(charToRemove.ToString(), "");

                string line = $"public const int _{prefix}_{text} = {id};";

                builder.AppendLine(line);
            }

            string lines = builder.ToString();
            string content = 
$$"""
   // <auto-generated> This file has been auto generated at {{DateTime.Now}} </auto-generated>

   namespace {{Namespace}};
   
   public partial class {{ClassName}}
   {
       {{lines}}
   }
   """;

            File.WriteAllText(FilePath, content);

            return null;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}