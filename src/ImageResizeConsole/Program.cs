using ImageResizeCore.Repositories;
using ImageResizeCore.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        // 登録
        services
            .AddSingleton<IImageFileResizeService, ImageFileResizeService>()
            .AddSingleton<IImageService, ImageService>()
            .AddSingleton<IFileRepository, FileRepository>()
    )
    .Build();

host.Services.GetService<IImageFileResizeService>()!.Resize(args.FirstOrDefault(string.Empty), args.Skip(1).FirstOrDefault(string.Empty), 1368);
