using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace Trining2.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult form1()
        {
            ViewBag.n1 = 0;
            ViewBag.n2 = 0;
            return View();
        }

        [HttpPost]
        public IActionResult form1(int n1, int n2 , string b1) 
        {
            double result;
            if (b1.Equals("Max"))
            {
               result =  Math.Max(n1, n2);
                
            }
            else if (b1.Equals("Min"))
            {
                result = Math.Min(n1, n2);
            }
            else 
            {
                result = (n1 + n2)/2;
            }
            ViewBag.n1 = n1.ToString();
            ViewBag.n2 = n2.ToString();
            ViewBag.b1 = result;
            return View();
        }

        [HttpGet]
        public IActionResult form2()
        {
            ViewBag.n1 = 0;
            ViewBag.n2 = 0;
            return View();
        }

        [HttpPost]
        public IActionResult form2(int n1, int n2 , string o1)
        {
            double result;
            if (o1.Equals("Add"))
            {
                result = (n1 + n2);
            } else if (o1.Equals("Sub"))
            {
                result = (n1 - n2);
            }
            else
            {
                result = ((n1/n2));
            }
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.o1 = result;
            return View();
        }

        [HttpGet]
        public IActionResult form3()
        {
            ViewBag.n1 = 0;
            ViewBag.n2 = 0;
            ViewBag.n3 = 0; 
            return View();
        }
        [HttpPost]
        public IActionResult form3(int n1 , int n2 , int n3)
        {
            int secondMin = n1;
            if ((n1 <= n2 && n1 >= n3) || (n1 >= n2 && n1 <=n3))
            {
               secondMin = n1;
            }else if ((n2 <= n1 && n2 >=n3) || (n2>= n1 && n2 <= n3)) 
            {
                secondMin = n2;
            }
            else
            {
                secondMin = n3;
            }
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.n3 = n3;
            ViewBag.r1 = secondMin;
            return View();
        }
        [HttpGet]
        public IActionResult form4()
        {
            return View();
        }
        [HttpPost]
        public IActionResult form4(string uname , string pass)
        {
            string status;
            if (uname.Equals("asp") && pass.Equals("asp"))
            {
                status = "valid user";
            }
            else
            {
                status = "Invalid user";
            }
            ViewBag.uname = uname;
            ViewBag.pass = pass;
            ViewBag.status = status;
            return View();
        }

        [HttpGet]
        public IActionResult form5(int n1 , int n2 , int n3)
        {
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.n3 = n3;
            return View();
        }
        [HttpPost]
        public IActionResult form5(int n1, int n2, int n3 , string b1)
        {
            if (b1.Equals("Max"))
            {
                TempData["result"] = (Math.Max(n1, Math.Max(n2,n3))).ToString();
                TempData["b1"] = "Max";
            }
            else
            {
                TempData["result"] = ((n1 + n2 + n3) / 3.0).ToString();
                TempData["b1"] = "Avg";
            }
            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.n3 = n3;
            return RedirectToAction("form6");
        }
        [HttpGet]
        public IActionResult form6()
        {
           
            return View();
        }
        [HttpPost]
        [ActionName("form6")]
        public IActionResult Back()
        {
            return RedirectToAction("form5");
        }
        [HttpGet]
        public IActionResult form7()
        {

            return View();
        }
        [HttpPost]
        public IActionResult form7(string pname,double price,int count)
        {
           double total = price * count;
            TempData["pname"] = pname;
            TempData["price"] = price.ToString();
            TempData["count"] = count.ToString();
            TempData["total"] = total.ToString();
            return RedirectToAction("form8");
        }
        [HttpGet]
        public IActionResult form8()
        {

            return View();
        }
        [HttpPost]
        [ActionName("form8")]
        public IActionResult back()
        {
            return RedirectToAction("form7");
        }
        [HttpGet]
        public IActionResult form9()
        {

            return View();
        }
        [HttpPost]
        public IActionResult form9(string uname, string pname)
        {
            HttpContext.Session.SetString("uname", uname);
            HttpContext.Session.SetString("pname", pname);
            return RedirectToAction("form10");
        }
        [HttpGet]
        public IActionResult form10()
        {
            return View();
        }
        [HttpPost]
        public IActionResult form10(double price, int count)
        {
            double total = price * count;
            TempData["price"] = price.ToString();
            TempData["count"] = count.ToString();
            TempData["total"] = total.ToString();
            return RedirectToAction("form11");
        }
        [HttpGet]
        public IActionResult form11()
        {
            ViewBag.uname = HttpContext.Session.GetString("uname");
            ViewBag.pname = HttpContext.Session.GetString("pname");
            return View();
        }
        [HttpPost]
        public IActionResult from11()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Form12()
        {
            var data = Request.Cookies["UserInfooro"];
            return View();

        }

        [HttpPost]
        public IActionResult Form12(string department, string tel, string desc)
        {

            if (department.Equals("IT"))
            {
                TempData["department"] = "IT";
            }
            else
            {
                TempData["department"] = "Pharmacy";
            }
            HttpContext.Session.SetString("tel", tel);
            if (desc != null)
            {
                CookieOptions obj = new CookieOptions();
                obj.Expires = DateTime.Now.AddDays(50);
                Response.Cookies.Append("UserInfooro", desc, obj);
                TempData["desc"] = desc.ToString();
            }

            return RedirectToAction("Form13");
        }

        [HttpGet]
        public IActionResult Form13()
        {
            ViewBag.tel = HttpContext.Session.GetString("tel");
            return View();
        }

        [HttpPost]
        public IActionResult Form13(string department, string tel, string desc)
        {
            return View();
        }
    }
}
