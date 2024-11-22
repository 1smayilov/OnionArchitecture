﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Security.Extensions;
using Core.Security.Constants;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (userRoleClaims == null || !userRoleClaims.Any()) 
            throw new AuthorizationException("You are not authenticated.");

        bool isNotMatchedAUserRoleClaimWithRequestRoles = !userRoleClaims.Any(userRoleClaim =>
            userRoleClaim == GeneralOperationClaims.Admin || 
            request.Roles.Any(role => role == userRoleClaim) 
        );

        if (isNotMatchedAUserRoleClaimWithRequestRoles) 
            throw new AuthorizationException("You are not authorized.");

        TResponse response = await next();
        return response;
    }
}