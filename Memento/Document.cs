namespace Memento
{
    public class Document : IFile
    {
        public string Name { get; private set; }
        public double Size { get; private set; }
        public string Content { get; private set; }
    }
}