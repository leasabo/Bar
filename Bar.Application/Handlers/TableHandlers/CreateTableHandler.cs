using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Bar.Domain.Entities;
using Bar.Domain.Interfaces;

namespace Bar.Application.Handlers.TableHandlers
{
    public class CreateTableCommand : IRequest<Table>
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int WaiterId { get; set; }
    }

    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(x => x.Number).GreaterThan(0).WithMessage("Table number must be greater than 0.");
            RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Table capacity must be greater than 0.");
            RuleFor(x => x.WaiterId).GreaterThan(0).WithMessage("Waiter ID is required.");
        }
    }

    public class CreateTableHandler : IRequestHandler<CreateTableCommand, Table>
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public CreateTableHandler(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<Table> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<Table>(request);
            await _tableRepository.AddAsync(table);
            return table;
        }
    }
}