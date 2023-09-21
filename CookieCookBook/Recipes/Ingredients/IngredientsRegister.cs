namespace CookieCookBook.Recipes.Ingredients;


public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamom(),
        new CocoaPowder()
    };

    public Ingredient GetByID(int id)
    {
        var allIngredientWithGivenId = All.Where(ingredient => ingredient.Id == id);

        if(allIngredientWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException($"More than one ingredients have ID equal to {id}.");
        }

        //if(All.Select(ingredient => ingredient.Id == id).Distinct().Count() != All.Count())
        //{
        //    throw new InvalidOperationException($"Some ingredients have duplicated Ids.");
        //}


        return allIngredientWithGivenId.FirstOrDefault();
    }
}