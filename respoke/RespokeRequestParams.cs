using System;
using System.Collections.Generic;

namespace Respoke
{
	public class RespokeRequestParams {
		public Dictionary<string, object> Body = null;
		public string Path = null;
		public string Method = "GET";
		public string AppSecret = null;
	}
}

