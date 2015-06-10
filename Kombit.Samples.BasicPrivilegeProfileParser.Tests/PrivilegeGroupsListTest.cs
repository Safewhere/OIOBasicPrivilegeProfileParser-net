#region

using System.Collections.Generic;
using Xunit;

#endregion

namespace Kombit.Samples.BasicPrivilegeProfileParser.Tests
{
    public class PrivilegeGroupsListTest
    {
        /// <summary>
        ///     Parse a bpp xml to a list of PrivilegeGroup successfully
        /// </summary>
        [Fact]
        public void ParseXmlSuccessfully()
        {
            var bpp =
                "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4NCjxicHA6UHJpdmlsZWdlTGlzdCB4bWxuczpicHA9Imh0dHA6Ly9pdHN0LmRrL29pb3NhbWwvYmFzaWNfcHJpdmlsZWdlX3Byb2ZpbGUiIHhtbG5zOnhzaT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS9YTUxTY2hlbWEtaW5zdGFuY2UiPg0KICA8UHJpdmlsZWdlR3JvdXAgU2NvcGU9InVybjpkazpnb3Y6c2FtbDpjdnJOdW1iZXJJZGVudGlmaWVyOjEyMzQ1Njc4Ij4NCiAgICA8UHJpdmlsZWdlPmh0dHA6Ly9zYXBhLnRlc3Qta29tYml0LmRrL3JvbGVzL3VzZXJzeXN0ZW1yb2xlL3dpdGhEUi8xPC9Qcml2aWxlZ2U+DQogICAgPENvbnN0cmFpbnQgTmFtZT0iaHR0cDovL29yZ2FuaXNhdGlvbi50ZXN0LWtvbWJpdC5kay9jb25zdHJhaW50cy9LTEUiPjI8L0NvbnN0cmFpbnQ+DQogICAgPENvbnN0cmFpbnQgTmFtZT0iaHR0cDovL29yZ2FuaXNhdGlvbi50ZXN0LWtvbWJpdC5kay9jb25zdHJhaW50cy9TZW5zaXRpdml0eSI+SGlnaDwvQ29uc3RyYWludD4NCiAgPC9Qcml2aWxlZ2VHcm91cD4NCiAgPFByaXZpbGVnZUdyb3VwIFNjb3BlPSJ1cm46ZGs6Z292OnNhbWw6Y3ZyTnVtYmVySWRlbnRpZmllcjoxMjM0NTY3OCI+DQogICAgPFByaXZpbGVnZT5odHRwOi8vc2FwYS50ZXN0LWtvbWJpdC5kay9yb2xlcy91c2Vyc3lzdGVtcm9sZS93aXRoRFIvMjwvUHJpdmlsZWdlPg0KICAgIDxDb25zdHJhaW50IE5hbWU9Imh0dHA6Ly9vcmdhbmlzYXRpb24udGVzdC1rb21iaXQuZGsvY29uc3RyYWludHMvS0xFLU5FVyI+MTwvQ29uc3RyYWludD4NCiAgICA8Q29uc3RyYWludCBOYW1lPSJodHRwOi8vb3JnYW5pc2F0aW9uLnRlc3Qta29tYml0LmRrL2NvbnN0cmFpbnRzL1NlbnNpdGl2aXR5Ij5IaWdoPC9Db25zdHJhaW50Pg0KICA8L1ByaXZpbGVnZUdyb3VwPg0KICA8UHJpdmlsZWdlR3JvdXAgU2NvcGU9InVybjpkazpnb3Y6c2FtbDpjdnJOdW1iZXJJZGVudGlmaWVyOjg3NjU0MzIxIj4NCiAgICA8UHJpdmlsZWdlPmh0dHA6Ly9zYXBhLnRlc3Qta29tYml0LmRrL3JvbGVzL3VzZXJzeXN0ZW1yb2xlL25vRFIvMTwvUHJpdmlsZWdlPg0KICA8L1ByaXZpbGVnZUdyb3VwPg0KICA8UHJpdmlsZWdlR3JvdXAgU2NvcGU9InVybjpkazpnb3Y6c2FtbDpjdnJOdW1iZXJJZGVudGlmaWVyOjg3NjU0MzIxIj4NCiAgICA8UHJpdmlsZWdlPmh0dHA6Ly9zYXBhLnRlc3Qta29tYml0LmRrL3JvbGVzL3VzZXJzeXN0ZW1yb2xlL25vRFIvMjwvUHJpdmlsZWdlPg0KICA8L1ByaXZpbGVnZUdyb3VwPg0KICA8UHJpdmlsZWdlR3JvdXAgU2NvcGU9InVybjpkazpnb3Y6c2FtbDpjdnJOdW1iZXJJZGVudGlmaWVyOjk4NzY1NDMyIj4NCiAgICA8UHJpdmlsZWdlPmh0dHA6Ly9zYXBhLnRlc3Qta29tYml0LmRrL3JvbGVzL3VzZXJzeXN0ZW1yb2xlL25vRFIvMjwvUHJpdmlsZWdlPg0KICA8L1ByaXZpbGVnZUdyb3VwPg0KICA8UHJpdmlsZWdlR3JvdXAgU2NvcGU9InVybjpkazpnb3Y6c2FtbDpjdnJOdW1iZXJJZGVudGlmaWVyOjEyMTIxMjEyIj4NCiAgICA8UHJpdmlsZWdlPmh0dHA6Ly9zYXBhLnRlc3Qta29tYml0LmRrL3JvbGVzL3VzZXJzeXN0ZW1yb2xlL3dpdGhEUi8zPC9Qcml2aWxlZ2U+DQogICAgPENvbnN0cmFpbnQgTmFtZT0iaHR0cDovL29yZ2FuaXNhdGlvbi50ZXN0LWtvbWJpdC5kay9jb25zdHJhaW50cy9Lb3AiPjE8L0NvbnN0cmFpbnQ+DQogICAgPENvbnN0cmFpbnQgTmFtZT0iaHR0cDovL29yZ2FuaXNhdGlvbi50ZXN0LWtvbWJpdC5kay9jb25zdHJhaW50cy9TZW5zaXRpdml0eSI+TWVkaXVtPC9Db25zdHJhaW50Pg0KICA8L1ByaXZpbGVnZUdyb3VwPg0KPC9icHA6UHJpdmlsZWdlTGlzdD4=";
            var bppGroupsList = (List<PrivilegeGroup>) PrivilegeGroupParser.Parse(bpp);
            //var decodedBpp = Encoding.UTF8.GetString(Convert.FromBase64String(bpp));
            //var bppGroupsList = new PrivilegeGroupsList(decodedBpp);
            Assert.True(bppGroupsList.Count == 6);
            Assert.True(bppGroupsList[0].Constraints.Count == 2);
            Assert.True(bppGroupsList[0].Scope == "urn:dk:gov:saml:cvrNumberIdentifier");
            Assert.True(bppGroupsList[0].Privilege.Cvr == "12345678");
            Assert.True(bppGroupsList[0].Privilege.Type == "http://sapa.test-kombit.dk/roles/usersystemrole/withDR/1");
            Assert.True(bppGroupsList[0].Constraints[0].Name == "http://organisation.test-kombit.dk/constraints/KLE");
            Assert.True(bppGroupsList[0].Constraints[0].Value == "2");
            Assert.True(bppGroupsList[0].Constraints[1].Name ==
                        "http://organisation.test-kombit.dk/constraints/Sensitivity");
            Assert.True(bppGroupsList[0].Constraints[1].Value == "High");

            Assert.True(bppGroupsList[1].Constraints.Count == 2);
            Assert.True(bppGroupsList[1].Scope == "urn:dk:gov:saml:cvrNumberIdentifier");
            Assert.True(bppGroupsList[1].Privilege.Cvr == "12345678");
            Assert.True(bppGroupsList[1].Privilege.Type == "http://sapa.test-kombit.dk/roles/usersystemrole/withDR/2");
            Assert.True(bppGroupsList[1].Constraints[0].Name == "http://organisation.test-kombit.dk/constraints/KLE-NEW");
            Assert.True(bppGroupsList[1].Constraints[0].Value == "1");
            Assert.True(bppGroupsList[1].Constraints[1].Name ==
                        "http://organisation.test-kombit.dk/constraints/Sensitivity");
            Assert.True(bppGroupsList[1].Constraints[1].Value == "High");

            Assert.True(bppGroupsList[2].Constraints.Count == 0);
            Assert.True(bppGroupsList[2].Scope == "urn:dk:gov:saml:cvrNumberIdentifier");
            Assert.True(bppGroupsList[2].Privilege.Cvr == "87654321");
            Assert.True(bppGroupsList[2].Privilege.Type == "http://sapa.test-kombit.dk/roles/usersystemrole/noDR/1");

            Assert.True(bppGroupsList[3].Constraints.Count == 0);
            Assert.True(bppGroupsList[3].Scope == "urn:dk:gov:saml:cvrNumberIdentifier");
            Assert.True(bppGroupsList[3].Privilege.Cvr == "87654321");
            Assert.True(bppGroupsList[3].Privilege.Type == "http://sapa.test-kombit.dk/roles/usersystemrole/noDR/2");

            Assert.True(bppGroupsList[4].Constraints.Count == 0);
            Assert.True(bppGroupsList[4].Scope == "urn:dk:gov:saml:cvrNumberIdentifier");
            Assert.True(bppGroupsList[4].Privilege.Cvr == "98765432");
            Assert.True(bppGroupsList[4].Privilege.Type == "http://sapa.test-kombit.dk/roles/usersystemrole/noDR/2");

            Assert.True(bppGroupsList[5].Constraints.Count == 2);
            Assert.True(bppGroupsList[5].Scope == "urn:dk:gov:saml:cvrNumberIdentifier");
            Assert.True(bppGroupsList[5].Privilege.Cvr == "12121212");
            Assert.True(bppGroupsList[5].Privilege.Type == "http://sapa.test-kombit.dk/roles/usersystemrole/withDR/3");
            Assert.True(bppGroupsList[5].Constraints[0].Name == "http://organisation.test-kombit.dk/constraints/Kop");
            Assert.True(bppGroupsList[5].Constraints[0].Value == "1");
            Assert.True(bppGroupsList[5].Constraints[1].Name ==
                        "http://organisation.test-kombit.dk/constraints/Sensitivity");
            Assert.True(bppGroupsList[5].Constraints[1].Value == "Medium");
        }
    }
}