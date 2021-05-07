using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        LookaheadEntities db = new LookaheadEntities();
        public ActionResult Index()
        {
            List<Forecast2ViewModel> emplist = db.Forecast2.Select(x => new Forecast2ViewModel
            {
                TheDate = x.TheDate,
                Operation = x.Operation,
                EquipmentToRig = x.EquipmentToRig,
                EquipmentFromRig = x.EquipmentFromRig,
                Vessels = x.Vessels,
                Personnel = x.Personnel
            }).ToList();
            return View(emplist);
        }

        public void ExportToExcel()
        {
            List<Forecast2ViewModel> emplist = db.Forecast2.Select(x => new Forecast2ViewModel
            {
                TheDate = x.TheDate,
                Operation = x.Operation,
                EquipmentToRig = x.EquipmentToRig,
                EquipmentFromRig = x.EquipmentFromRig,
                Vessels = x.Vessels,
                Personnel = x.Personnel
            }).ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");


            ws.Cells["A1"].Value = "Date";
            ws.Cells["B1"].Value = "Operation";
            ws.Cells["C1"].Value = "EquipmentToRig";
            ws.Cells["D1"].Value = "EquipmentFromRig";
            ws.Cells["E1"].Value = "Vessels";
            ws.Cells["F1"].Value = "Personnel";

            int rowStart = 2;
            foreach (var item in emplist)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.TheDate.ToString("MM/dd/yyyy");
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Operation;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.EquipmentToRig;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.EquipmentFromRig;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Vessels;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Personnel;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
    }
}