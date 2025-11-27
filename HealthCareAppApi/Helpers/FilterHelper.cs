//using Kutiyana_Memon_Hospital_Api.DTOs.Request;
using System.Globalization;
using System.Text;

namespace HealthCareAppApi.Helpers
{
    public static class FilterHelper
    {
        //public static string BuildDynamicFilterQuery<TEnum>(
        //    TEnum baseTable,
        //    string baseAlias,
        //    List<FilterFieldRequest> filters,
        //    out string joinClause)
        //{
        //    var whereBuilder = new StringBuilder("WHERE 1=1");
        //    var joinBuilder = new StringBuilder();

        //    if (filters == null || filters.Count == 0)
        //    {
        //        joinClause = string.Empty;
        //        return string.Empty;
        //    }

        //    //  Group filters by fieldName to detect date range pairs (FilterType 6)
        //    var groupedFilters = filters.GroupBy(f => f.FieldName);

        //    foreach (var group in groupedFilters)
        //    {
        //        var filterList = group.ToList();

        //        // 🗓Handle Date Range filterType 6 (FromDate + ToDate)
        //        if (filterList.Any(f => f.FilterType == 6))
        //        {
        //            var fromValue = filterList.FirstOrDefault()?.Value;
        //            var toValue = filterList.Skip(1).FirstOrDefault()?.Value;

        //            if (!string.IsNullOrEmpty(fromValue) && !string.IsNullOrEmpty(toValue))
        //            {
        //                whereBuilder.Append($" AND {baseAlias}.{group.Key} >= '{EscapeSql(fromValue)}' AND {baseAlias}.{group.Key} < DATEADD(DAY, 1, '{EscapeSql(toValue)}')");
        //                continue;
        //            }
        //            else if (!string.IsNullOrEmpty(fromValue))
        //            {
        //                whereBuilder.Append($" AND {baseAlias}.{group.Key} >= '{EscapeSql(fromValue)}'");
        //                continue;
        //            }
        //            else if (!string.IsNullOrEmpty(toValue))
        //            {
        //                whereBuilder.Append($" AND {baseAlias}.{group.Key} < DATEADD(DAY, 1, '{EscapeSql(toValue)}')");
        //                continue;
        //            }
        //        }

        //        //  Handle normal filters (Text, Dropdown, Boolean, etc.)
        //        foreach (var filter in filterList)
        //        {
        //            if (string.IsNullOrWhiteSpace(filter.FieldName) || string.IsNullOrWhiteSpace(filter.Value))
        //                continue;

        //            var alias = baseAlias;

        //            if (filter.IsCurrentTableField && !string.IsNullOrWhiteSpace(filter.JoinTableAlias))
        //                alias = filter.JoinTableAlias;

        //            var field = $"{alias}.{filter.FieldName}";

        //            // Add JOIN if required
        //            if (filter.IsCurrentTableField &&
        //                !string.IsNullOrWhiteSpace(filter.JoinTableName) &&
        //                !string.IsNullOrWhiteSpace(filter.JoinCondition))
        //            {
        //                string joinSql = $"LEFT JOIN {filter.JoinTableName} {filter.JoinTableAlias} ON {filter.JoinCondition}";
        //                if (!joinBuilder.ToString().Contains(joinSql))
        //                    joinBuilder.AppendLine(joinSql);
        //            }

        //            var condition = BuildFilterCondition(field, filter);
        //            if (!string.IsNullOrEmpty(condition))
        //                whereBuilder.Append(" AND ").Append(condition);
        //        }
        //    }

        //    joinClause = joinBuilder.ToString();
        //    return whereBuilder.ToString();
        //}

        //// Builds individual filter conditions
        //private static string BuildFilterCondition(string field, FilterFieldRequest filter)
        //{
        //    switch (filter.FilterType)
        //    {
        //        case 1: // Text
        //            return $"{field} LIKE '%{EscapeSql(filter.Value)}%'";

        //        case 2: // Single Select (Dropdown)
        //            if (decimal.TryParse(filter.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
        //                return $"{field} = {filter.Value}";
        //            return $"{field} = '{EscapeSql(filter.Value)}'";

        //        case 3: // Multi-select
        //            var values = filter.Value.Split(',')
        //                                     .Select(v => $"'{EscapeSql(v.Trim())}'");
        //            return $"{field} IN ({string.Join(",", values)})";

        //        //case 4: // Exact Date
        //        //    return $"{field} = '{EscapeSql(filter.Value)}'";
        //        case 4: // Exact Date (match whole day)
        //            return $"{field} >= '{EscapeSql(filter.Value)}' AND {field} < DATEADD(DAY, 1, '{EscapeSql(filter.Value)}')";


        //        case 5: // Boolean
        //            if (bool.TryParse(filter.Value, out var b))
        //                return $"{field} = {(b ? 1 : 0)}";
        //            return "";

        //        case 6: // Date Range handled in main loop (skip)
        //            return string.Empty;

        //        default:
        //            return $"{field} = '{EscapeSql(filter.Value)}'";
        //    }
        //}

        //// 🧹 SQL injection safety
        //private static string EscapeSql(string value)
        //{
        //    return value.Replace("'", "''");
        //}
    }
}
