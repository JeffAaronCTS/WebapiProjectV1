using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;
using System.Security.Claims;
using System.Text;

using System.Text.Json;

using iTextSharp.text;

using iTextSharp.text.pdf;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

using WebapiProject.Repository;

namespace WebapiProject.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class ReportController : ControllerBase

    {

        private readonly IReportRepository _repo;

        public ReportController(IReportRepository reportRepository)

        {

            _repo = reportRepository;

        }


        [HttpGet("user-order")]

        public IActionResult GetUserOrderReport()

        {

            var report = _repo.GetUserOrderReport();

            return Ok(report);

        }

        [HttpGet("user-order-details")]
        public IActionResult GetUserOrderDetails()
        {
            try
            {
                // Get the user ID from the logged-in user
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User not logged in.");
                }

                // Fetch the user order details using the user ID
                var report = _repo.GetUserOrderDetails(int.Parse(userId));
                return Ok(report);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("stock-level")]

        public IActionResult GetStockLevelReport()

        {

            var report = _repo.GetStockLevelReport();

            return Ok(report);

        }

        [HttpGet("low-stock")]

        public IActionResult GetLowStockReport()

        {

            var report = _repo.GetLowStockReport();

            return Ok(report);

        }

        [HttpGet("sales")]

        public IActionResult GetSalesReport(DateTime startDate, DateTime endDate)

        {

            var report = _repo.GetSalesReport(startDate, endDate);

            return Ok(report);

        }

        [HttpGet("supplier-performance")]

        public IActionResult GetSupplierPerformanceReport()

        {

            var report = _repo.GetSupplierPerformanceReport();

            return Ok(report);

        }
        [HttpGet("product-demand")]

        public IActionResult GetProductDemandReport(DateTime startDate, DateTime endDate)

        {

            var report = _repo.GetProductDemandReport(startDate, endDate);

            return Ok(report);

        }
        [HttpGet("order-history")]
        public IActionResult GetOrderHistoryReport()
        {
            try
            {
                var report = _repo.GetOrderHistoryReport();
                return Ok(report);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
