using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/excels")]
    [Authorize(Roles = "admin")]
    public class ExcelController : ControllerBase
    {
        #region Export Excel

        [HttpGet]
        public IActionResult ExportExcel()
        {
            var wb = new XLWorkbook();
            wb.Worksheets.Add("Receipt");



            return Ok();
        }

        #endregion
    }
}
