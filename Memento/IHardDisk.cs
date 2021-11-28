using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Memento
{
    public interface IHardDisk
    {
        string Name { get; set; }
        Storage Storage { get; set; }

        void AddFiles(List<IFile> files);
        void RemmoveFiles();
    }
}