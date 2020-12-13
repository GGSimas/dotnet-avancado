using FluentValidation;

namespace ProjBiblio.Application.InputModels
{
    public class GeneroInputModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }


    public class GeneroInputModelValidation: AbstractValidator<GeneroInputModel> {
        public GeneroInputModelValidation()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("A descrição do genero é obrigatória")
                .Length(0,100).WithMessage("A descrição deve conter no maxímo 100 caracteres");
        }
    }
}