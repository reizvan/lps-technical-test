namespace DocVault.Domain
{
    public class UploadedFile : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
