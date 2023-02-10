namespace BinanceSDK.Helpers
{
	public abstract class StringEnum
	{
		private readonly string _value;
		private static readonly Dictionary<Type, List<StringEnum>> _register
			= new Dictionary<Type, List<StringEnum>>();


		protected StringEnum(string value)
		{
			_value = value;
			_Register(this);
		}


		public override string ToString()
		{
			return _value;
		}


		public static T Parse<T>(string value) where T : StringEnum
		{
			Type type = typeof(T);
			List<StringEnum>? list = _register.GetValueOrDefault(type);
			if (list == null)
			{
				throw new Exception($"There is no registered values for a type {type}");
			}

			foreach (var instance in list)
			{
				if (instance.ToString() == value)
				{
					return (T)instance;
				}
			}

			throw new Exception($"Cannot find registered value ({value}) for type ({type})");
		}


		private static void _Register(StringEnum instance)
		{
			Type type = instance.GetType();
			List<StringEnum> values = _register.GetValueOrDefault(type) ?? new List<StringEnum>();

			foreach (var value in values)
			{
				if (value.ToString() == instance.ToString())
				{
					throw new Exception($"The value {instance} has already been registered in type {type}");
				}
			}

			values.Add(instance);
			_register[type] = values;
		}
	}
}
