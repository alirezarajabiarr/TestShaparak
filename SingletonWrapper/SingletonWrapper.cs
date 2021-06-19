using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestShaparak.SingletonWrapper
{
	public abstract class SingletonWrapper<T>
	{
		#region Singleton
		// ReSharper disable once InconsistentNaming
		private static readonly Lazy<T> _instance;
		static SingletonWrapper()
		{
			_instance = new Lazy<T>(LazyThreadSafetyMode.ExecutionAndPublication);
		}
		public static T Instance => _instance.Value;
		#endregion

	}
}
