namespace Memento
{
    public class Image : IFile
    {
        public string Name { get; private set; }
        public double Size { get; private set; }
        public byte[] ImageBytes { get; set; }
        public Image(string name, double size, byte[] imageBytes)
        {
            (Name, Size, ImageBytes) = (name, size, imageBytes);
        }
    }
}