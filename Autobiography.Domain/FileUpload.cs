using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Domain
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string FileSrc { get; set; }
    }
}
