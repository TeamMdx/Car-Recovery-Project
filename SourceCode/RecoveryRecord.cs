using System;

namespace CST2550
{
	// This class just holds all the information for one breakdown record.
	// It maps directly to a row in the CarRecoveries table in SQL.
	public class RecoveryRecord
	{
		public string NumberPlate { get; set; }
		public string CarModel { get; set; }
		public string Issue { get; set; }
		public string Location { get; set; }
		public DateTime BreakdownTime { get; set; }
		public string Status { get; set; }

		// Need an empty constructor otherwise the API can't deserialise
		// the JSON it receives from the frontend
		public RecoveryRecord() { }

		public RecoveryRecord(string plate, string model, string issue, string location, DateTime time, string status)
		{
			NumberPlate = plate;
			CarModel = model;
			Issue = issue;
			Location = location;
			BreakdownTime = time;
			Status = status;
		}
	}
}
