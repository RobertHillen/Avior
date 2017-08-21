using System.ComponentModel.DataAnnotations;
using Avior.Base.Interfaces;
using Avior.Business.Commands.Coach;
using Avior.Business.EntityConversions;
using Avior.Business.UnitOfWork;
using Avior.Business.UnitOfWork.Extensions;

namespace Avior.Business.Queries.Coach
{
    public sealed class GetCoachEditQuery : IQuery<EditCoachCommand>
    {
        [Required]
        public int Id { get; set; }
    }

    public sealed class GetCoachEditQueryHandler : IQueryHandler<GetCoachEditQuery, EditCoachCommand>
    {
        private readonly IDataUnitOfWork uow;

        public GetCoachEditQueryHandler(IDataUnitOfWork uow)
        {
            this.uow = uow;
        }

        public EditCoachCommand Handle(GetCoachEditQuery parameters)
        {
            return uow.Coaches.GetById(parameters.Id).ToEditCoachCommand();
        }
    }
}
