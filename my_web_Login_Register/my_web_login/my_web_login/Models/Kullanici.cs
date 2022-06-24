using System.ComponentModel.DataAnnotations;

namespace my_web_login.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi{ get; set; }
       
        public string Sifre { get; set; }
        [Compare("Sifre", ErrorMessage = "Şifreler Uyuşmuyor !!")]//  şifre kontrol
        public string Sifre2 { get; set; }

    }
}
