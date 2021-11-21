using ImageResizeCore.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Test;

internal class ImageServiceTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Bitmap source = new (100, 200);

        IImageService imageService = new ImageService();

        var result = imageService.Resize(source, 50);

        Assert.IsTrue(
            result.Width == 25
            && result.Height == 50
            );
    }

    [Test]
    public void Test2()
    {
        Bitmap source = new(400, 200);

        IImageService imageService = new ImageService();

        var result = imageService.Resize(source, 50);

        Assert.IsTrue(
            result.Width == 50
            && result.Height == 25
            );
    }

}
