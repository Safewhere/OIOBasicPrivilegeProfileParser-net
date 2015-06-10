#region

using System;
using System.Xml;

#endregion

namespace Kombit.Samples.BasicPrivilegeProfileParser
{
    /// <summary>
    ///     Represent a constraint of basic privilege profile.
    /// </summary>
    public class Constraint : IEquatable<Constraint>
    {
        /// <summary>
        ///     Initializes a new instance of the constraint class by an xml element
        /// </summary>
        /// <param name="xConstraint">a constraint xml parameter</param>
        public Constraint(XmlElement xConstraint)
        {
            Name = xConstraint.GetAttribute("Name");
            Value = xConstraint.InnerText;
        }

        /// <summary>
        ///     Name of a constraint
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Value of a constraint
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Determines whether the specified constraint is equal to the current one.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Constraint other)
        {
            return ((Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase)) &&
                    (Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}