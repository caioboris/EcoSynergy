using Microsoft.ML;

namespace FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;

public interface IPredicaoService
{
    string CaminhoModelo {  get; }
    string CaminhoTreinamento { get; }
    void TreinarModelo();
    MLContext mlContext { get; }
}
