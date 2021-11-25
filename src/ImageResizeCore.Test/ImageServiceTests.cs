using ImageResizeCore.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Test;

internal class ImageServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void 縦長()
    {
        Bitmap source = new(100, 200);

        IImageService imageService = new ImageService();

        var result = imageService.Resize(source, 50);

        Assert.IsTrue(result.Width == 25);
        Assert.IsTrue(result.Height == 50);
    }

    [Test]
    public void 横長()
    {
        Bitmap source = new(400, 200);

        IImageService imageService = new ImageService();

        var result = imageService.Resize(source, 50);

        Assert.IsTrue(result.Width == 50);
        Assert.IsTrue(result.Height == 25);
    }

    [Test]
    public void 縮小_色()
    {
        Bitmap source = new(20, 20);

        IImageService imageService = new ImageService();
        {
            using var g = Graphics.FromImage(source);
            g.FillRectangle(Brushes.Aqua, new(0, 0, 20, 20));
            g.FillRectangle(Brushes.Violet, new(0, 0, 2, 2));
            g.FillRectangle(Brushes.Violet, new(18, 18, 2, 2));
        }

        var result = imageService.Resize(source, 10);

        Assert.IsTrue(result.Width == 10);
        Assert.IsTrue(result.Height == 10);
        Assert.IsTrue(result.GetPixel(0, 0).ToArgb() == Color.Violet.ToArgb());
        Assert.IsTrue(result.GetPixel(9, 9).ToArgb() == Color.Violet.ToArgb());
        Assert.IsTrue(result.GetPixel(1, 0).ToArgb() == Color.Aqua.ToArgb());
        Assert.IsTrue(result.GetPixel(0, 1).ToArgb() == Color.Aqua.ToArgb());
        Assert.IsTrue(result.GetPixel(9, 0).ToArgb() == Color.Aqua.ToArgb());
        Assert.IsTrue(result.GetPixel(0, 9).ToArgb() == Color.Aqua.ToArgb());
    }

}
