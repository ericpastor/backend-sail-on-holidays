using AutoMapper;
using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;

namespace SailOnHolidays.Business.src.Services
{
    public class YachtService : BaseService<Yacht, YachtReadDTO, YachtCreateDTO, YachtUpdateDTO>, IYachtService
    {
        protected readonly IYachtRepo _yachtRepo;

        public YachtService(IYachtRepo yachtRepo, IMapper mapper) : base(yachtRepo, mapper)
        {
            _yachtRepo = yachtRepo;
        }
    }
}