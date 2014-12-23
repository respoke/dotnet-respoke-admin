using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Respoke
{
	public class Http
	{
		public string baseUrl;

		public Http ()
		{
			baseUrl = "https://api.respoke.io/v1";
		}

		public Http (string customBaseUrl) {
			baseUrl = customBaseUrl;
		}

		public RespokeResponse Request (string path, string meth, object JsonData) {
			Stream dataStream = null;
			RespokeResponse resObject = new RespokeResponse();
			HttpWebResponse response = null;

			WebRequest req = WebRequest.Create(baseUrl + path);
			req.Method = meth;
			req.ContentType = "application/json";
			((HttpWebRequest)req).UserAgent = "Respoke .NET Client";

			if (JsonData != null) {
				byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(JsonData));
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
			resObject.body = JsonConvert.DeserializeObject (responseFromServer);
			resObject.statusCode = (int)response.StatusCode;
			// Clean up the streams.
			reader.Close();
			dataStream.Close();
			response.Close();


			return resObject;
		}

//		public string GetEndpointTokenId (string appId, string appSecret, string endpointId) {
//			
//		}
	}

	public class RespokeResponse {
		public object body;
		public int statusCode;
		public bool threwException = false;
	}
		
}

