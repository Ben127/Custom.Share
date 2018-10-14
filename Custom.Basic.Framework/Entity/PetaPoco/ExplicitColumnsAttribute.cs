using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Basic.Framework.Entity.PetaPoco
{
    /// <summary>
    ///     Represents the attribute which decorates a poco class to state all columns must be explicitly mapped using either a
    ///     <seealso cref="ColumnAttribute" /> or <seealso cref="ResultColumnAttribute" />.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExplicitColumnsAttribute : Attribute
    {
    }
}
