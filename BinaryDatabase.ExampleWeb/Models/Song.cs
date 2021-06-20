using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryDatabase.ExampleWeb.Models
{
    [Serializable]
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
