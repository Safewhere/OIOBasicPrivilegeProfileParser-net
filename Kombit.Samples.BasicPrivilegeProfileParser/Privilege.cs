#region

using System;

#endregion

namespace Kombit.Samples.BasicPrivilegeProfileParser
{
    /// <summary>
    ///     Represent the privilege of a privilege group
    /// </summary>
    public class Privilege : IEquatable<Privilege>
    {
        /// <summary>
        ///     Initializes a new instance of the privilege class with a type and a cvr
        /// </summary>
        /// <param name="type">a string that represents type of a privilege object</param>
        /// <param name="cvr">a string that represents cvr of a privilege object</param>
        public Privilege(string type, string cvr)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (cvr == null)
                throw new ArgumentNullException("cvr");

            Type = type;
            Cvr = cvr;
        }

        /// <summary>
        ///     Type of a privilege
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        ///     Cvr of a privilege
        /// </summary>
        public string Cvr { get; private set; }

        /// <summary>
        ///     Determines whether the specified privilege is equal to the current one.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Privilege other)
        {
            return ((Type.Equals(other.Type, StringComparison.InvariantCultureIgnoreCase)) &&
                    (Cvr.Equals(other.Cvr, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}