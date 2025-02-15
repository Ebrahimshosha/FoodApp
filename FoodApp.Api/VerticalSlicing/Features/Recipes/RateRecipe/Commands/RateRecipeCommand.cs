﻿namespace FoodApp.Api.VerticalSlicing.Features.Recipes.RateRecipe.Commands;

public record RateRecipeCommand(int RecipeId, int Rating, string? Review) : IRequest<Result>;

public class RateRecipeCommandHandler : BaseRequestHandler<RateRecipeCommand, Result>
{
    public RateRecipeCommandHandler(RequestParameters requestParameters) : base(requestParameters) { }

    public async override Task<Result> Handle(RateRecipeCommand request, CancellationToken cancellationToken)
    {
        if (request.Rating < 1 || request.Rating > 5)
        {
            return Result.Failure(OrderErrors.InvalidRating);
        }

        var recipeResult = await _mediator.Send(new GetRecipeByIdQuery(request.RecipeId));
        if (!recipeResult.IsSuccess)
        {
            return Result.Failure(RecipeErrors.RecipeNotFound);
        }

        var userId = _userState.ID;
        if (string.IsNullOrEmpty(userId))
        {
            return Result.Failure<UserResponse>(UserErrors.NoLoggedInUserFound);
        }

        var hasRatedRecipe = await _mediator.Send(new CheckUserRecipeRatingQuery(int.Parse(userId), request.RecipeId), cancellationToken);

        if (hasRatedRecipe)
        {
            return Result.Failure(RecipeErrors.RecipeAlreadyRated);
        }

        var rating = request.Map<RecipeRating>();
        rating.UserId = int.Parse(userId);
        rating.RecipeId = recipeResult.Data.Id;

        await _unitOfWork.Repository<RecipeRating>().AddAsync(rating);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
