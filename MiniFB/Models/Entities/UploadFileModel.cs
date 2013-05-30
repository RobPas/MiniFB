using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFB.Models.Entities
{
    public class UploadFileModel
    {
        //[FileSize(10240)]
        //[FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase File { get; set; }
    }
}