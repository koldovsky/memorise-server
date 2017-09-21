using MemoBll;
using MemoDAL;
using Moq;
using NUnit.Framework;

namespace Memorise.Tests
{
    [TestFixture]
	[TestFixtureSource("GetMockedSut")]
    class CatalogBllTests
    {
		[Test]
		void GetAllCategoriesTest()
		{

		}

		private CatalogBll GetMockedSut()
		{
			Mock<IUnitOfWork> uow = new Mock<IUnitOfWork>();
			ConverterToDto converter = new ConverterToDto();
			var catalog = new CatalogBll(uow.Object, converter);
			return catalog;
		}
    }
}
