using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand>
    {
        private readonly IUnitOfWork uow;
        public DeleteSchoolCommandHandler(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public async Task<Unit> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
           var DeleteItem= await uow.School.GetByIdAsync(x=>x.Id==request.Id);
            await uow.School.DeleteAsync(DeleteItem);
            return Unit.Value;
        }
    }
}
