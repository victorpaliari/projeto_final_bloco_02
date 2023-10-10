using FluentValidation;
using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {


            RuleFor(p => p.Tipo)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

        }
    }
}
