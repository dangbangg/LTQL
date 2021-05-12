﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;
using System.Collections;
namespace QuanLyBanHang.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            using(QLBanHangEF db = new QLBanHangEF())
            {
                var loaisp = db.LoaiSPs.ToList();
                Hashtable tenloaisp = new Hashtable();
                foreach(var item in loaisp)
                {
                    tenloaisp.Add(item.MaLoaiSP, item.TenLoaiSP);
                }
                ViewBag.TenLoaiSP = tenloaisp;
                return PartialView("Index");
            }
           
        }
    }
}