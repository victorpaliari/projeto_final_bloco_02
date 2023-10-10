using FluentValidation;
using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
            public ProdutoValidator()
            {

                RuleFor(p => p.Nome)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(100);

                RuleFor(p => p.Preco)
                    .NotEmpty();

                RuleFor(p => p.Foto)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(5000);
            }
        }
}
