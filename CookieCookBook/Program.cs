using CookieCookBook.App;
using CookieCookBook.DataAccess;
using CookieCookBook.FileAccess;
using CookieCookBook.Recipes.Ingredients;

namespace CookieCookBook;

public class Program
{
    static void Main(string[] args)
    {
        const FileFormat Format = FileFormat.Json;

        IStringsRepository stringsRepository = Format == FileFormat.Json ? 
            new StringsJsonRepository() : new StringsTexualRepository();

        const string FileName = "recipes";

        var fileMetadata = new FileMetaData(FileName, Format);

        var ingredientsRegister = new IngredientsRegister();

        var cookiesRecipesApp = new CookiesRecipesApp(
            new RecipesRepository(
                 stringsRepository, 
                 ingredientsRegister
            ),
            new RecipesConsoleUserInteraction(
                 ingredientsRegister
            )
        );
        cookiesRecipesApp.Run(fileMetadata.ToPath());
    }
}