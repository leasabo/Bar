﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Bar.Domain.Entities;
using Bar.Domain.Interfaces;

namespace Bar.Application.Handlers.WaiterHandlers
{
    public class CreateWaiterCommand : IRequest<Waiter>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateWaiterCommandValidator : AbstractValidator<CreateWaiterCommand>
    {
        public CreateWaiterCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        }
    }

    public class CreateWaiterHandler : IRequestHandler<CreateWaiterCommand, Waiter>
    {
        private readonly IWaiterRepository _waiterRepository;
        private readonly IMapper _mapper;

        public CreateWaiterHandler(IWaiterRepository waiterRepository, IMapper mapper)
        {
            _waiterRepository = waiterRepository;
            _mapper = mapper;
        }

        public async Task<Waiter> Handle(CreateWaiterCommand request, CancellationToken cancellationToken)
        {
            var waiter = _mapper.Map<Waiter>(request);
            await _waiterRepository.AddAsync(waiter);
            return waiter;
        }
    }
}