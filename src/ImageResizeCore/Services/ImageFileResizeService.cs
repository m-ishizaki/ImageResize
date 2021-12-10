using ImageResizeCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizeCore.Services;

internal class ImageFileResizeService : IImageFileResizeService
{
    IFileRepository fileRepository;
    IImageService imageService;

    public ImageFileResizeService(IFileRepository fileRepository, IImageService imageService)
    {
        this.fileRepository = fileRepository;
        this.imageService = imageService;
    }

    public void Resize(string sourceFilePath, string outFilePath, int longSideLength)
    {
        if (Directory.Exists(sourceFilePath))
            ResizeDirectory(sourceFilePath, outFilePath, longSideLength);
        else
            ResizeFile(sourceFilePath, outFilePath, longSideLength);
    }

    public void ResizeDirectory(string sourceFilePath, string outFilePath, int longSideLength)
    {
        foreach (var file in Directory.GetFiles(sourceFilePath).Select((filePath, index) => new { filePath, index }))
            ResizeFile(file.filePath, Path.Combine(outFilePath, (file.index + 1).ToString("000") + Path.GetExtension(file.filePath)), longSideLength);

    }

    public void ResizeFile(string sourceFilePath, string outFilePath, int longSideLength)
    {
        using var sourceImage = fileRepository.LoadImageFile(sourceFilePath);
        using var outImage = imageService.Resize(sourceImage, longSideLength);
        fileRepository.SaveImageFile(outFilePath, outImage);
    }
}
