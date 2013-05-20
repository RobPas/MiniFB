using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFB.Models.Contexts;
using MiniFB.Models.ProfileSettings;
using System.Drawing;

namespace MiniFB.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IRepository<User> _userRepo;

        public ProfileController()
        {
            _userRepo = new Repository<User>();
        }

        public ProfileController(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public ActionResult Index(string username = null)
        {
            /* Om inget username skickas med visas den inloggades egna profilsida */
            if (username == null)
            {
                if (User.Identity.Name != null)
                {
                    User user = _userRepo.FindAll(u => u.UserName == User.Identity.Name).Include(u => u.NewsFeedItems).FirstOrDefault();

                    return View(user);
                }
            }
            else
            {
                User user = _userRepo.FindAll(u => u.UserName == username).Include(u => u.NewsFeedItems).FirstOrDefault();
                return View(user);
            }
            return HttpNotFound();
        }

        public ActionResult Edit(Guid id)
        {
            User user = _userRepo.FindByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            SettingsValidator sv = new SettingsValidator();

            if (ModelState.IsValid && sv.isValidSex(user.Sex))
            {


                //// Initialize variables
                //string sSavePath;
                //string sThumbExtension;
                //int intThumbWidth;
                //int intThumbHeight;

                //// Set constant values
                //sSavePath = "images/";
                //sThumbExtension = "_thumb";
                //intThumbWidth = 160;
                //intThumbHeight = 120;

                //// If file field isn’t empty
                //if (user.ProfilePictureInput != null)
                //{
                //    // Check file size (mustn’t be 0)
                //    HttpPostedFile myFile = user.ProfilePictureInput;
                //    int nFileLen = myFile.ContentLength;
                //    if (nFileLen == 0)
                //    {
                //        Console.Write("No file was uploaded.");
                //    }

                //    // Check file extension (must be JPG)
                //    if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg")
                //    {
                //        Console.Write("The file must have an extension of JPG");

                //    }

                //    // Read file into a data stream
                //    byte[] myData = new Byte[nFileLen];
                //    myFile.InputStream.Read(myData, 0, nFileLen);

                //    // Make sure a duplicate file doesn’t exist.  If it does, keep on appending an 
                //    // incremental numeric until it is unique
                //    string sFilename = System.IO.Path.GetFileName(myFile.FileName);
                //    int file_append = 0;
                //    while (System.IO.File.Exists(Server.MapPath(sSavePath + sFilename)))
                //    {
                //        file_append++;
                //        sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                //                         + file_append.ToString() + ".jpg";
                //    }

                //    // Save the stream to disk
                //    System.IO.FileStream newFile
                //            = new System.IO.FileStream(Server.MapPath(sSavePath + sFilename),
                //                                       System.IO.FileMode.Create);
                //    newFile.Write(myData, 0, myData.Length);
                //    newFile.Close();

                //    // Check whether the file is really a JPEG by opening it
                //    System.Drawing.Image.GetThumbnailImageAbort myCallBack =
                //                   new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                //    Bitmap myBitmap;
                //    try
                //    {
                //        myBitmap = new Bitmap(Server.MapPath(sSavePath + sFilename));

                //        // If jpg file is a jpeg, create a thumbnail filename that is unique.
                //        file_append = 0;
                //        string sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                //                                                 + sThumbExtension + ".jpg";
                //        while (System.IO.File.Exists(Server.MapPath(sSavePath + sThumbFile)))
                //        {
                //            file_append++;
                //            sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) +
                //                           file_append.ToString() + sThumbExtension + ".jpg";
                //        }

                //        // Save thumbnail and output it onto the webpage
                //        System.Drawing.Image myThumbnail
                //                = myBitmap.GetThumbnailImage(intThumbWidth,
                //                                             intThumbHeight, myCallBack, IntPtr.Zero);
                //        myThumbnail.Save(Server.MapPath(sSavePath + sThumbFile));
                //        user.ProfilePicture = sSavePath + sThumbFile;

                //        // Displaying success information
                //        Console.Write("File uploaded successfully!");

                //        // Destroy objects
                //        myThumbnail.Dispose();
                //        myBitmap.Dispose();
                //    }
                //    catch (ArgumentException errArgument)
                //    {
                //        // The file wasn't a valid jpg file
                //        Console.Write("The file wasn't a valid jpg file.");
                //        System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
                //    }
                //}














                _userRepo.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public bool ThumbnailCallback()
        {
            return false;
        } 
    }
}