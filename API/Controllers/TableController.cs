using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSVAnalytics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private static CSVTable tab = new CSVTable(@"D:\Codes\");
        //

        private static List<(object, object)> values = new List<(object, object)>
        {
            // TODO (Shua)
        };

        // TODO: GET, POST (Rakha)
    }
}
