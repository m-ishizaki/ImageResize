using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Repositories;

internal interface IFileRepository
{
    Bitmap LoadImageFile(string filePath);
    void SaveImageFile(string filePath, Bitmap image);
}
