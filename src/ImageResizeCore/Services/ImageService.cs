using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Services;

internal class ImageService : IImageService
{
    public Bitmap Resize(Bitmap source, int longSideLength)
    {
        (int height, int width)
            = (source.Height > source.Width)
            ? (longSideLength, (int)(source.Width * (longSideLength / (float)source.Height)))
            : ((int)(source.Height * (longSideLength / (float)source.Width)), longSideLength)
            ;

        Bitmap result = new(width, height);
        using var g = Graphics.FromImage(result);
        g.DrawImage(source, 0, 0, width, height);
        return result;
    }
}

