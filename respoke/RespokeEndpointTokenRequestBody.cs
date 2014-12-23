using System;

namespace Respoke
{
	public class RespokeEndpointTokenRequestBody {
		public string appId = null;
		public string appSecret = null;
		public string endpointId = null;
		public int ttl = 86000;
		public string roleId = null;
		public string roleName = null;
	}
}

