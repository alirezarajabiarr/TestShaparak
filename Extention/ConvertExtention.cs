using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TestShaparak.Extention
{
	public static class ConvertExtention
	{
		public static string BitsStringToHexString(this string binary)
		{
			if (binary.Length % 8 != 0)
				throw new ArgumentException("Invalid Lenght");

			return Enumerable.Range(0, binary.Length / 8)
				.Select(i => Convert.ToByte(binary.Substring(i * 8, 8), 2).ToString("X2"))
				.Aggregate((a, b) => $"{a}{b}");
		}
		public static byte[] BitsStringToByteArray(this string binary)
		{
			if (binary.Length % 8 != 0)
				throw new ArgumentException("Invalid Lenght");

			return Enumerable.Range(0, binary.Length / 8)
				.Select(i => Convert.ToByte(binary.Substring(i * 8, 8), 2))
				.ToArray();
		}

		public static byte[] BitsStringToAsciiArray(this string binary)
		{
			if (binary.Length % 8 != 0)
				throw new ArgumentException("Invalid Lenght");


			return Encoding.ASCII.GetBytes(BitsStringToHexString(binary));
		}

		public static string BitsStringToAsciiHexString(this string binary)
		{
			if (binary.Length % 8 != 0)
				throw new ArgumentException("Invalid Lenght");

			return ToHexString(BitsStringToAsciiArray(binary));
		}


		public static byte[] HexStringToByteArray(this string hexString)
		{
			return Enumerable.Range(0, hexString.Length)
				.Where(x => x % 2 == 0)
				.Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
				.ToArray();
		}

		public static string ToHexString(this byte[] bytes)
		{
			return bytes.Select(t => t.ToString("X2")).Aggregate((a, b) => $"{a}{b}");
		}


		public static T DeserializeFromJsonString<T>(this string jsonString) where T : class, new()
		{
			object result;
			var js = new DataContractJsonSerializer(typeof(T));
			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
				result = js.ReadObject(ms);

			return result as T;
		}

		public static T DeserializeFromJson<T>(this byte[] jsonBuffer) where T : class, new()
		{
			return Encoding.UTF8.GetString(jsonBuffer).DeserializeFromJsonString<T>();
		}

		public static string SerializeDataContractAsJsonString(this object obj)
		{
			
			return JsonSerializer.Serialize(obj);
			
		}

		public static T DeepCopy<T>(this T obj) where T : class, new()
		{
			var result = Activator.CreateInstance<T>();

			foreach (var pi in obj.GetType().GetProperties().Where(t => t.CanRead && t.CanWrite).ToList())
			{
				pi.SetValue(result, pi.GetValue(obj, null), null);
			}

			return result;
		}
		public static string AsShamsiDateTime(this DateTime dt)
		{
			var pc = new PersianCalendar();
			return $"{pc.GetYear(dt):0000}/{pc.GetMonth(dt):00}/{pc.GetDayOfMonth(dt):00} {dt:HH:mm:ss}";
		}

		public static byte[] SerializeDataContractAsJson(this object obj)
		{
			return Encoding.UTF8.GetBytes(obj.SerializeDataContractAsJsonString());
		}

		public static T DeserializeJsonStreamToObj<T>(this Stream stream)
		where T : class, new()
		{
			var buffer = new byte[stream.Length];
			stream.Read(buffer, 0, buffer.Length);
			return buffer.DeserializeFromJson<T>();
		}

		public static string ExceptionToString(this Exception e)
		{
			return
				$"{e?.Message}{(e?.InnerException != null ? "\r\n" + ExceptionToString(e.InnerException) : string.Empty)}";
		}
		public static string AsMaskedPan(this string str)
		{
			if (string.IsNullOrWhiteSpace(str) || str.Length < 16) return null;
			return $"{str.Substring(0, 6)}{string.Empty.PadLeft(str.Length - 10, '*')}{str.Substring(str.Length - 4)}";
		}

	}
}
