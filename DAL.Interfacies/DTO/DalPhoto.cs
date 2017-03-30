using System;

namespace DAL.Interfacies.DTO
{
    public class DalPhoto:IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public int AlbumId { get; set; }

        public DateTime LoadDateTime { get; set; }
    }
}
