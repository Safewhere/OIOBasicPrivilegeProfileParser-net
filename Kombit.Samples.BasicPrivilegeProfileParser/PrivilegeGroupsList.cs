#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

#endregion

namespace Kombit.Samples.BasicPrivilegeProfileParser
{
    /// <summary>
    ///     Represent a list of PrivilegeGroup objects
    /// </summary>
    public class PrivilegeGroupsList : IList<PrivilegeGroup>, IEquatable<PrivilegeGroupsList>
    {
        private readonly IList<PrivilegeGroup> privilegeGroups;

        /// <summary>
        ///     Initializes a new instance of the PrivilegeGroupsList class by an xml element
        /// </summary>
        /// <param name="xml"></param>
        public PrivilegeGroupsList(XmlElement xml)
        {
            privilegeGroups = new List<PrivilegeGroup>();
            XmlNodeList xGroupsList =
                xml.GetElementsByTagName("PrivilegeGroup");
            foreach (XmlNode xn in xGroupsList)
            {
                var privilegeGroup = new PrivilegeGroup((XmlElement) xn);
                privilegeGroups.Add(privilegeGroup);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the PrivilegeGroupsList class by a list of PrivilegeGroup objects
        /// </summary>
        /// <param name="privilegeGroups"></param>
        public PrivilegeGroupsList(IList<PrivilegeGroup> privilegeGroups)
        {
            this.privilegeGroups = privilegeGroups;
        }

        /// <summary>
        ///     Determines whether the specified PrivilegeGroupList is equal to the current one.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PrivilegeGroupsList other)
        {
            if (other == null)
            {
                return false;
            }
            if (privilegeGroups.Count != other.privilegeGroups.Count)
                return false;
            return privilegeGroups.All(x => other.Any(o => o.Equals(x)));
        }

        /// <summary>
        ///     Get enumerator of a list of privilegeGroups
        /// </summary>
        /// <returns></returns>
        public IEnumerator<PrivilegeGroup> GetEnumerator()
        {
            return privilegeGroups.GetEnumerator();
        }

        /// <summary>
        ///     Get enumerator of a list of privilegeGroups
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return privilegeGroups.GetEnumerator();
        }

        /// <summary>
        ///     Get an index of a PrivilegeGroup in a list of privilegeGroups
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(PrivilegeGroup item)
        {
            return privilegeGroups.IndexOf(item);
        }

        /// <summary>
        ///     Insert a PrivilegeGroup to a list of PrivilegeGroups
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, PrivilegeGroup item)
        {
            privilegeGroups.Insert(index, item);
        }

        /// <summary>
        ///     Remove a PrivilegeGroup in a list of PrivilegeGroups
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            privilegeGroups.RemoveAt(index);
        }

        /// <summary>
        ///     Select a PrivilegeGroup in a list of PrivilegeGroups by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PrivilegeGroup this[int index]
        {
            get { return privilegeGroups[index]; }
            set { privilegeGroups[index] = value; }
        }

        /// <summary>
        ///     Add a PrivilegeGroup to a list of PrivilegeGroups
        /// </summary>
        /// <param name="item"></param>
        public void Add(PrivilegeGroup item)
        {
            privilegeGroups.Add(item);
        }

        /// <summary>
        ///     Clear all items on PrivilegeGroups
        /// </summary>
        public void Clear()
        {
            privilegeGroups.Clear();
        }

        /// <summary>
        ///     Determines whethere a PrivilegeGroup exists on a list of PrivilegeGroups
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(PrivilegeGroup item)
        {
            return privilegeGroups.Contains(item);
        }

        /// <summary>
        ///     Copy the current PrivilegeGroups to an array by an arrayIndex
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(PrivilegeGroup[] array, int arrayIndex)
        {
            privilegeGroups.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Determine the number of items in the current list of PrivilegeGroups
        /// </summary>
        public int Count
        {
            get { return privilegeGroups.Count; }
        }

        /// <summary>
        ///     Determine if the current PrivilegeGroups is ReadOnly
        /// </summary>
        public bool IsReadOnly
        {
            get { return privilegeGroups.IsReadOnly; }
        }

        /// <summary>
        ///     Remove a PrivilegeGroup item in the current list of PrivilegeGroups
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(PrivilegeGroup item)
        {
            return privilegeGroups.Remove(item);
        }
    }
}