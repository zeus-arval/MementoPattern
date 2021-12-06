using Memento.Common;

namespace Memento
{
    public class Document : File
    {
        public string Content { get; private set; }

        public Document(string name, double size, string content) : base(name, size)
            => Content = content;
    }
}