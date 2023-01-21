using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FunctionAppContagem;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((services) =>
    {
        services.AddSingleton<Contador>();
    })
    .Build();

host.Run();