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
