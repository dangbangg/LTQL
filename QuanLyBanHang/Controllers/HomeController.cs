using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using QuanLyBanHang.Models;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyBanHang.Controllers
{
    public class HomeController : Controller
    {
        QLBanHangEF db = new QLBanHangEF();
        public ActionResult Index(int maloaisp = 0)
        {
            if (maloaisp == 0)
            {
                var sanPhams = db.SanPhams.Include(S => S.LoaiSP);
                return View(sanPhams.ToList());
            }
            else
            {
                var sanPhams = db.SanPhams.Include(S => S.LoaiSP).Where(x=>x.MaLoaiSP==maloaisp);
                return View(sanPhams.ToList());
            }    
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email,string password)
        {
            if (ModelState.IsValid)
            {
                var mat_khau_ma_hoa = GETMD5(password);
                var kiem_tra_tai_khoan = db.KhachHangs.Where(s => s.Email.Equals(Email) && s.password.Equals(mat_khau_ma_hoa)).ToList();
                if (kiem_tra_tai_khoan != null)
                {
                    Session["MaKhachHang"] = kiem_tra_tai_khoan.FirstOrDefault().MaKH;
                    Session["TenKH"] = kiem_tra_tai_khoan.FirstOrDefault().TenKH;
                    var checkAdmin = kiem_tra_tai_khoan.FirstOrDefault().role;
                    if(checkAdmin == "admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }  
                    else
                    {
                        return RedirectToAction("Index");
                    }    
                    
                }
                else
                {
                    ViewBag.LoginError = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }
            }
             return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.KhachHangs.FirstOrDefault(m => m.Email == kh.Email);
                if(checkEmail == null)
                {
                    kh.password = GETMD5(kh.password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return RedirectToAction("Register");
                }
            }
            return View();
        }
        public static string GETMD5(string pass) 
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string mat_khau_ma_hoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mat_khau_ma_hoa += targetData[i].ToString("x2");

            }
            return mat_khau_ma_hoa;


        }
    }
}