
namespace PatternsTests
{
	using Patterns;
	using Shouldly;

	public class IntervalTests
	{
		public void ClosedIntervalTests()
		{
			// [1, 5]
			Interval<int> interval = new Interval<int>(1, 5);

			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(true);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(true);
			interval.Contains(6).ShouldBe(false);
		}

		public void OpenIntervalTests()
		{
			// (1, 5)
			Interval<int> interval = new Interval<int>(false, 1, 5, false);

			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(false);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(false);
			interval.Contains(6).ShouldBe(false);
		}

		public void LeftSemiopenIntervalTests()
		{
			// (1, 5]
			Interval<int> interval = new Interval<int>(false, 1, 5, true);

			interval.Contains(0).ShouldBe(false);
			interval.Contains(1).ShouldBe(false);
			interval.Contains(3).ShouldBe(true);
			interval.Contains(5).ShouldBe(true);
			interval.Contains(6).ShouldBe(false);
		}

		public void RightSemiopenIntervalTests()
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
