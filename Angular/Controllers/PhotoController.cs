using BLL.Interfacies.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace GalleryForStudent.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IUserService userservice;
        private readonly IAlbumService albumservice;
        private readonly IPhotoService photoservice;
     
        public PhotoController(IUserService userService, IAlbumService albumService, IPhotoService photoService, ILikeService likeService)
        {
            this.userservice = userService;
            this.albumservice = albumService;
            this.photoservice = photoService;
        }
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private static int MaxStar = 5;
        [HttpPost]
        public ActionResult AddPhoto(IEnumerable<HttpPostedFileBase> uploads, int id)
        {
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    photoservice.AddToAlbum(id,
                        $"/Content/Images/UsersImages/profile{albumservice.GetAlbumEntity(id).UserId}_{id}" + fileName);
                    file.SaveAs(
                        Server.MapPath(
                            $"~/Content/Images/UsersImages/profile{albumservice.GetAlbumEntity(id).UserId}_{id}" +
                            fileName));
                }
            }
            return RedirectToAction("AlbumView", "UserAccount", new { id });
        }
        public ActionResult AddImage(HttpPostedFileBase file)
        {
            var fileName = file.FileName;
            var path = GetPathToImg(fileName);
            file.SaveAs(path);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveImage(string url)
        {
            var path = Server.MapPath(url);
            System.IO.File.Delete(path);
            
            return Json(true);
        }

        public JsonResult AddImageAjax(string fileName, string data)
        {
            var dataIndex = data.IndexOf("base64", StringComparison.Ordinal) + 7;
            var cleareData = data.Substring(dataIndex);
            var fileData = Convert.FromBase64String(cleareData);
            var bytes = fileData.ToArray();

            var path = GetPathToImg(fileName);
            using (var fileStream = System.IO.File.Create(path))
            {
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPhotos()
        {
            var photos = photoservice.GetAll().ToList();
            return Json(photos, JsonRequestBehavior.AllowGet);
        }

        private string GetPathToImg(string fileName)
        {
            var serverPath = Server.MapPath("~");
            return Path.Combine(serverPath, "Content", "img", fileName);
        }
    }
}