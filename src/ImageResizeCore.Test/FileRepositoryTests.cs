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
            bitmap.Save(fileName);
        }

        IFileRepository fileRepository = new FileRepository();

        {
            using var bitmap = fileRepository.LoadImageFile(fileName);
            Assert.IsTrue(bitmap.Width == 3);
            Assert.IsTrue(bitmap.Height == 3);
        }
    }

    [Test]
    public void Save()
    {
        string filePath = Path.Combine(directoryPah, "test02.jpg");

        IFileRepository fileRepository = new FileRepository();

        fileRepository.SaveImageFile(filePath, new(3, 3));

        using Bitmap bitmap = new(filePath);
        Assert.IsTrue(bitmap.Width == 3);
        Assert.IsTrue(bitmap.Height == 3);
    }
}

