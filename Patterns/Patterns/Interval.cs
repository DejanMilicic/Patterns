/// http://www.codeproject.com/Articles/168662/Time-Period-Library-for-NET
/// https://github.com/sestoft/C5/blob/master/C5.UserGuideExamples/Sets.cs
#pragma warning disable 1570
namespace Patterns
{
	using System;
	using System.Collections.Generic;

	public class Interval<T> where T: IComparable
	{
		public StartEdge Start { get; private set; }
		public EndEdge End { get; private set; }

		/// <summary>
		/// Creates closed interval
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		public Interval(T start, T end) : this('[', start, end, ']')
		{
		}

		public Interval(char startChar, T start, T end, char endChar)
		{
			if (start.CompareTo(end) > 0) throw new ArgumentException("Start is greater than End");
			if (startChar != '[' && startChar != '(') throw new ArgumentException("startChar");
			if (endChar != ']' && endChar != ')') throw new ArgumentException("endChar");

			bool startClosed = startChar == '[';
			bool endClosed = endChar == ']';

			this.Start = new StartEdge(start, startClosed);
			this.End = new EndEdge(end, endClosed);
		}

		public bool Contains(T point)
		{
			return this.Start.CompareTo(point) <= 0 && this.End.CompareTo(point) >= 0;
		}

		public bool Contains(Interval<T> other)
		{
			if (other == null) throw new ArgumentNullException("other");

			return this.Contains(other.Start) && this.Contains(other.End);
		}

		/***************/

		private bool Contains(StartEdge leftEdge)
		{
			if (leftEdge.Value.CompareTo(this.Start.Value) < 0 || this.End.Value.CompareTo(leftEdge.Value) < 0)
			{
				return false;
			}
			else if (this.Start.Value.CompareTo(leftEdge.Value) < 0 && leftEdge.Value.CompareTo(this.End.Value) < 0)
			{
				return true;
			}
			else // edge case
			{
				if (leftEdge.Value.CompareTo(this.Start.Value) == 0)
				{
					return this.Start.Closed || leftEdge.Open;
				}
				else // (leftEdge.Value == this.End.Value)
				{
					return leftEdge.Closed && this.End.Closed;
				}
			}
		}

		private bool Contains(EndEdge rightEdge)
		{
			if (rightEdge.Value.CompareTo(this.Start.Value) < 0 || this.End.Value.CompareTo(rightEdge.Value) < 0)
			{
				return false;
			}
			else if (this.Start.Value.CompareTo(rightEdge.Value) < 0 && rightEdge.Value.CompareTo(this.End.Value) < 0)
			{
				return true;
			}
			else // edge case
			{
				if (rightEdge.Value.CompareTo(this.End.Value) == 0)
				{
					return this.End.Closed || rightEdge.Open;
				}
				else // (rightEdge.Value == this.Start.Value)
				{
					return rightEdge.Closed && this.Start.Closed;
				}
			}
		}

		public bool OverlapsWith(Interval<T> other)
		{
			if (other == null) throw new ArgumentNullException("other");

			return this.Contains(other.Start) || this.Contains(other.End);		
		}

		public class Edge
		{
			public Edge(T value, bool closed)
			{
				this.Value = value;
				this.Closed = closed;
			}

			public T Value { get; private set; }
			public bool Closed { get; private set; }
			public bool Open { get { return !this.Closed; } }
		}

		public class StartEdge : Edge
		{
			public StartEdge(T value, bool closed): base(value, closed)
			{
			}

			public int CompareTo(T point)
			{
				if (this.Open && this.Value.CompareTo(point) == 0)
				{
					return 1;
				}

				return this.Value.CompareTo(point);
			}

			// todo : operators for (SE, SE), (EB, EB), (LB, RB)
		}

		public class EndEdge : Edge
		{
			public EndEdge(T value, bool closed): base(value, closed)
			{
			}

			public int CompareTo(T point)
			{
				if (this.Open && this.Value.CompareTo(point) == 0)
				{
					return -1;
				}

				return this.Value.CompareTo(point);
			}
		}
	}
}
