namespace Vault.Core.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public byte[] Bytes { get; set; }
    }
}