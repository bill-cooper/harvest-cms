using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Orchard.Localization;
using Orchard.Media;
using Orchard.Media.Models;
using Orchard.Media.Services;
using Orchard.Media.ViewModels;
using Orchard.Security;
using Orchard.Themes;

namespace Orchard.MediaPicker.Controllers {
    [Themed(false)]
    public class AdminController : Controller {
        private readonly IMediaService _mediaService;
        private readonly IAuthorizer _authorizer;

        public IOrchardServices Services { get; set; }

        public AdminController(IOrchardServices services, IMediaService mediaService, IAuthorizer authorizer) {
            _authorizer = authorizer;

            Services = services;
            _mediaService = mediaService;

            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public ActionResult Index(string name, string mediaPath) {
            IEnumerable<MediaFile> mediaFiles = _mediaService.GetMediaFiles(mediaPath);
            IEnumerable<MediaFolder> mediaFolders = _mediaService.GetMediaFolders(mediaPath);
            var model = new MediaFolderEditViewModel { FolderName = name, MediaFiles = mediaFiles, MediaFolders = mediaFolders, MediaPath = mediaPath };
            ViewData["Service"] = _mediaService;
            return View(model);
        }

        [HttpPost]
        public JsonResult CreateFolder(string path, string folderName) {
            if (!Services.Authorizer.Authorize(Permissions.ManageMedia)) {
                return Json(T("Couldn't create media folder").ToString());
            }

            try {
                _mediaService.CreateFolder(HttpUtility.UrlDecode(path), folderName);
                return Json(true);
            }
            catch (Exception exception) {
                return Json(T("Creating Folder failed: {0}", exception.Message).ToString());
            }
        }
    }
}