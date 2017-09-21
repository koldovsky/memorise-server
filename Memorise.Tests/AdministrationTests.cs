using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MemoBll;

namespace Memorise.Tests
{
	[TestFixture]
	[TestFixtureSource("GetMockedSut")]
	class AdministrationTests
	{
		[Test]
		void GetAllRolesTest()
		{

		}

		private Administration GetMockedSut()
		{
			return new Administration();
		}
	}
}
