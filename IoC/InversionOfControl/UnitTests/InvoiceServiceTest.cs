using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InversionOfControl;

namespace UnitTests
{
    [TestClass]
    public class InvoiceServiceTest
    {
        [TestMethod]
        public void TestCreateInvoice_IncludePorto()
        {
            // Arrange/Set-Up (Aufsetzen)

            decimal amount = 300;
            decimal expectetAmount = 310;
            InvoiceRepositoryMock repositoryMock = new InvoiceRepositoryMock();
            InvoiceService service = new InvoiceService(repositoryMock);

            // Act (Ausführen)

            service.CreateInvoice(amount);


            // Assert (Auswerten/Kontrollieren

            Assert.AreEqual(expectetAmount, repositoryMock.Invoice.Amount);

        }

        [TestMethod]
        public void TestCreateInvoice_NoPorto()
        {
            // Arrange/Set-Up (Aufsetzen)

            decimal amount = 1200;
            decimal expectetAmount = 1200;
            InvoiceRepositoryMock repositoryMock = new InvoiceRepositoryMock();
            InvoiceService service = new InvoiceService(repositoryMock);

            // Act (Ausführen)

            service.CreateInvoice(amount);

            // Assert (Auswerten/Kontrollieren

            Assert.AreEqual(expectetAmount, repositoryMock.Invoice.Amount);

        }
    }
}
