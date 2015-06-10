#region

using System;
using System.Collections.Generic;
using System.Xml;
using Kombit.Samples.Common;

#endregion

namespace Kombit.Samples.BasicPrivilegeProfileParser
{
    //<?xml version="1.0" encoding="UTF-8"?>
    //<bpp:PrivilegeList xmlns:bpp="http://itst.dk/oiosaml/basic_privilege_profile" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    //  <PrivilegeGroup Scope="urn:dk:gov:saml:cvrNumberIdentifier:12345678">
    //    <Privilege>http://sapa.test-kombit.dk/roles/usersystemrole/withDR/1</Privilege>
    //    <Constraint Name="http://organisation.test-kombit.dk/constraints/KLE">2</Constraint>
    //    <Constraint Name="http://organisation.test-kombit.dk/constraints/Sensitivity">High</Constraint>
    //  </PrivilegeGroup>
    //  <PrivilegeGroup Scope="urn:dk:gov:saml:cvrNumberIdentifier:12345678">
    //    <Privilege>http://sapa.test-kombit.dk/roles/usersystemrole/withDR/2</Privilege>
    //    <Constraint Name="http://organisation.test-kombit.dk/constraints/KLE-NEW">1</Constraint>
    //    <Constraint Name="http://organisation.test-kombit.dk/constraints/Sensitivity">High</Constraint>
    //  </PrivilegeGroup>
    //  <PrivilegeGroup Scope="urn:dk:gov:saml:cvrNumberIdentifier:87654321">
    //    <Privilege>http://sapa.test-kombit.dk/roles/usersystemrole/noDR/1</Privilege>
    //  </PrivilegeGroup>
    //  <PrivilegeGroup Scope="urn:dk:gov:saml:cvrNumberIdentifier:87654321">
    //    <Privilege>http://sapa.test-kombit.dk/roles/usersystemrole/noDR/2</Privilege>
    //  </PrivilegeGroup>
    //  <PrivilegeGroup Scope="urn:dk:gov:saml:cvrNumberIdentifier:12121212">
    //    <Privilege>http://sapa.test-kombit.dk/roles/usersystemrole/withDR/3</Privilege>
    //    <Constraint Name="http://organisation.test-kombit.dk/constraints/Kop">1</Constraint>
    //    <Constraint Name="http://organisation.test-kombit.dk/constraints/Sensitivity">Medium</Constraint>
    //  </PrivilegeGroup>
    //</bpp:PrivilegeList>
    /// <summary>
    ///     Represent a privilege group in a basic privilege profile
    /// </summary>
    public class PrivilegeGroup : IEquatable<PrivilegeGroup>
    {
        /// <summary>
        ///     Initializes a new instance of the PrivilegeGroup class by an xml element
        /// </summary>
        /// <param name="xml"></param>
        public PrivilegeGroup(XmlElement xml)
        {
            if (xml == null)
                throw new ArgumentNullException("xml");

            Constraints = new List<Constraint>();
            XmlNodeList xConstraintsList = xml.GetElementsByTagName("Constraint");
            if (xConstraintsList.Count > 0)
            {
                foreach (var xConstraint in xConstraintsList)
                {
                    var constraint = new Constraint((XmlElement) xConstraint);
                    Constraints.Add(constraint);
                }
            }

            var types = xml.GetElementsByTagName("Privilege");
            if (types.Count > 1)
            {
                Logging.Instance.Error("Duplicate privilege has been found on privilege group element");
                throw new ArgumentException("Duplicate privilege has been found on privilege group element");
            }
            if (types.Count == 0)
            {
                Logging.Instance.Error("No privilege has been found on privilege group element");
                throw new ArgumentException("No privilege has been found on privilege group element");
            }
            var type = types[0].InnerText;

            var scopeAndCvr = xml.GetAttribute("Scope");
            var lastIndexOfSemiColon = scopeAndCvr.LastIndexOf(':');

            var scope = scopeAndCvr.Substring(0, lastIndexOfSemiColon);
            var privilegeCvr = scopeAndCvr.Substring(lastIndexOfSemiColon + 1);
            Scope = scope;
            Privilege = new Privilege(type, privilegeCvr);
        }

        /// <summary>
        ///     Scope of a privilege group
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        ///     Privilege of a privilege group
        /// </summary>
        public Privilege Privilege { get; set; }

        /// <summary>
        ///     A constraints list of a privilege group
        /// </summary>
        public List<Constraint> Constraints { get; private set; }

        /// <summary>
        ///     Determines whether the specified PrivilegeGroup is equal to the current one.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PrivilegeGroup other)
        {
            if (other == null)
                return false;

            if (Constraints.Count != other.Constraints.Count)
                return false;
            foreach (var constraint in Constraints)
            {
                if (!other.Constraints.Contains(constraint))
                    return false;
            }
            return Scope.Equals(other.Scope, StringComparison.InvariantCultureIgnoreCase)
                   && Privilege.Equals(other.Privilege);
        }
    }
}