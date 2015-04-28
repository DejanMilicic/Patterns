
namespace PatternsTests
{
	using Patterns;
	using Shouldly;

	public class IntervalTests
	{
		public void Constructor()
		{
			// inverse interval
			bool exceptionInverseInterval = false;
			try
			{
				new Interval<int>(6, 5);
			}
			catch
			{
				exceptionInverseInterval = true;
			}
			exceptionInverseInterval.ShouldBe(true);

			// invalid left edge
			bool exceptionLeftEdgeChar = false;
			try
			{
				new Interval<int>('a', 2, 5, ')');
			}
			catch
			{
				exceptionLeftEdgeChar = true;
			}
			exceptionLeftEdgeChar.ShouldBe(true);

			// invalid right edge
			bool exceptionRightEdgeChar = false;
			try
			{
				new Interval<int>('[', 2, 5, 'b');
			}
			catch
			{
				exceptionRightEdgeChar = true;
			}
			exceptionRightEdgeChar.ShouldBe(true);

			// shorter constructor
			Interval<int> interval1 = new Interval<int>(2, 5);
			interval1.Start.Value.ShouldBe(2);
			interval1.Start.Closed.ShouldBe(true);
			interval1.Start.Open.ShouldBe(false);
			interval1.End.Value.ShouldBe(5);
			interval1.End.Closed.ShouldBe(true);
			interval1.End.Open.ShouldBe(false);

			// constructor
			Interval<int> interval2 = new Interval<int>('[', 2, 5, ']');
			interval2.Start.Value.ShouldBe(2);
			interval2.Start.Closed.ShouldBe(true);
			interval2.Start.Open.ShouldBe(false);
			interval2.End.Value.ShouldBe(5);
			interval2.End.Closed.ShouldBe(true);
			interval2.End.Open.ShouldBe(false);

			Interval<int> interval3 = new Interval<int>('(', 2, 5, ']');
			interval3.Start.Value.ShouldBe(2);
			interval3.Start.Closed.ShouldBe(false);
			interval3.Start.Open.ShouldBe(true);
			interval3.End.Value.ShouldBe(5);
			interval3.End.Closed.ShouldBe(true);
			interval3.End.Open.ShouldBe(false);

			Interval<int> interval4 = new Interval<int>('[', 2, 5, ')');
			interval4.Start.Value.ShouldBe(2);
			interval4.Start.Closed.ShouldBe(true);
			interval4.Start.Open.ShouldBe(false);
			interval4.End.Value.ShouldBe(5);
			interval4.End.Closed.ShouldBe(false);
			interval4.End.Open.ShouldBe(true);

			Interval<int> interval5 = new Interval<int>('(', 2, 5, ')');
			interval5.Start.Value.ShouldBe(2);
			interval5.Start.Closed.ShouldBe(false);
			interval5.Start.Open.ShouldBe(true);
			interval5.End.Value.ShouldBe(5);
			interval5.End.Closed.ShouldBe(false);
			interval5.End.Open.ShouldBe(true);
		}

		public void ClosedIntervalContains()
		{
			// [1, 5]
			Interval<int> interval = new Interval<int>('[', 2, 5, ']');

			// points
			interval.Contains(1).ShouldBe(false);
			interval.Contains(2).ShouldBe(true);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(true);
			interval.Contains(6).ShouldBe(false);

			// closed interval
			interval.Contains(new Interval<int>('[', 0, 1, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 1, 2, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 1, 3, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 4, 6, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 5, 6, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 6, 7, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 2, 2, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 2, 4, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 3, 5, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 2, 5, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 3, 4, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 5, 5, ']')).ShouldBe(true);

			//open interval
			interval.Contains(new Interval<int>('(', 0, 1, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 1, 2, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 1, 3, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 4, 6, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 5, 6, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 6, 7, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 2, 2, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 2, 4, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 3, 5, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 2, 5, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 3, 4, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 5, 5, ')')).ShouldBe(false);

			//semiopen left
			interval.Contains(new Interval<int>('(', 0, 1, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 1, 2, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 1, 3, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 4, 6, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 5, 6, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('(', 6, 7, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 2, 2, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 2, 4, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 3, 5, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 2, 5, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 3, 4, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('(', 5, 5, ']')).ShouldBe(false); // empty set

			//semiopen right
			interval.Contains(new Interval<int>('[', 0, 1, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 1, 2, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 1, 3, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 4, 6, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 5, 6, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 6, 7, ')')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 2, 2, ']')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 2, 4, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 3, 5, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 2, 5, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 3, 4, ')')).ShouldBe(true);
			interval.Contains(new Interval<int>('[', 5, 5, ')')).ShouldBe(true);
		}										 
												 
		public void OpenIntervalContains()
		{
			// (1, 5)
			Interval<int> interval = new Interval<int>('(', 2, 5, ')');

			// points
			interval.Contains(1).ShouldBe(false);
			interval.Contains(2).ShouldBe(false);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(false);
			interval.Contains(6).ShouldBe(false);

			// intervals
			// todo add open and semiopen intervals
			interval.Contains(new Interval<int>('[', 0, 1, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 1, 1, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 6, 7, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 5, 7, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 1, 5, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 0, 2, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 4, 6, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 1, 3, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 3, 5, ']')).ShouldBe(false);
			interval.Contains(new Interval<int>('[', 3, 4, ']')).ShouldBe(true);
		}

		public void LeftSemiopenIntervalContains()
		{
			// (1, 5]
			Interval<int> interval = new Interval<int>('(', 1, 5, ']');

			// points
			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(false);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(true);
			interval.Contains(6).ShouldBe(false);
		}

		public void RightSemiopenIntervalContains()
		{
			// [1, 5)
			Interval<int> interval = new Interval<int>('[', 1, 5, ')');

			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(true);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(false);
			interval.Contains(6).ShouldBe(false);
		}
	}
}
