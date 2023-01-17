using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.DAL;
namespace BLL.Services
{
    public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, SchoolDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateSchoolCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<SchoolDTO> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            School post = mapper.Map<School>(request);
            post = await unitOfWork.School.AddAsync(post);
            return mapper.Map<SchoolDTO>(post);

        }
    }
}
