namespace CookieCookBook.Recipes.Ingredients;

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetByID(int id);
}