/// http://www.codeproject.com/Articles/168662/Time-Period-Library-for-NET
namespace Patterns
{
	using System;

	public class DateTimeRange
	{
		public DateTime? Start { get; private set; }
		public DateTime? End { get; private set; }

		public DateTimeRange(DateTime? start, DateTime? end)
		{
			if (start > end) throw new ArgumentException("Start date is greater than End date");

			Start = start;
			End = end;
		}

		public bool Includes(DateTime value)
		{
			if (!Start.HasValue && !End.HasValue)
			{
				// DateRange does not have Start nor End
				// so it does not exists - it hold no dates
				return false;
			}
			else if (Start.HasValue && End.HasValue)
			{
				return (Start <= value) && (value <= End);
			}
			else if (Start.HasValue) // semiopen interval [Start, )
			{
				return Start <= value;
			}
			else // End.HasValue - semiopen interval (, End]
			{
				return value <= End;
			}
		}

		// todo : implement
		//public bool Includes(DateRange range)
		//{
		//	return (Start <= range.Start) && (range.End <= End);
		//}
	}
}
