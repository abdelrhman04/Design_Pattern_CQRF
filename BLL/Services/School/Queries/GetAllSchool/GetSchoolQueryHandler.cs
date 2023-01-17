using AutoMapper;
using MediatR;

namespace BLL.Services
{
    public class GetSchoolQueryHandler : IRequestHandler<GetSchoolQuery, List<SchoolDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public GetSchoolQueryHandler(IUnitOfWork _uow, IMapper mapper)
        {
            uow = _uow;
            _mapper = mapper;
        }
        public async Task<List<SchoolDTO>> Handle(GetSchoolQuery request, CancellationToken cancellationToken)
        {
            var allPosts =await uow.School.ListAllAsync() ;
            return _mapper.Map<List<SchoolDTO>>(allPosts);
        }
    }
}
