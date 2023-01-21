using System.Runtime.InteropServices;

namespace FunctionAppContagem.Models;

public class ResultadoContador
{
    private static readonly string _LOCAL;
    private static readonly string _KERNEL;
    private static readonly string _FRAMEWORK;

    static ResultadoContador()
    {
        _LOCAL = Environment.MachineName;
        _KERNEL = Environment.OSVersion.VersionString;
        _FRAMEWORK = RuntimeInformation.FrameworkDescription;
    }

    public int ValorAtual { get; init; }
    public int Incremento { get => Contador.INCREMENTO; }
    public string Local { get => _LOCAL; }
    public string Kernel { get => _KERNEL; }
    public string TargetFramework { get => _FRAMEWORK; }

    public ResultadoContador(int valorAtual)
    {
        ValorAtual = valorAtual;
    }
}