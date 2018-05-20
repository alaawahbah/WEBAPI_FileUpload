using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WEBAPI_FileUpload.UploadRepo
{
    public class FileUploadDetails 
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
        public string FileCreatedTime { get; set; }
        
    }
}