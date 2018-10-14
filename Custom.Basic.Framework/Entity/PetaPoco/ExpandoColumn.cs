using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Basic.Framework.Entity.PetaPoco
{
    internal class ExpandoColumn : PocoColumn
    {
        public override void SetValue(object target, object val)
        {
            (target as IDictionary<string, object>)[ColumnName] = val;
        }

        public override object GetValue(object target)
        {
            object val = null;
            (target as IDictionary<string, object>).TryGetValue(ColumnName, out val);
            return val;
        }

        public override object ChangeType(object val)
        {
            return val;
        }
    }
}
