using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass
{
    public class GetExtraClassQuery: IRequest<ExtraClassViewModel>
    {
        public int Id { get; set; }
    }
}
