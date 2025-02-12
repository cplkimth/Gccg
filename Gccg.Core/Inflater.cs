﻿using System.Text;
using System.Text.RegularExpressions;
using Gccg.Core.Models;
using Gccg.Core.Utilities;

namespace Gccg.Core;

public static class Inflater
{
    internal static string Inflate(string template, params Table[] tables)
    {
        StringBuilder builder = new (template);

        GccgConfig.Instance.Fill(builder);

        var tableMatches = Regex.Matches(template, "`T(.*?)T`", RegexOptions.Singleline);
        foreach (Match tableMatch in tableMatches)
        {
            var replaced = InflateTables(tableMatch.Groups[1].Value, tables);

#if DEBUG
            // Console.WriteLine(replaced);
#endif
            builder.Replace(tableMatch.Value, replaced);
        }

#if DEBUG
        // Console.WriteLine(builder.ToString());
#endif

        return builder.ToString();
    }

    private static string InflateTables(string template, Table[] tables)
    {
        StringBuilder builder = new();

        foreach (var table in tables)
        {
            var replaced = InflateTable(template, table);

            replaced = ReplaceTable(replaced, table);

            builder.AppendLine(replaced);
        }

        return builder.ToString();
    }

    private static string InflateTable(string template, Table table)
    {
        StringBuilder builder = new(template);

        var columnMatches = Regex.Matches(template, "`(!??)([APFIN]):(.*?):(.*?)``", RegexOptions.Singleline);
        foreach (Match columnMatch in columnMatches)
        {
            var criteria = $"{columnMatch.Groups[1].Value}{columnMatch.Groups[2].Value}";
            var columns = table.Search(criteria);

            List<string> lines = columns.ConvertAll(x => ReplaceColumn(x, columnMatch.Groups[4].Value));
            var separator = BuildSeparator(columnMatch.Groups[3].Value);
            var replacedText = string.Join(separator, lines);

            builder.Replace(columnMatch.Value, replacedText);
        }

        return builder.ToString();
    }

    private static string BuildSeparator(string template) 
        => template
        .Replace("[N]", Environment.NewLine)
        .Replace("[T]", "\t");

    private static void ReplaceBaseModel(BaseModel baseModel, StringBuilder builder)
    {
        builder.Replace("`Name`", baseModel.Name.ToPascalCase());
        builder.Replace("`name`", baseModel.Name.ToCamelCase());
        builder.Replace("`name_`", baseModel.Name.ToSnakeCase());
    }

    private static string ReplaceTable(string template, Table table)
    {
        StringBuilder builder = new(template);
        ReplaceBaseModel(table, builder);

        return builder.ToString();
    }

    private static string ReplaceColumn(Column column, string template)
    {
        StringBuilder builder = new(template);
        ReplaceBaseModel(column, builder);

        builder.Replace("`Type`", column.Type);

        builder.Replace("`Table`", column.Table.ToPascalCase());
        builder.Replace("`table`", column.Table.ToCamelCase());
        builder.Replace("`table_`", column.Table.ToSnakeCase());

        return builder.ToString();
    }
}