namespace DAL.Interfacies.DTO
{
   public class DalAlbum:IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AlbumImage { get; set; }

        public int UserId { get; set; }
    }
}
