using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Services;

internal interface IImageFileResizeService
{
    void Resize(string sourceFilePath, string outFilePath, int longSideLength);
}
