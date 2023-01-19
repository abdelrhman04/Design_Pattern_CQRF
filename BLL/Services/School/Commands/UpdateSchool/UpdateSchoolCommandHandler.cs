using AutoMapper;
using CORE.DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UpdateSchoolCommandHandler : IRequestHandler<UpdateSchoolCommand,SchoolDTO>
    {
        private readonly IUnitOfWork _postRepository;
        private readonly IMapper _mapper;
        public UpdateSchoolCommandHandler(IUnitOfWork postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<SchoolDTO> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            School post = _mapper.Map<School>(request);
            School post3= await _postRepository.School.UpdateAsync_Return(post);
            SchoolDTO post2 = _mapper.Map<SchoolDTO>(post3);
            return post2;

        }
    }
}
