using FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace FIAP.GlobalSolution.EcoSynergy.Application.Services;

public class PredicaoService : IPredicaoService
{
    public string CaminhoModelo { get => Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloRecomendacao.zip"); }
    public string CaminhoTreinamento { get => Path.Combine(Environment.CurrentDirectory, "Data", "recomendacao-train.csv"); }

    public MLContext mlContext { get; }

    public PredicaoService()
    {
        mlContext = new MLContext();

        if (!System.IO.File.Exists(CaminhoModelo))
        {
            Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
            TreinarModelo();
        }
    }

    public void TreinarModelo()
    {
        var pastaModelo = Path.GetDirectoryName(CaminhoModelo);
        if (!Directory.Exists(pastaModelo))
        {
            Directory.CreateDirectory(pastaModelo);
            Console.WriteLine($"Diretório criado: {pastaModelo}");
        }

        IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosPredicao>(
            path: CaminhoTreinamento, hasHeader: true, separatorChar: ',');

        var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "LUMINOSIDADE", inputColumnName: nameof(DadosPredicao.ValorLuminosidade))
            .Append(mlContext.Transforms.CopyColumns(outputColumnName: "QUANTIDADEPAINEIS", inputColumnName: nameof(DadosPredicao.QuantidadePaineis)))
            .Append(mlContext.Transforms.CopyColumns(outputColumnName: "PRODUCAOMEDIAPORPAINEL", inputColumnName: nameof(DadosPredicao.ProducaoMediaPorPainel)))
            .Append(mlContext.Transforms.Concatenate("LUMINOSIDADE", "QUANTIDADEPAINEIS", "PRODUCAOMEDIAPORPAINEL"))
            .Append(mlContext.Regression.Trainers.FastTree());

        var modelo = pipeline.Fit(dadosTreinamento);

        mlContext.Model.Save(modelo, dadosTreinamento.Schema, CaminhoModelo);
        Console.WriteLine($"Modelo treinado e salvo em: {CaminhoModelo}");
    }
}

public class DadosPredicao
{
    [LoadColumn(0)] public float ValorLuminosidade { get; set; }
    [LoadColumn(1)] public int QuantidadePaineis { get; set; }
    [LoadColumn(2)] public float ProducaoMediaPorPainel { get; set; }
}

public class PredicaoProducao
{
    [ColumnName("ProducaoTotal")]
    public float ProducaoTotalEsperada { get; set; }
    [ColumnName("Paineis")]
    public int QuantidadePaineis { get; set; }
}
