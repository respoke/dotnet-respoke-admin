using NUnit.Framework;
using System;
using Respoke;

namespace RespokeTests
{
	[TestFixture ()]
	public class HttpTests
	{
		[Test ()]
		public void GetSlash ()
		{
			Respoke.Http respoke = new Respoke.Http();
			RespokeResponse resp = respoke.Request("/", "GET", null);
			Assert.AreEqual(404, resp.statusCode);
			Assert.NotNull(resp.body);
		}
	}
}

