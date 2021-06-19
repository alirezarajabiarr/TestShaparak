using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestShaparak.SingletonWrapper;
using System.Net.Http;
using System.Net.Http.Headers;
using TestShaparak.Extention;

namespace TestShaparak.Environments
{
	internal class Environments : SingletonWrapper<Environments>
	{
		public static string EngineBaseAddress { get; set; }

		static Environments()
		{
			EngineBaseAddress = "http://pftest.shaparak.com:9095/merchant"; //"http://192.168.0.18:9011/Services";
		}
		

		public output CallService<input, output>(input request) where output : class, new()// where input : class, new()
		{
			using (var client = new HttpClient())
			{
				var serviceName = "/webService/writeExternalRequest/";

				var byteArray = Encoding.ASCII.GetBytes("username:password1234");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = client.PostAsync($"{EngineBaseAddress}/{serviceName}",
					new StringContent(request?.SerializeDataContractAsJsonString(), Encoding.UTF8,
						"application/json")).Result;
				var contentBuffer = response.Content.ReadAsByteArrayAsync().Result;
				string returnjson = System.Text.Encoding.UTF8.GetString(byteArray);
				var engineResponse = contentBuffer.DeserializeFromJson<output>();
				return engineResponse;
			}
		}


		public string CallServiceString<input>(input request)// where input : class, new()
		{
			using (var client = new HttpClient())
			{
				var serviceName = "/webService/writeExternalRequest/";

				var byteArray = Encoding.ASCII.GetBytes("930659:123456");
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var json = request?.SerializeDataContractAsJsonString();
				var response = client.PostAsync($"{EngineBaseAddress}/{serviceName}",
					new StringContent(request?.SerializeDataContractAsJsonString(), Encoding.UTF8,
						"application/json")).Result;
				var contentBuffer = response.Content.ReadAsByteArrayAsync().Result;
				string returnjson = System.Text.Encoding.UTF8.GetString(contentBuffer);
				//var engineResponse = contentBuffer.DeserializeFromJson<output>();
				return returnjson;
			}
		}


		public string CallServiceTracking<input>(input request)// where input : class, new()
		{
			using (var client = new HttpClient())
			{
				var serviceName = "/webService/readRequestCartableWithFilter/";

				var byteArray = Encoding.ASCII.GetBytes("930659:123456");
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = client.PostAsync($"{EngineBaseAddress}/{serviceName}",
					new StringContent(request?.SerializeDataContractAsJsonString(), Encoding.UTF8,
						"application/json")).Result;
				var contentBuffer = response.Content.ReadAsByteArrayAsync().Result;
				string returnjson = System.Text.Encoding.UTF8.GetString(contentBuffer);
				//var engineResponse = contentBuffer.DeserializeFromJson<output>();
				return returnjson;
			}









		}
	}
}
