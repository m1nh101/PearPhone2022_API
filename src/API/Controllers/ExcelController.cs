using ClosedXML.Excel;
using Core.Interfaces;
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
        private readonly IReceiptForExcel _receiptForExcel;

        public ExcelController(IReceiptForExcel receiptForExcel)
        {
            _receiptForExcel = receiptForExcel;
        }
        #region Export Excel

        [HttpGet]
        public IActionResult ExportExcel(int orderId)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Receipt");

            ws.Cell("A1").Value = "OrderId";
            ws.Cell("B1").Value = "Seller";
            ws.Cell("C1").Value = "Total";
            ws.Cell("D1").Value = "Description";
            ws.Cell("E1").Value = "AddressId";
            ws.Cell("F1").Value = "Voucher";
            ws.Cell("G1").Value = "Status";

            var lst = _receiptForExcel.GetReciptForExcel(orderId);
            int row = 2;

            for (int i = 0; i < lst.Count; i++)
            {
                ws.Cell("A1" + row).Value = lst[i].OrderId;
                ws.Cell("B1" + row).Value = lst[i].Seller;
                ws.Cell("C1" + row).Value = lst[i].Total;
                ws.Cell("D1" + row).Value = lst[i].Description;
                ws.Cell("E1" + row).Value = lst[i].AddressId;
                ws.Cell("F1" + row).Value = lst[i].NameVoucher;
                ws.Cell("G1" + row).Value = lst[i].Status;
                row++;
            }

            string nameFile = "Export_" + DateTime.Now.Ticks + ".xlsx";
            //string pathFile = Server.MapPath("~/Resource/ExportExcel" + nameFile);

            //wb.SaveAs(pathFile);

            return Ok(nameFile);
        }

        #endregion
    }
}
