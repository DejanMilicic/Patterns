
namespace Patterns
{
	using System;
	using System.Globalization;

	public static class ConversionExtensions
	{
		public static int ToInt(this string stringValue, int defaultValue = 0)
		{
			if (stringValue == null) return defaultValue;
			int integer = Int32.TryParse(stringValue, out integer) ? integer : defaultValue;
			return integer;
		}

		public static DateTime? ToDateTime(this string dateTimeStr, string dateFmt = "yyyy-MM-ddTHH:mm:ss")
		{
			DateTime? result = null;
			DateTime dt;
			const DateTimeStyles Style = DateTimeStyles.AllowWhiteSpaces;
			if (DateTime.TryParseExact(dateTimeStr, dateFmt, CultureInfo.InvariantCulture, Style, out dt)) result = dt;
			return result;
		}
	}
}
