using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Basic.Framework.Entity.PetaPoco
{
    /// <summary>
    ///     Represents an attribute, which when applied to a Poco class, specifies the the DB table name which it maps to
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute
    {
        /// <summary>
        ///     The table nane of the database that this entity maps to.
        /// </summary>
        /// <returns>
        ///     The table nane of the database that this entity maps to.
        /// </returns>
        public string Value { get; private set; }

        /// <summary>
        ///     Constructs a new instance of the <seealso cref="TableNameAttribute" />.
        /// </summary>
        /// <param name="tableName">The table nane of the database that this entity maps to.</param>
        public TableNameAttribute(string tableName)
        {
            Value = tableName;
        }
    }
}
