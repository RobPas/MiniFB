using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFB.Models.Entities
{
    public class FileStringResult : FileResult
    {
        public string Data { get; set; }

        public FileStringResult(string data, string contentType)
            : base(contentType)
        {
            Data = data;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            if (Data == null) { return; }
            response.Write(Data);
        }
    }
}