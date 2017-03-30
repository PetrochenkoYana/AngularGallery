using System;
using System.Collections.Generic;

namespace BLL.Interfacies.Entities
{
    public class PhotoEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public int AlbumId { get; set; }

        public DateTime LoadDateTime { get; set; }

        public int LikesAmount { get; set; }
    }
}
