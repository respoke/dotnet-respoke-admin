using System;

namespace Respoke
{
	public class RespokeResponseJson {
		public string tokenId;
		public string appId;
		public string endpointId;
		public string roleId;
		public string accountId;
		public int createTime;
		public int expiryTime;
		public string id;
		public bool forDevelopment;
		public DateTime createdAt;
		public string[] errors;
		public string error;
	}

	public class RespokeResponse {
		public RespokeResponseJson body;
		public int statusCode;
		public bool threwException = false;
	}
}

