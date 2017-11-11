namespace Vault.Core.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public LibraryItem LibraryItem { get; set; }
        public byte[] Bytes { get; set; }
    }
}