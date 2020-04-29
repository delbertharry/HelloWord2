using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWord2.Models;
using Microsoft.Data.SqlClient;

namespace HelloWord2.Controllers
{
    //private SqlConnection con;
     
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Simple1 s = new Simple1();
            SqlConnectionStringBuilder _sqlConnectorStr = new SqlConnectionStringBuilder();
            SqlConnection _Conn;
            SqlCommand command;
            SqlDataReader dr;

            s._Age = 037;
            s._Name = "Souffle";

            _sqlConnectorStr["Data Source"] = "(local)";
            _sqlConnectorStr["integrated Security"] = true;
            _sqlConnectorStr["Initial Catalog"] = "AdventureWorks2017";
            _sqlConnectorStr.UserID = "sa";
            _sqlConnectorStr.Password = "";
            //_sqlConnectorStr["UserID"] = "sa";
            //_sqlConnectorStr["Password"] = "";

            try
            {
                _Conn = new SqlConnection(_sqlConnectorStr.ConnectionString);
                _Conn.Open();
                command = new SqlCommand("select Name from Production.Location ", _Conn);
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    s.values.Add(dr["name"].ToString());
                }
                _Conn.Close();
            }
            catch (Exception)
            {
                s.values.Add("No values");
            }
            finally
            {
                //Do nothing
            }

            return View(s);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
