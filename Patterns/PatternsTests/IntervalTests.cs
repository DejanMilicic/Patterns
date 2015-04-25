
namespace PatternsTests
{
	using Patterns;
	using Shouldly;

	public class IntervalTests
	{
		public void ClosedIntervalContains()
		{
			// [1, 5]
			Interval<int> interval = new Interval<int>(1, 5);

			// points
			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(true);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(true);
			interval.Contains(6).ShouldBe(false);

			// intervals
			// todo add open and semiopen intervals
			interval.Contains(new Interval<int>(-1, 0)).ShouldBe(false);
			interval.Contains(new Interval<int>(6, 10)).ShouldBe(false);
			interval.Contains(new Interval<int>(0, 2)).ShouldBe(false);
			interval.Contains(new Interval<int>(4, 6)).ShouldBe(false);

			interval.Contains(new Interval<int>(1, 3)).ShouldBe(true);
			interval.Contains(new Interval<int>(3, 5)).ShouldBe(true);
			interval.Contains(new Interval<int>(1, 5)).ShouldBe(true);
			interval.Contains(new Interval<int>(2, 4)).ShouldBe(true);
		}

		public void OpenIntervalContains()
		{
			// (1, 5)
			Interval<int> interval = new Interval<int>(false, 1, 5, false);

			// points
			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(false);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(false);
			interval.Contains(6).ShouldBe(false);

			// intervals
			// todo add open and semiopen intervals
			interval.Contains(new Interval<int>(-1, 0)).ShouldBe(false);
			interval.Contains(new Interval<int>(-1, 1)).ShouldBe(false);
			interval.Contains(new Interval<int>(6, 10)).ShouldBe(false);
			interval.Contains(new Interval<int>(5, 10)).ShouldBe(false);
			interval.Contains(new Interval<int>(1, 5)).ShouldBe(false);
			interval.Contains(new Interval<int>(0, 2)).ShouldBe(false);
			interval.Contains(new Interval<int>(4, 6)).ShouldBe(false);
			interval.Contains(new Interval<int>(1, 3)).ShouldBe(false);
			interval.Contains(new Interval<int>(3, 5)).ShouldBe(false);
			interval.Contains(new Interval<int>(2, 4)).ShouldBe(true);
		}

		public void LeftSemiopenIntervalContains()
		{
			// (1, 5]
			Interval<int> interval = new Interval<int>(false, 1, 5, true);

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
			Interval<int> interval = new Interval<int>(true, 1, 5, false);

			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(true);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(false);
			interval.Contains(6).ShouldBe(false);
		}
	}
}
