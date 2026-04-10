using Microsoft.AspNetCore.Mvc;

namespace CST2550.Controllers
{
	// API controller for all recovery record operations.
	// The frontend calls these endpoints to search, add, edit and delete records.
	[ApiController]
	[Route("api/[controller]")]
	public class RecoveryController : ControllerBase
	{
		private readonly RecoveryTree _tree;
		private readonly DatabaseManager _db;

		public RecoveryController(RecoveryTree tree, DatabaseManager db)
		{
			_tree = tree;
			_db = db;
		}

		// GET /api/recovery/{plate}
		// Searches the BST for a record with that number plate
		[HttpGet("{plate}")]
		public IActionResult Search(string plate)
		{
			var result = _tree.Search(plate);

			if (result == null)
				return NotFound();

			return Ok(result);
		}

		// POST /api/recovery
		// Adds a new breakdown - saves to the BST and the database
		[HttpPost]
		public IActionResult Add(RecoveryRecord record)
		{
			_tree.Add(record);
			_db.SaveToDatabase(record);
			return Ok();
		}

		// PUT /api/recovery
		// Updates an existing record - finds it in the BST, updates the object,
		// then saves the changes to the database as well
		[HttpPut]
		public IActionResult Update(RecoveryRecord record)
		{
			var existing = _tree.Search(record.NumberPlate);

			if (existing == null)
				return NotFound();

			// Update the copy held in memory by the BST
			existing.CarModel = record.CarModel;
			existing.Issue = record.Issue;
			existing.Location = record.Location;
			existing.Status = record.Status;
			existing.BreakdownTime = record.BreakdownTime;

			// Save the same changes to SQL
			_db.UpdateDatabase(record);

			return Ok();
		}

		// DELETE /api/recovery/{plate}
		// Removes a record from both the BST and the database
		[HttpDelete("{plate}")]
		public IActionResult Delete(string plate)
		{
			bool removed = _tree.Delete(plate);

			if (!removed)
				return NotFound();

			_db.DeleteFromDatabase(plate);
			return Ok();
		}

		// GET /api/recovery/all?sort=date&order=desc
		// Returns all records sorted by date or status - used by the All Breakdowns tab
		[HttpGet("all")]
		public IActionResult GetAll([FromQuery] string sort = "date", [FromQuery] string order = "desc")
		{
			var records = _db.GetAllRecords(sort, order);
			return Ok(records);
		}

		// GET /api/recovery/stats
		// Returns the stats used by the dashboard page
		[HttpGet("stats")]
		public IActionResult GetStats()
		{
			var stats = _db.GetBreakdownStats();
			return Ok(stats);
		}
	}
}
