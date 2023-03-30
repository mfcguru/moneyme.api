using MediatR;
using MoneyMe.Api.Source.Domain.BusinessRules;
using MoneyMe.Api.Source.Infrastructure.DataProvider;
using System.Net.Mail;

namespace MoneyMe.Api.Source.Domain.Features.SubmitApplication
{
    public class SubmitApplicationCommand : IRequest
    {
        private readonly SubmitApplicationParameters parameters;
        public SubmitApplicationCommand(SubmitApplicationParameters parameters) => this.parameters = parameters;

        public class Handler : IRequestHandler<SubmitApplicationCommand>
        {
            private readonly IDataProvider dataProvider;
            public Handler(IDataProvider dataProvider)
            {
                this.dataProvider = dataProvider;
            }

            public async Task<Unit> Handle(SubmitApplicationCommand request, CancellationToken cancellationToken)
            {
                await Validations(request.parameters);

                //
                // add logic here to save application info to the database
                //

                return Unit.Value;
            }

            private async Task Validations(SubmitApplicationParameters parameters)
            {
                var address = new MailAddress(parameters.Email);
                var blockedDomainName = await dataProvider.FindBlocklistedDomainName(address.Host);
                if (blockedDomainName != null)
                {
                    throw new BlockedDomainException();
                }

                var blockedMobileNo = await dataProvider.FindBlocklistedMobileNo(parameters.Mobile);
                if (blockedMobileNo != null)
                {
                    throw new BlockedMobileNoException();
                }

                if (GetAge(parameters.DateOfBirth) < 18)
                {
                    throw new InvalidAgeException();
                }
            }

            private int GetAge(DateTime bornDate)
            {
                var today = DateTime.Today;
                var age = today.Year - bornDate.Year;
                if (bornDate > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}
