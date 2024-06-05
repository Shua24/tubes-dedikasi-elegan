using CSVAnalytics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        public static CSVTable s_csv = new("polakuman3.csv");
        public static Table s_readTable = new(s_csv);

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(s_readTable.CsvTable.SerializeDataFrame());
        }

        [HttpGet("{ColumnName}")]
        public IActionResult Get(string ColumnName)
        {
            return Ok(s_readTable.CsvTable.ShowColumn(ColumnName));
        }
    }
}
