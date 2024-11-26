global using System.Text;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore.Metadata;
global using Microsoft.EntityFrameworkCore.Query;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Connections;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.VisualBasic;
global using Newtonsoft.Json;

global using MediatR;

global using FluentValidation.AspNetCore;
global using FluentValidation;

global using AutoMapper;

global using Hangfire;

global using Serilog.Sinks.MSSqlServer;
global using Serilog;

global using RabbitMQ.Client.Events;
global using RabbitMQ.Client;

global using FoodApp.Api.Extensions;

global using FoodApp.Api.Migrations;

global using System.Linq.Expressions;

global using FoodApp.Api.VerticalSlicing.Common;
global using FoodApp.Api.VerticalSlicing.Common.RabbitMQServices;
global using FoodApp.Api.VerticalSlicing.Common.Abstractions.Consts;

global using FoodApp.Api.VerticalSlicing.Features.Common;
global using FoodApp.Api.VerticalSlicing.Features.Common.Helper;

global using FoodApp.Api.VerticalSlicing.Features.Orders;
global using FoodApp.Api.VerticalSlicing.Features.Orders.CreateOrder.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Orders.CancelOrder.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Orders.AssignOrdersToDeliveryMan;
global using FoodApp.Api.VerticalSlicing.Features.Orders.AssignOrdersToDeliveryMan.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Orders.CreateOrder;
global using FoodApp.Api.VerticalSlicing.Features.Orders.UpdateOrderStatus;
global using FoodApp.Api.VerticalSlicing.Features.Orders.UpdateOrderStatus.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Orders.UpdateOrderStatusTrip.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Orders.UpdateOrderStatusTrip;
global using FoodApp.Api.VerticalSlicing.Features.Orders.UpdateOrderStatus.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Orders.CreateOrder.DTOs;
global using FoodApp.Api.VerticalSlicing.Features.Orders.CreateOrder.Queries;

global using FoodApp.Api.VerticalSlicing.Features.Account;
global using FoodApp.Api.VerticalSlicing.Features.Account.Common.Helper;
global using FoodApp.Api.VerticalSlicing.Features.Account.ForgotPassword;
global using FoodApp.Api.VerticalSlicing.Features.Account.ForgotPassword.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.Login;
global using FoodApp.Api.VerticalSlicing.Features.Account.Login.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.RefreshTokens.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.Register;
global using FoodApp.Api.VerticalSlicing.Features.Account.Register.Orchestrator;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResendVerificationCode;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResendVerificationCode.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResetPassword;
global using FoodApp.Api.VerticalSlicing.Features.Account.ResetPassword.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.RevokeToken.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.VerifyAccount;
global using FoodApp.Api.VerticalSlicing.Features.Account.VerifyAccount.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.Login.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Account.RefreshTokens.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Account.Register.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Account.Register.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Account.ChangePassword.Commands;

global using FoodApp.Api.VerticalSlicing.Features.Categories.AddCategory.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Categories.AddCategory;
global using FoodApp.Api.VerticalSlicing.Features.Categories.AddCategory.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Categories.DeleteCategory.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Categories.UpdateCategory;
global using FoodApp.Api.VerticalSlicing.Features.Categories.UpdateCategory.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Categories.ViewCategory;
global using FoodApp.Api.VerticalSlicing.Features.Categories.ViewCategory.Queries;

global using FoodApp.Api.VerticalSlicing.Features.Recipes;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.Common;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.Common.Helper;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.ViewRecipe;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.AddRecipe;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.AddRecipe.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.AddRecipeToFavourite;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.AddRecipeToFavourite.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.DeleteRecipe.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.GetLowestRatedRecipes;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.GetLowestRatedRecipes.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.GetTopRatedRecipes;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.GetTopRatedRecipes.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.ListRecipes;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.ListRecipes.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.RateRecipe;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.RateRecipe.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.RemoveRecipeFromFavourite.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.UpdateRecipe;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.UpdateRecipe.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.ViewFavouriteRecipes.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Recipes.RateRecipe.Queries;

global using FoodApp.Api.VerticalSlicing.Features.Users.DeleteUserProfile.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Users.GetAllUsers.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Users.GetUserProfile.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Users.UpdateUserProfile;
global using FoodApp.Api.VerticalSlicing.Features.Users.UpdateUserProfile.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Users.GetAllUsers;
global using FoodApp.Api.VerticalSlicing.Features.Users.GetUserEmailByUserId.Query;


global using FoodApp.Api.VerticalSlicing.Features.Roles.Common;
global using FoodApp.Api.VerticalSlicing.Features.Roles.AddRole;
global using FoodApp.Api.VerticalSlicing.Features.Roles.AddRole.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Roles.AssignRoleToUser;
global using FoodApp.Api.VerticalSlicing.Features.Roles.AssignRoleToUser.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Roles.AssignRoleToUser.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Roles.GetAllRoles.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRole.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRoleFromUser;
global using FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRoleFromUser.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Roles.RemoveRoleFromUser.Queries;

global using FoodApp.Api.VerticalSlicing.Features.Discounts;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.AddDiscount.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.AddDiscount;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.ApplyDiscount;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.ApplyDiscount.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.DeactivateDiscount.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.DeleteDiscount.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.GetActiveDiscounts;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.GetActiveDiscounts.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.UpdateDiscount;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.UpdateDiscount.Commands;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.ViewDiscount;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.ViewDiscount.Queries;
global using FoodApp.Api.VerticalSlicing.Features.Discounts.ApplyDiscount.Queries;


global using FoodApp.Api.VerticalSlicing.Features.Invoices.GenerateInvoice;


global using FoodApp.Api.VerticalSlicing.Data.Entities;
global using FoodApp.Api.VerticalSlicing.Data.Context;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Repository;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Interface;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Specification;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Specification.RecipeSpec;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Specification.DiscountSpec;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Specification.UsesrSpec;
global using FoodApp.Api.VerticalSlicing.Data.Repository.Specification.CategorySpec;