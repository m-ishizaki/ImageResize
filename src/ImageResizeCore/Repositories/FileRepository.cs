using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Repositories;

internal class FileRepository : IFileRepository
{
    public Bitmap LoadImageFile(string filePath)
    {
        using Bitmap file = new(filePath);
        return new (file);
    }

    public void SaveImageFile(string filePath, Bitmap image) => image?.Save(filePath);
}
