using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.Models
{
    public class ImageView
    {
        public string Id { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
