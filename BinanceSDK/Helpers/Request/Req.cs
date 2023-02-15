using System.Reflection;
using System.Text;

namespace BinanceSDK.Helpers.Request
{
	public abstract class Req
	{
		public string GetQueryString()
		{
			Type info = this.GetType();
			IEnumerable<FieldInfo> fields = info.GetRuntimeFields();
			var queryParams = _CollectQueryParams(fields);
			return _BuildQueryString(queryParams);
		}


		private string _BuildQueryString(List<string> queryParams)
		{
			const string delimiter = "&";
			if (queryParams.Count == 0)
			{
				return string.Empty;
			}

			StringBuilder sb = new StringBuilder(queryParams[0]);
			for (int i = 1; i < queryParams.Count; i++)
			{
				sb.Append(delimiter);
				sb.Append(queryParams[i]);
			}

			return sb.ToString();
		}


		private List<string> _CollectQueryParams(IEnumerable<FieldInfo> fields)
		{
			List<string> nameValues = new List<string>();

			foreach (FieldInfo field in fields)
			{
				Query? queryAttr = _FindQueryAttr(field);

				if (queryAttr != null)
				{
					object? value = field.GetValue(this);

					if (value != null)
					{
						string name = queryAttr.ParamName ?? field.Name;
						nameValues.Add($"{name}={value}");
					}
				}
			}

			return nameValues;
		}


		private Query? _FindQueryAttr(FieldInfo field)
		{
			IEnumerable<Attribute> attrs = field.GetCustomAttributes();
			foreach (Attribute attr in attrs)
			{
				if (attr is Query query)
				{
					return query;
				}
			}

			return null;
		}
	}
}
