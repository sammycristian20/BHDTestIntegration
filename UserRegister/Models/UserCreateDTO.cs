using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace UserRegister.Models
{
    public class UserCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<PhoneDto> Phones { get; set; } = new();

    }

    public class PhoneDto
    {
        public string Number { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }


public static class UserEndpoints
{
	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

        group.MapGet("/", () =>
        {
            return new [] { new User() };
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new User { ID = id };
        })
        .WithName("GetUserById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, User input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateUser")
        .WithOpenApi();

        group.MapPost("/", (User model) =>
        {
            //return TypedResults.Created($"/api/Users/{model.ID}", model);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new User { ID = id });
        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }
}}
