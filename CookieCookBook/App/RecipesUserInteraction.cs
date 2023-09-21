﻿using CookieCookBook.Recipes;
using CookieCookBook.Recipes.Ingredients;

namespace CookieCookBook.App;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are:" + Environment.NewLine);

            //var counter = 1;
            //foreach (var recipe in allRecipes)
            //{
            //    Console.WriteLine($"*****{counter}*****");
            //    Console.WriteLine(recipe);
            //    Console.WriteLine();
            //    ++counter;
            //}

            var allRecipesAsString = allRecipes.Select((recipe, index)
                => 
$@"*****{index + 1}*****
{recipe}");

            Console.WriteLine(string.Join(Environment.NewLine, allRecipesAsString));
            Console.WriteLine();
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " +
            "Available ingredients are:");

        //foreach (var ingredient in _ingredientsRegister.All)
        //{
        //    Console.WriteLine(ingredient);
        //}

        Console.WriteLine(string.Join(Environment.NewLine, _ingredientsRegister.All));
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;

        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an integer by its ID, " +
                "or type anything else if finished.");

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetByID(id);

                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }
        return ingredients;
    }

    public void ShowMessage(string message) => Console.WriteLine(message);

    public void Exit() => Console.WriteLine("Press any key to close.");

}