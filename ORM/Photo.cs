using System;

namespace ORM
{
    public class Photo
    {
        public int PhotoId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public int AlbumId { get; set; }

        public DateTime LoadDateTime { get; set; }
    }
}
