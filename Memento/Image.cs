using Memento.Common;
using System;

namespace Memento
{
    public class Image : File
    {
        public byte[] ImageBytes { get; set; }
        public Image(string name, double size, byte[] imageBytes) : base(name, size)
        {
            ImageBytes = imageBytes;
        }        
    }
}