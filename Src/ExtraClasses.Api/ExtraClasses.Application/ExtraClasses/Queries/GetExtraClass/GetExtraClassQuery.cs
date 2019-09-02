using MediatR;

namespace ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass
{
    public class GetExtraClassQuery: IRequest<ExtraClassViewModel>
    {
        public int Id { get; set; }
    }
}
