using System.Collections.Generic;

namespace CST2550
{
	// This is used to send the dashboard stats back to the frontend as JSON.
	// The GetBreakdownStats() method in DatabaseManager fills this in.
	public class BreakdownStats
	{
		public int TodayCount { get; set; }
		public int ThisMonthCount { get; set; }
		public int TotalCount { get; set; }
		public int PendingCount { get; set; }
		public int InProgressCount { get; set; }
		public int CompletedCount { get; set; }

		// This list holds one entry per day for the last 30 days,
		// which is what the bar chart on the dashboard uses
		public List<DailyCount> Last30Days { get; set; } = new List<DailyCount>();
	}

	// One entry in the chart - a date label and how many breakdowns happened that day
	public class DailyCount
	{
		public string Date { get; set; }
		public int Count { get; set; }
	}
}