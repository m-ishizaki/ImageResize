﻿using ImageResizeCore.Repositories;
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
        using var image = fileRepository.LoadImageFile(sourceFilePath);
        imageService.Resize(image, longSideLength);
        fileRepository.SaveImageFile(outFilePath, image);
    }
}
