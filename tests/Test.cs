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
			RespokeClient respoke = new RespokeClient();
			RespokeResponse resp = respoke.Request(new RespokeRequestParams{
				path = "/"
			});
			Assert.AreEqual(404, resp.statusCode);
			Assert.NotNull(resp.body);
			Assert.IsTrue(resp.threwException);
		}

		[Test ()]
		public void EndpointToken ()
		{
			RespokeClient respoke = new RespokeClient();
			RespokeEndpointTokenRequestBody reqParams = new RespokeEndpointTokenRequestBody () {
				appId = "391095be-6e83-40e3-90a5-439809ad2396",
				appSecret = "7e34caf2-1814-4e11-a8fd-7796b8c787a1",
				endpointId = "myendpoint123",
				roleId = "35D43FE7-CDE8-4DE0-BA5F-BC6A29DCF13A"
			};
			RespokeResponse resp = respoke.GetEndpointTokenId(reqParams);
			Assert.AreEqual(200, resp.statusCode);
			Assert.NotNull(resp.body);
			Assert.AreEqual(reqParams.appId, resp.body.appId);
			Assert.IsNotEmpty(resp.body.tokenId);
			Assert.IsFalse(resp.threwException);
		}
	}
}

