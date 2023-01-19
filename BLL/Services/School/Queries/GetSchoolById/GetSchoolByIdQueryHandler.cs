using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GetSchoolByIdQueryHandler : IRequestHandler<GetSchoolByIdQuery, SchoolDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public GetSchoolByIdQueryHandler(IUnitOfWork _uow, IMapper mapper)
        {
            uow = _uow;
            _mapper = mapper;
        }
        public async Task<SchoolDTO> Handle(GetSchoolByIdQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await uow.School.GetByIdAsync(c=>c.Id == request.Id);
            return _mapper.Map<SchoolDTO>(allPosts);
        }
    }
}
