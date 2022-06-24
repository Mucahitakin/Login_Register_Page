using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using my_web_login.Models;


namespace my_web_login.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Kullanici kl)
        {
            SqlConnection con = new SqlConnection("Data source=MUCO;Integrated Security=True;Database=login_table");
            SqlCommand cmd = new SqlCommand("Sp_KullaniciLogin", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = kl.KullaniciAdi;
            cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = kl.Sifre;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            else
            {
                return View();
            }
            
            

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Kullanici kl)
        {
            if (ModelState.IsValid)
            {
                SqlConnection con = new SqlConnection("Data source=MUCO;Integrated Security=True;Database=login_table");
                SqlCommand cmd = new SqlCommand("Sp_KullanicilarRegister", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = kl.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = kl.Sifre;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Login");
            }
            else { return View(); }
        }
    }
}
