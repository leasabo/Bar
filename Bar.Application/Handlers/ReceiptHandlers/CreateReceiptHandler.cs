using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace Bar.Application.Handlers.ReceiptHandlers
{
    public class CreateReceiptCommand : IRequest<Receipt>
    {
        public int TableId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime EmissionDate { get; set; }
    }

    public class CreateReceiptCommandValidator : AbstractValidator<CreateReceiptCommand>
    {
        public CreateReceiptCommandValidator()
        {
            RuleFor(x => x.TableId).GreaterThan(0).WithMessage("Table ID is required.");
            RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("Total amount must be greater than 0.");
            RuleFor(x => x.EmissionDate).NotEmpty().WithMessage("Emission date is required.");
        }
    }

    public class CreateReceiptHandler : IRequestHandler<CreateReceiptCommand, Receipt>
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IMapper _mapper;

        public CreateReceiptHandler(IReceiptRepository receiptRepository, IMapper mapper)
        {
            _receiptRepository = receiptRepository;
            _mapper = mapper;
        }

        public async Task<Receipt> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = _mapper.Map<Receipt>(request);
            await _receiptRepository.AddAsync(receipt);
            return receipt;
        }
    }
}