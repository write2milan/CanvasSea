using canvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace canvas.Controllers
{
    public class FoodController : Controller
    {
        //
        // GET: /Food/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetFoodData()
        {
            CanvasSeaDBContext db = new CanvasSeaDBContext();
            List<FoodModel> listOfFood = db.food.ToList();
            return Json(listOfFood, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddFoodData(FoodModel foodmodeldata)
        {
            CanvasSeaDBContext db = new CanvasSeaDBContext();
            db.food.Add(foodmodeldata);
            db.SaveChanges();
            List<FoodModel> listOfFood = db.food.ToList();
            return Json(listOfFood, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetFoodByID(int foodid)
        {
            CanvasSeaDBContext db = new CanvasSeaDBContext();
            FoodModel _ofood = new FoodModel();
            _ofood = db.food.Find(foodid);
            return Json(_ofood, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateFoodData(FoodModel foodmodeldata)
        {
            CanvasSeaDBContext db = new CanvasSeaDBContext();
            db.Entry(foodmodeldata).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            List<FoodModel> listOfFood = db.food.ToList();
            return Json(listOfFood, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteFoodData(int foodid)
        {
            CanvasSeaDBContext db = new CanvasSeaDBContext();
            FoodModel _ofood = new FoodModel();
            _ofood = db.food.Find(foodid);
            db.Entry(_ofood).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            List<FoodModel> listOfFood = db.food.ToList();
            return Json(listOfFood, JsonRequestBehavior.AllowGet);
        }
	}
}