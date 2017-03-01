namespace WorkflowMax.Connector.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using WorkflowMax.Connector.Dto;

    [TestFixture]
    public class ResponseParserTests
    {
        [Test]
        public void CategoryList_Deserialization_WorksOk()
        {
            var content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<Response api-method=\"List\"><Status>OK</Status><Categories /></Response>";
            var x = ResponseParser.Deserialize<CategoriesResponse>(content);
            Assert.AreEqual(0, x.Categories.Count);
        }

        [Test]
        public void ClientAdd_Deserialization_ReturnProperClientObject()
        {
            var content =
                "<Response api-method=\"Add\"><Status>OK</Status><Client><ID>11587321</ID><Name>TestingClient2185576d-ba67-41bb-a66c-59cb1760b831</Name><Address></Address><City></City><Region></Region><PostCode></PostCode><Country></Country><PostalAddress></PostalAddress><PostalCity></PostalCity><PostalRegion></PostalRegion><PostalPostCode></PostalPostCode><PostalCountry></PostalCountry><Phone></Phone><Fax></Fax><Website></Website><ReferralSource></ReferralSource><ExportCode></ExportCode><IsProspect>No</IsProspect><IsArchived>No</IsArchived><IsDeleted>No</IsDeleted><Contacts /><Notes /></Client></Response>";

            var response = ResponseParser.Deserialize<ClientResponse>(content);

            Assert.AreEqual(11587321, response.Client.Id);
        }

        [Test]
        public void ClientList_Deserialization_WorksOk()
        {
            var content =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<Response api-method=\"List\"><Status>OK</Status><Clients><Client><ID>11571445</ID><Name>Redington</Name><Address></Address><City></City><Region></Region><PostCode></PostCode><Country></Country><PostalAddress></PostalAddress><PostalCity></PostalCity><PostalRegion></PostalRegion><PostalPostCode></PostalPostCode><PostalCountry></PostalCountry><Phone></Phone><Fax></Fax><Website></Website><ReferralSource></ReferralSource><ExportCode></ExportCode><IsProspect>No</IsProspect><IsArchived>No</IsArchived><IsDeleted>Yes</IsDeleted><Contacts /></Client></Clients></Response>";
            var x = ResponseParser.Deserialize<ClientsResponse>(content);
            Assert.AreEqual(1, x.Clients.Count);

            var redington = x.Clients.Single();
            Assert.AreEqual(11571445, redington.Id);
            Assert.AreEqual("Redington", redington.Name);
            Assert.AreEqual("No", redington.IsProspect);
            Assert.AreEqual("Yes", redington.IsDeleted);
            Assert.AreEqual("No", redington.IsArchived);
        }

        [Test]
        public void ErrorResponse_Deserialization_ThrowsApplicationException()
        {
            var messageContents = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<Response>
  <Status>ERROR</Status>
  <ErrorDescription>A detailed explanation of the error</ErrorDescription>
</Response>";

            Assert.Throws<ApplicationException>(() => ResponseParser.Deserialize<ErrorResponse>(messageContents));
        }
    }
}