using Memento.Common;

namespace Memento
{
    public class USB : HardDisk
    {
        public USB(string name, Storage storage) : base(name, storage) { }
    }
}