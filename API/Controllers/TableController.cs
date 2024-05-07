using CSVAnalytics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        public static CSVTable _csv = new CSVTable("polakuman3.csv");
        public static Table _readTable = new Table(_csv);

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_readTable.table.SerializeDataFrame());
        }

        [HttpGet("{ColumnName}")]
        public IActionResult Get(string ColumnName)
        {
            return Ok(_readTable.table.ShowColumn(ColumnName));
        }
    }
}
