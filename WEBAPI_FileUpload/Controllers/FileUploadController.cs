using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WEBAPI_FileUpload.UploadRepo;

namespace WEBAPI_FileUpload.Controllers
{

    public class FileUploadController : ApiController
    {
        [Mime]
        public async Task<FileUploadDetails> Post()
        {
            // file path
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");

            // 
            var multiFormDataStreamProvider = new MultiFileUploadProvider(fileuploadPath);

            // Read the MIME multipart asynchronously 
            await Request.Content.ReadAsMultipartAsync(multiFormDataStreamProvider);

            string uploadingFileName = multiFormDataStreamProvider
                .FileData.Select(x => x.LocalFileName).FirstOrDefault();

            // Create response
            return new FileUploadDetails
            {

                FilePath = uploadingFileName,

                FileName = Path.GetFileName(uploadingFileName),

                FileLength = new FileInfo(uploadingFileName).Length,

                FileCreatedTime = DateTime.Now.ToLongDateString()
            };
        }
    }
}
