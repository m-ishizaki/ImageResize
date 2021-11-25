using ImageResizeCore.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Test;

internal class FileRepositoryTests
{
    string directoryPah = Path.Combine(Environment.CurrentDirectory, nameof(FileRepositoryTests));

    [SetUp]
    public void Setup()
    {
        if (!Directory.Exists(directoryPah)) Directory.CreateDirectory(directoryPah);
        foreach (var file in Directory.GetFiles(directoryPah)) File.Delete(file);
    }

    [Test]
    public void Load()
    {
        string fileName = Path.Combine(directoryPah, "test01.jpg");
        {
            using Bitmap bitmap = new(3, 3);
            using var g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Aqua, new(0, 0, 3, 3));
            g.FillRectangle(Brushes.Violet, new(0, 0, 1, 1));
            bitmap.Save(fileName);
        }

        IFileRepository fileRepository = new FileRepository();

        {
            using var bitmap = fileRepository.LoadImageFile(fileName);
            Assert.IsTrue(bitmap.Width == 3);
            Assert.IsTrue(bitmap.Height == 3);
            Assert.IsTrue(bitmap.GetPixel(0, 0).ToArgb() == Color.Violet.ToArgb());
            Assert.IsTrue(bitmap.GetPixel(1, 1).ToArgb() == Color.Aqua.ToArgb());
        }
    }

    [Test]
    public void Save()
    {
        string filePath = Path.Combine(directoryPah, "test02.jpg");

        {
            using Bitmap bitmap = new(3, 3);
            var g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Aqua, new(0, 0, 3, 3));
            g.FillRectangle(Brushes.Violet, new(0, 0, 1, 1));

            IFileRepository fileRepository = new FileRepository();

            fileRepository.SaveImageFile(filePath, bitmap);
        }

        {
            using Bitmap bitmap = new(filePath);
            Assert.IsTrue(bitmap.Width == 3);
            Assert.IsTrue(bitmap.Height == 3);
            Assert.IsTrue(bitmap.GetPixel(0, 0).ToArgb() == Color.Violet.ToArgb());
            Assert.IsTrue(bitmap.GetPixel(1, 1).ToArgb() == Color.Aqua.ToArgb());
        }
    }
}

