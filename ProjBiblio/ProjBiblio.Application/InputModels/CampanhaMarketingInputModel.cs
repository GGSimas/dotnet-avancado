using System;
using FluentValidation;

namespace ProjBiblio.Application.InputModels
{
    public class CampanhaMarketingInputModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio {get; set;}
        public DateTime DataFim { get; set; }
        public double PercentualDesconto { get; set; }

    }


    public class CampanhaMarketingValidator: AbstractValidator<CampanhaMarketingInputModel> {
        public CampanhaMarketingValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("A descrição é um campo obrigatorio").Length(0, 100).WithMessage("O Tamanho máximo é de 100 caracteres");
            RuleFor(x => x.DataInicio).NotEmpty().WithMessage("O campo data inicio é obrigatorio");
            RuleFor(x => x.PercentualDesconto).NotEmpty().WithMessage("è obrigatório informar o percentual de desconto");
        }
    }
}