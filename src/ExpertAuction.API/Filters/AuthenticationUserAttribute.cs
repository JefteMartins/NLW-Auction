﻿using ExpertAuction.API.Contracts;
using ExpertAuction.API.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpertAuction.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        private IUserRepository _repository;

        public AuthenticationUserAttribute(IUserRepository repository)
        {
            _repository = repository;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);

                var email = FromBase64String(token);

                var exist = _repository.ExistUserWithEmail(email);

                if (!exist)
                    context.Result = new UnauthorizedObjectResult("E-mail not valid!");
            }
            catch(Exception ex)
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authentication) || !authentication.StartsWith("Bearer "))
                throw new Exception("Token not found");

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string token)
        {
            var data = Convert.FromBase64String(token);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}