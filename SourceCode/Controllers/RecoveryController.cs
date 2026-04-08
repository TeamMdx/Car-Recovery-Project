using Microsoft.AspNetCore.Mvc;

namespace CST2550.Controllers
{
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

        [HttpGet("{plate}")]
        public IActionResult Search(string plate)
        {
            var result = _tree.Search(plate);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public IActionResult Add(RecoveryRecord record)
        {
            _tree.Add(record);
            _db.SaveToDatabase(record);
            return Ok();
        }
    }
}
