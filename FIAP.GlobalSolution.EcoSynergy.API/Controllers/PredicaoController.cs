using FIAP.GlobalSolution.EcoSynergy.Application.Dtos;
using FIAP.GlobalSolution.EcoSynergy.Application.Interfaces;
using FIAP.GlobalSolution.EcoSynergy.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;

namespace FIAP.GlobalSolution.EcoSynergy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PredicaoController : ControllerBase
{
    private readonly IPredicaoService _predicaoService;

    public PredicaoController(IPredicaoService predicaoService)
    {
        _predicaoService = predicaoService;
    }

    [HttpPost("predicao")]
    public IActionResult Recomendar(PredicaoDTO model)
    {
        if (!System.IO.File.Exists(_predicaoService.CaminhoModelo))
        {
            return BadRequest("O modelo ainda não foi treinado.");
        }

        ITransformer modelo;
        using (var stream = new FileStream(_predicaoService.CaminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            modelo = _predicaoService.mlContext.Model.Load(stream, out var modeloSchema);
        }

        var engineRecomendacao = _predicaoService.mlContext.Model.CreatePredictionEngine<DadosPredicao, PredicaoProducao>(modelo);

        var recomendacao = engineRecomendacao.Predict(new DadosPredicao
        {
            ValorLuminosidade = model.ValorLuminosidade,
            QuantidadePaineis = model.QuantidadePaineis
        });

        return Ok(new
        {
            producaoEsperada = recomendacao.ProducaoTotalEsperada,
            quantidadePaineis = recomendacao.QuantidadePaineis
        });
    }

}
