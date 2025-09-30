using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;
using FluentValidation.TestHelper;

public class CreateCategoryCommandValidatorTests
{
    private readonly CreateCategoryCommandValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var model = new CreateCategoryCommand("");
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Name_Is_Valid()
    {
        var model = new CreateCategoryCommand("Zara");
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }
}
