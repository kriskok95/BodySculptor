﻿namespace BodySculptor.Identity.Services
{
    using BodySculptor.Common.Services;
    using BodySculptor.Identity.Constants;
    using BodySculptor.Identity.Data.Entities;
    using BodySculptor.Identity.Models.Identity;
    using BodySculptor.Identity.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenGeneratorService tokenGeneratorService;
        private readonly IExercisesRegisterService exercisesRegisterService;
        private readonly HttpClient client;

        public IdentityService(UserManager<User> userManager
            , ITokenGeneratorService tokenGeneratorService
            , IExercisesRegisterService exercisesRegisterService)
        {
            this.userManager = userManager;
            this.tokenGeneratorService = tokenGeneratorService;
            this.exercisesRegisterService = exercisesRegisterService;
            this.client = new HttpClient();
        }

        public async Task<Result<User>> Register(RegisterUserRquestModel userInput)
        {
            var user = new User
            {
                Email = userInput.Email,
                UserName = userInput.UserName,
            };

            var identityResult = await this.userManager
                .CreateAsync(user, userInput.Password);

            var isRegisterSuccessful = identityResult.Succeeded;

            var errors = identityResult
                .Errors
                .Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<User>.SuccessWith(user)
                : Result<User>.Failure(errors);
        }

        public async Task<Result<LoginOutputModel>> Login(LoginRequestModel userInput)
        {
            var user = await this.userManager
                .FindByNameAsync(userInput.UserName);

            if(user == null)
            {
                return Constants.InvalidCredentialsErrorMessage;
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, userInput.Password);

            if (!isPasswordValid)
            {
                return Constants.InvalidCredentialsErrorMessage;
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var token = this.tokenGeneratorService.GenerateToken(user, roles);

            return new LoginOutputModel(token);
        }

        public async Task<Result> CheckCredentials(LoginRequestModel model)
        {
            var user = await this.userManager
                .FindByNameAsync(model.UserName);

            if(user == null)
            {
                return Constants.InvalidCredentialsErrorMessage;
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
            {
                return Constants.InvalidCredentialsErrorMessage;
            }
            return true;
        }
    }
}
