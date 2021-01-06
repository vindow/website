﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Momentum.Auth.Core.Repositories;
using Momentum.Framework.Application.Services;

namespace Momentum.Auth.Application.Commands
{
    public class CreateOrUpdateUserTwitterCommand : IRequest
    {
        public string DisplayName { get; set; }
        public string OAuthKey { get; set; }
        public string OAuthSecret { get; set; }
    }

    public class CreateOrUpdateUserTwitterCommandHandler : IRequestHandler<CreateOrUpdateUserTwitterCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserTwitterRepository _userTwitterRepository;

        public CreateOrUpdateUserTwitterCommandHandler(IMapper mapper, ICurrentUserService currentUserService, IUserTwitterRepository userTwitterRepository)
        {
            _mapper = mapper;
            _currentUserService = currentUserService;
            _userTwitterRepository = userTwitterRepository;
        }

        public async Task<Unit> Handle(CreateOrUpdateUserTwitterCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();

            var existingItem = await _userTwitterRepository.GetByUserId(userId);

            var userTwitter = _mapper.Map(request, existingItem);
            userTwitter.UserId = userId;

            if (existingItem == null)
            {
                await _userTwitterRepository.Add(userTwitter);
            }
            else
            {
                await _userTwitterRepository.Update(userTwitter);
            }
            
            return Unit.Value;
        }
    }
}