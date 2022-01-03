using ImageResizeCore.Repositories;
using ImageResizeCore.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rksoftware.ArgumentsBuilder.Attributes;
using Rksoftware.ArgumentsBuilder.Hosts;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        // 登録
        services
            .AddSingleton<Service, Service>()
            .AddSingleton<IImageFileResizeService, ImageFileResizeService>()
            .AddSingleton<IImageService, ImageService>()
            .AddSingleton<IFileRepository, FileRepository>()
    )
    .Build();
host.ApplicationRun<Service, Arguments>(args);

class Service
{
    IImageFileResizeService imageFileResizeService;
    public Service(IImageFileResizeService imageFileResizeService) => (this.imageFileResizeService) = (imageFileResizeService);
    void Run(Arguments arguments) => imageFileResizeService.Resize(arguments.src ?? string.Empty, arguments.dest ?? string.Empty, (int.TryParse(arguments.size, out var size) ? size : 1368));
}

record struct Arguments([Parameter] string? src, [Parameter] string? dest, [Parameter] string? size) { }
