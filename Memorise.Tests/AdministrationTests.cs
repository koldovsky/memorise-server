using MemoBll.Managers;
using NUnit.Framework;

namespace Memorise.Tests
{
	[TestFixture]
	class AdministrationTests
	{
		[Test]
		public void GetAllRolesTest()
		{

		}

		private AdministrationBll GetMockedSut()
		{
			return new AdministrationBll();
		}
	}
}
