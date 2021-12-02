using Memento.Common;

namespace Memento
{
    public class SSD : HardDisk
    {
        public SSD(string name, Storage storage) : base(name, storage) { }
    }
}