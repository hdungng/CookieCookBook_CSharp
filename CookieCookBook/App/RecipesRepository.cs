using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.Recipes;
using CookieCookBook.DataAccess;

namespace CookieCookBook.App;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private const string Seperator = ",";
    private readonly IIngredientsRegister _ingredientsRegister;
    public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath) => 
        _stringsRepository.Read(filePath)
            .Select(RecipeFromString)
            .ToList();

    //List<string> recipesFromFile = _stringsRepository.Read(filePath);

    //var recipes = new List<Recipe>();

    //foreach (var recipeFromFile in recipesFromFile)
    //{
    //    var recipe = RecipeFromString(recipeFromFile);
    //    recipes.Add(recipe);
    //}

    //return recipes;


    private Recipe RecipeFromString(string recipeFromFile)
    {
        //var textualIds = recipeFromFile.Split(Seperator);
        //var ingredients = new List<Ingredient>();

        //foreach (var textualId in textualIds)
        //{
        //    var id = int.Parse(textualId);
        //    var ingredient = _ingredientsRegister.GetByID(id);
        //    ingredients.Add(ingredient);
        //}

        //return new Recipe(ingredients);
        var ingredients = recipeFromFile.Split(Seperator)
            .Select(int.Parse)
            .Select(_ingredientsRegister.GetByID);

        return new Recipe(ingredients);
    }



    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipeAsStrings = allRecipes.Select(recipe =>
        {
            var allIds = recipe.Ingredients
                .Select(ingredient => ingredient.Id);

            return string.Join(Seperator, allIds);
        });

        _stringsRepository.Write(filePath, recipeAsStrings.ToList());
    }
}
