using MediatR;

namespace ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass
{
    public class DeleteExtraClassCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
