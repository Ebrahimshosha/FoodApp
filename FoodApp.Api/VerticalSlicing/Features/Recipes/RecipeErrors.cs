﻿namespace FoodApp.Api.VerticalSlicing.Features.Recipes;

public class RecipeErrors
{

    public static readonly Error RecipeNotFound =
        new("Recipe is not found", StatusCodes.Status404NotFound);

    public static readonly Error RecipeNotCreated =
    new("An error occurred while creating the recipe", StatusCodes.Status400BadRequest);

    public static readonly Error FavouriteRecipeNotFound =
      new("FavouriteRecipe is not found", StatusCodes.Status404NotFound);

    public static readonly Error FavouriteRecipeAlreadyExists =
        new("FavouriteRecipe Already Exists", StatusCodes.Status409Conflict); 
    
    public static readonly Error RecipeAlreadyExists =
        new("Recipe Already Exists", StatusCodes.Status409Conflict);

    public static readonly Error RecipeAlreadyRated =
        new("Recipe Already Rated", StatusCodes.Status409Conflict);
}