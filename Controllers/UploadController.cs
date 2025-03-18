using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Susteni.Repository;
using Microsoft.Extensions.Options;
using System.Drawing;
using Susteni.Models.Account;
using System;
using Susteni.Models;
using Microsoft.Graph.ExternalConnectors;
using Microsoft.Extensions.Configuration;

namespace Susteni.Controllers
{
    public class UploadController : Controller
    {

        private readonly IConfiguration Configuration;

        public UploadController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AccountLogOnInfoItem GetLogonInfo()
        {
            AccountLogOnInfoItem logonInfo = new AccountLogOnInfoItem();

            logonInfo.UserId = HttpContext.Session.GetString("UserId");
            logonInfo.Password = HttpContext.Session.GetString("Password");
            logonInfo.Server = Configuration["MySettings:Server"];
            logonInfo.Database = Configuration["MySettings:Database"];

            return logonInfo;
        }


        public ActionResult AsyncUpload()
        {
            return View();
        }



        public async Task<ActionResult> Async_SaveLogo(IEnumerable<IFormFile> files, string CustomerGuid)
        {
            if (files != null)
            {
                CustomerRepository customerRepository = new CustomerRepository(Configuration);
                AccountLogOnInfoItem logonInfo = GetLogonInfo();
                FilerItem item = new FilerItem();

                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var fileExt = fileName.Substring(fileName.LastIndexOf(".")).ToLower();
                    MemoryStream stream = new MemoryStream();
                    //using (FileStream fileST = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    file.CopyTo(stream);
                    string result = "";

                    Bitmap bm_in = new(stream);
                    if (bm_in.Width > 480 || bm_in.Height > 480)
                    {

                        try
                        {
                            int width;
                            int height;
                            double scale;
                            double w;
                            double h;
                            width = bm_in.Width;
                            height = bm_in.Height;
                            w = bm_in.Width;
                            h = bm_in.Height;

                            if (width > height)
                            {
                                scale = (double)(h / w);
                                height = (int)(scale * 480);
                                width = 480;
                            }
                            else
                            {
                                scale = (double)(w / h);
                                width = (int)(scale * 480);
                                height = 480;
                            }

                            Bitmap bm_out = new Bitmap(width, height);
                            bm_out.SetResolution(72, 72);
                            Pen blackPen = new Pen(Color.DarkGray, 1);
                            Rectangle rect = new Rectangle(0, 0, width - 1, height - 1);

                            using (Graphics graphics = Graphics.FromImage(bm_out))
                            {
                                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                graphics.DrawImage(bm_in, 0, 0, bm_out.Width, bm_out.Height);
                                graphics.DrawRectangle(blackPen, rect);
                            }
                            bm_in.Dispose();
                            MemoryStream streamNew = new MemoryStream();
                            bm_out.Save(streamNew, System.Drawing.Imaging.ImageFormat.Png);
                            result = Convert.ToBase64String(streamNew.ToArray());
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        result = Convert.ToBase64String(stream.ToArray());
                    }

                    item.byte64string = result;
                    item.Ext = fileExt;
                    item.LinkGuid = CustomerGuid;


                    HttpContext.Session.SetString("Logo", result);

                    await customerRepository.uploadLogo(logonInfo, item);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }



        public async Task<ActionResult> Async_SavePicture(IEnumerable<IFormFile> files, string ShipGuid)
        {
            if (files != null)
            {
                ShipRepository shipRepository = new ShipRepository(Configuration);
                AccountLogOnInfoItem logonInfo = GetLogonInfo();
                FilerItem item = new FilerItem();

                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var fileExt = fileName.Substring(fileName.LastIndexOf(".")).ToLower();
                    MemoryStream stream = new MemoryStream();
                    //using (FileStream fileST = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    file.CopyTo(stream);
                    string result = "";

                    Bitmap bm_in = new(stream);
                    if (bm_in.Width > 480 || bm_in.Height > 480)
                    {

                        try
                        {
                            int width;
                            int height;
                            double scale;
                            double w;
                            double h;
                            width = bm_in.Width;
                            height = bm_in.Height;
                            w = bm_in.Width;
                            h = bm_in.Height;

                            if (width > height)
                            {
                                scale = (double)(h / w);
                                height = (int)(scale * 480);
                                width = 480;
                            }
                            else
                            {
                                scale = (double)(w / h);
                                width = (int)(scale * 480);
                                height = 480;
                            }

                            Bitmap bm_out = new Bitmap(width, height);
                            bm_out.SetResolution(72, 72);
                            Pen blackPen = new Pen(Color.DarkGray, 1);
                            Rectangle rect = new Rectangle(0, 0, width - 1, height - 1);

                            using (Graphics graphics = Graphics.FromImage(bm_out))
                            {
                                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                graphics.DrawImage(bm_in, 0, 0, bm_out.Width, bm_out.Height);
                                graphics.DrawRectangle(blackPen, rect);
                            }
                            bm_in.Dispose();
                            MemoryStream streamNew = new MemoryStream();
                            bm_out.Save(streamNew, System.Drawing.Imaging.ImageFormat.Png);
                            result = Convert.ToBase64String(streamNew.ToArray());
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        result = Convert.ToBase64String(stream.ToArray());
                    }

                    item.byte64string = result;
                    item.Ext = fileExt;
                    item.LinkGuid = ShipGuid;


                    HttpContext.Session.SetString("PictureShip", result);

                    await shipRepository.uploadPicture(logonInfo, item);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }


        public async Task<ActionResult> Async_SaveRapportDocFil(IEnumerable<IFormFile> files, string rapId, bool erstattSiste)
        {
            // The Name of the Upload component is "files"

            if (files != null)
            {
                ReportRepository rapportRepository = new ReportRepository(Configuration);
                AccountLogOnInfoItem logonInfo = GetLogonInfo();
                UploadReportFilerItem item = new UploadReportFilerItem();
                item.logonInfo = logonInfo;
                ReturnValueItem retur = new();

                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var fileExt = fileName.Substring(fileName.LastIndexOf(".")).ToLower();
                    MemoryStream stream = new MemoryStream();
                    //using (FileStream fileST = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    file.CopyTo(stream);
                    string result = Convert.ToBase64String(stream.ToArray());

                    item.RapId = rapId;
                    item.Base64String = result;
                    item.Ext = fileExt;
                    item.ErstattSiste = erstattSiste;

                    retur = await rapportRepository.uploadRapportDoc(item);
                    //if (retur.Base64String.Length > 0)
                    //{
                    //    HttpContext.Session.SetString("Preview", retur.Base64String);
                    //}
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public async Task<ActionResult> Async_SaveRapportPreviewFil(IEnumerable<IFormFile> files, string RapportFilerGuid)
        {
            // The Name of the Upload component is "files"

            if (files != null)
            {
                ReportRepository rapportRepository = new ReportRepository(Configuration);
                AccountLogOnInfoItem logonInfo = GetLogonInfo();
                UploadReportFilerItem item = new UploadReportFilerItem();
                item.logonInfo = logonInfo;
                ReturnValueItem retur = new();

                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var fileExt = fileName.Substring(fileName.LastIndexOf(".")).ToLower();
                    MemoryStream stream = new MemoryStream();
                    //using (FileStream fileST = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    file.CopyTo(stream);
                    string result = "";

                    Bitmap bm_in = new Bitmap(stream);
                    if (bm_in.Width > 480 || bm_in.Height > 480)
                    {

                        try
                        {
                            int width;
                            int height;
                            double scale;
                            double w;
                            double h;
                            width = bm_in.Width;
                            height = bm_in.Height;
                            w = bm_in.Width;
                            h = bm_in.Height;

                            if (width > height)
                            {
                                scale = (double)(h / w);
                                height = (int)(scale * 480);
                                width = 480;
                            }
                            else
                            {
                                scale = (double)(w / h);
                                width = (int)(scale * 480);
                                height = 480;
                            }

                            Bitmap bm_out = new Bitmap(width, height);
                            bm_out.SetResolution(72, 72);
                            Pen blackPen = new Pen(Color.DarkGray, 1);
                            Rectangle rect = new Rectangle(0, 0, width - 1, height - 1);

                            using (Graphics graphics = Graphics.FromImage(bm_out))
                            {
                                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                graphics.DrawImage(bm_in, 0, 0, bm_out.Width, bm_out.Height);
                                graphics.DrawRectangle(blackPen, rect);
                            }
                            bm_in.Dispose();
                            MemoryStream streamNew = new MemoryStream();
                            bm_out.Save(streamNew, System.Drawing.Imaging.ImageFormat.Png);
                            result = Convert.ToBase64String(streamNew.ToArray());
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        result = Convert.ToBase64String(stream.ToArray());
                    }

                    item.Base64String = result;
                    item.Ext = fileExt;
                    item.ErstattSiste = true;
                    item.ReportFilesGuid = RapportFilerGuid;

                    retur = await rapportRepository.uploadRapportPreview(item);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }


        public ActionResult Async_Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine("", "App_Data", fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        // System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
        
    }

}

