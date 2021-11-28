using ImageResizeCore.Repositories;
using ImageResizeCore.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Test;

internal class ImageFileResizeServiceTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_P01()
    {
        // test values
        const string sourceFfilePath = "sourcetestpath";
        const string outFilePath = "outtestpath";
        const int longSideLength = 2;
        System.Drawing.Bitmap sourceBitmap = new System.Drawing.Bitmap(1, 1);
        System.Drawing.Bitmap outBitmap = new System.Drawing.Bitmap(2, 2);

        // setup mock
        Moq.Mock<IFileRepository> moqFileRepository = new Moq.Mock<IFileRepository>();
        IFileRepository fileRepository = moqFileRepository.Object;
        {
            moqFileRepository.Setup(c => c.LoadImageFile(Moq.It.IsAny<string>())).Returns(sourceBitmap);
            moqFileRepository.Setup(c => c.SaveImageFile(Moq.It.IsAny<string>(), Moq.It.IsAny<System.Drawing.Bitmap>()));
        }
        Moq.Mock<IImageService> moqImageService = new Moq.Mock<IImageService>();
        IImageService imageService = moqImageService.Object;
        {
            moqImageService.Setup(c => c.Resize(Moq.It.IsAny<System.Drawing.Bitmap>(), Moq.It.IsAny<int>())).Returns(outBitmap);
        }

        // test
        IImageFileResizeService service = new ImageFileResizeService(fileRepository, imageService);
        service.Resize(sourceFfilePath, outFilePath, longSideLength);

        // Verify
        moqFileRepository.Verify(c => c.LoadImageFile(sourceFfilePath), Moq.Times.Once);
        moqImageService.Verify(c => c.Resize(sourceBitmap, longSideLength), Moq.Times.Once);
        moqFileRepository.Verify(c => c.SaveImageFile(outFilePath, outBitmap), Moq.Times.Once);
    }

    [Test]
    public void Test_P02()
    {
        // test values
        const string sourceFfilePath = "sourcetestpath02";
        const string outFilePath = "outtestpath02";
        const int longSideLength = 2;
        System.Drawing.Bitmap sourceBitmap = new System.Drawing.Bitmap(1, 1);
        System.Drawing.Bitmap outBitmap = new System.Drawing.Bitmap(2, 2);

        // setup mock
        Moq.Mock<IFileRepository> moqFileRepository = new Moq.Mock<IFileRepository>();
        IFileRepository fileRepository = moqFileRepository.Object;
        {
            moqFileRepository.Setup(c => c.LoadImageFile(Moq.It.IsAny<string>())).Returns(sourceBitmap);
            moqFileRepository.Setup(c => c.SaveImageFile(Moq.It.IsAny<string>(), Moq.It.IsAny<System.Drawing.Bitmap>()));
        }
        Moq.Mock<IImageService> moqImageService = new Moq.Mock<IImageService>();
        IImageService imageService = moqImageService.Object;
        {
            moqImageService.Setup(c => c.Resize(Moq.It.IsAny<System.Drawing.Bitmap>(), Moq.It.IsAny<int>())).Returns(outBitmap);
        }

        // test
        IImageFileResizeService service = new ImageFileResizeService(fileRepository, imageService);
        service.Resize(sourceFfilePath, outFilePath, longSideLength);

        // Verify
        moqFileRepository.Verify(c => c.LoadImageFile(sourceFfilePath), Moq.Times.Once);
        moqImageService.Verify(c => c.Resize(sourceBitmap, longSideLength), Moq.Times.Once);
        moqFileRepository.Verify(c => c.SaveImageFile(outFilePath, outBitmap), Moq.Times.Once);
    }
}

