using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using FunctionAppContagem.Models;

namespace FunctionAppContagem;

public class ValorAtual
{
    private readonly ILogger _logger;
    private readonly Contador _contador;

    public ValorAtual(ILoggerFactory loggerFactory,
        Contador contador)
    {
        _logger = loggerFactory.CreateLogger<ValorAtual>();
        _contador = contador;
    }

    [Function("ValorAtual")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        int valorAtualContador;
        lock (_contador)
        {
            _contador.Incrementar();
            valorAtualContador = _contador.ValorAtual;
        }

        _logger.LogInformation($"Contador - Valor atual: {valorAtualContador}");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteAsJsonAsync(new ResultadoContador(valorAtualContador));
        return response;
    }
}