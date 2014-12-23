using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Respoke;

namespace Respoke {
	public class RespokeClient {

		public string baseUrl;

		public RespokeClient () {
			baseUrl = "https://api.respoke.io/v1";
		}

		public RespokeClient(string customBaseUrl) {
			baseUrl = customBaseUrl;
		}

		public RespokeResponse Request (RespokeRequestParams parms) {
			Stream dataStream = null;
			RespokeResponse resObject = new RespokeResponse();
			HttpWebResponse response = null;

			WebRequest req = WebRequest.Create(baseUrl + parms.path);
			req.Method = parms.method;
			req.ContentType = "application/json";
			((HttpWebRequest)req).UserAgent = "Respoke .NET Client";

			if (parms.appSecret != null) {
				req.Headers.Add("App-Secret: " + parms.appSecret);
			}

			if (parms.body != null) {
				byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(parms.body));
				req.ContentLength = byteArray.Length;
				dataStream = req.GetRequestStream();
				dataStream.Write(byteArray, 0, byteArray.Length);
				dataStream.Close();
			} else {
				req.ContentLength = 0;
			}

			try {
				response = (HttpWebResponse)req.GetResponse();
			}
			catch (WebException ex) {
				resObject.threwException = true;
				response = (HttpWebResponse)ex.Response;
			}
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader(dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd();
			// Display the content.
			resObject.body = JsonConvert.DeserializeObject<RespokeResponseJson>(responseFromServer);
			resObject.statusCode = (int)response.StatusCode;
			// Clean up the streams.
			reader.Close();
			dataStream.Close();
			response.Close();


			return resObject;
		}

		public RespokeResponse GetEndpointTokenId (RespokeEndpointTokenRequestBody parms) {
			Dictionary<string, object> body = new Dictionary<string, object>();
			body.Add("appId", parms.appId);
			body.Add("endpointId", parms.endpointId);
			body.Add ("ttl", parms.ttl);

			if (parms.roleId != null) {
				body.Add ("roleId", parms.roleId);
			}
			if (parms.roleName != null) {
				body.Add ("roleName", parms.roleName);
			}

			return Request(new RespokeRequestParams() {
				body = body,
				method = "POST",
				path = "/tokens",
				appSecret = parms.appSecret
			});
		}
	}

	public class RespokeRequestParams {
		public Dictionary<string, object> body = null;
		public string path = null;
		public string method = "GET";
		public string appSecret = null;
	}
		
}

