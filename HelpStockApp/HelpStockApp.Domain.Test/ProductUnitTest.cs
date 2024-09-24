using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]

        public void CreateProduct_WithValidParameter_ResultObjectsValidState()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", "Feita de madeira e com assento confortável.", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalIdParameter_ResultException()
        {
            Action action = () => new Product(-1, "kit 4 Cadeiras", "Feita de madeira e com assento confortável.", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value.");

        }


        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalPriceParameter_ResultException()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", "Feita de madeira e com assento confortável.", -1, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Price, price negative value is unlikely!");
        }


        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalStockParameter_ResultException()
        {
            Action action = () => new Product(1,"kit 4 Cadeiras", "Feita de madeira e com assento confortável.", 300.50m, -2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Null Name")]
        public void CreateProduct_WithInvalShortNameParameter_ResultException()
        {
            Action action = () => new Product(1, null, "Feita de madeira e com assento confortável.", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }


        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithInvalNullNameParameter_ResultException()
        {
            Action action = () => new Product(1, "Ca", "Feita de madeira e com assento confortável.", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. Minimum 3 characters!");
        }


        [Fact(DisplayName = "Create Product With Null Description")]
        public void CreateProduct_WithInvalNullDescriptionParameter_ResultException()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", null, 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Description, description is required!");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithInvalShortDescriptionParameter_ResultException()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", "Cad", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 5 characters!");
        }

        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_WithInvalEmptyNameParameter_ResultException()
        {
            Action action = () => new Product(1, "", "Feita de madeira e com assento confortável.", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithInvalEmptyDescriptionParameter_ResultException()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", "", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Description, description is required!");
        }

        [Fact(DisplayName = "Create Product With Long Image Url")]
        public void CreateProduct_WithInvalLongImageUrlParameter_ResultException()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", "Feita de madeira e com assento confortável.", 300.50m, 2, "https://casahuma.cdn.magazord.com.br/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada/12345678/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada/12345678/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada/12345678/img/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada/12345678/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada/12345678/2024/02/produto/1892/cadeira-bela-madeira-macica-estofada/12345678.jpg");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Empty Image Url")]
        public void CreateProduct_WithInvalEmptyImageUrlParameter_ResultException()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", "Feita de madeira e com assento confortável.", 300.50m, 2, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Image, image is required!");
        }


        [Fact(DisplayName = "Create Product With Null Image Url")]
        public void CreateProduct_WithInvalNullImageUrlParameter_ResultException()
        {
            Action action = () => new Product(1, "kit 4 Cadeiras", "Feita de madeira e com assento confortável.", 300.50m, 2, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Image, image is required!");
        }

    }
}
