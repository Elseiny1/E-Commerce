using Application.DTOs;
using Application.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Application
{
    public static class DebendencyInjection
    {
        public static void AddApplication(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();

        }
    }
}
