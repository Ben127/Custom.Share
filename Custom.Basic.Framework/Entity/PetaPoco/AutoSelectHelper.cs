﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Custom.Basic.Framework.Entity.PetaPoco
{
    internal static class AutoSelectHelper
    {
        private static Regex rxSelect = new Regex(@"\A\s*(SELECT|EXECUTE|CALL|WITH|SET|DECLARE)\s",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        private static Regex rxFrom = new Regex(@"\A\s*FROM\s",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static string AddSelectClause<T>(IProvider provider, string sql, IMapper defaultMapper)
        {
            if (sql.StartsWith(";"))
                return sql.Substring(1);

            if (!rxSelect.IsMatch(sql))
            {
                var pd = PocoData.ForType(typeof(T), defaultMapper);
                var tableName = provider.EscapeTableName(pd.TableInfo.TableName);
                string cols = pd.Columns.Count != 0
                    ? string.Join(", ", (from c in pd.QueryColumns select tableName + "." + provider.EscapeSqlIdentifier(c)).ToArray())
                    : "NULL";
                if (!rxFrom.IsMatch(sql))
                    sql = string.Format("SELECT {0} FROM {1} {2}", cols, tableName, sql);
                else
                    sql = string.Format("SELECT {0} {1}", cols, sql);
            }
            return sql;
        }
    }
}
