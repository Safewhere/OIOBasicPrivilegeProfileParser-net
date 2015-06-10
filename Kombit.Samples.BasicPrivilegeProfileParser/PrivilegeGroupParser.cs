#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;

#endregion

namespace Kombit.Samples.BasicPrivilegeProfileParser
{
    /// <summary>
    ///     Represent a parser that parses a valid xml to a list of PrivilegeGroup objects
    /// </summary>
    public class PrivilegeGroupParser
    {
        /// <summary>
        ///     Parse a bpp xml string to a list of PrivilegeGroup
        /// </summary>
        /// <param name="base64Xml"></param>
        /// <returns></returns>
        public static IEnumerable<PrivilegeGroup> Parse(string base64Xml)
        {
            var decodedBpp = Encoding.UTF8.GetString(Convert.FromBase64String(base64Xml));
            var xmlDocument = GetElement(decodedBpp);
            XmlNodeList xGroupsList =
                xmlDocument.GetElementsByTagName("PrivilegeGroup");
            return (from XmlNode xn in xGroupsList select new PrivilegeGroup((XmlElement) xn)).ToList();
        }

        /// <summary>
        ///     Convert a list of PrivilegeGroup to a json string
        /// </summary>
        /// <param name="bppGroupList"></param>
        /// <returns></returns>
        public static String ToJsonString(IEnumerable<PrivilegeGroup> bppGroupList)
        {
            return new JavaScriptSerializer().Serialize(bppGroupList);
        }

        /// <summary>
        ///     Convert a xml string to an xml element
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private static XmlElement GetElement(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }
    }
}