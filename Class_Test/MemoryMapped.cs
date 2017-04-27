using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.MemoryMappedFiles;
using System.IO;

namespace FilmCollection
{
    class MemoryMapped
    {
        void openFile()
        {
            MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(RecordOptions.BaseName, FileMode.Open, "VideoList");



        }
    }
}
