using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string ImageContentType { get; set; }
        public string ImageFileName { get; set; }
        public byte[] Thumbnail { get; set; }
        public string ThumbnailContentType { get; set; }
        public string ThumbnailFileName { get; set; }

    }
}
