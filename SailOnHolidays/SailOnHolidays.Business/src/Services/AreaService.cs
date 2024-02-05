using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;

namespace SailOnHolidays.Business.src.Services
{
    public class AreaService : BaseService<Area, AreaReadDTO, AreaCreateDTO, AreaUpdateDTO>, IAreaService
    {
        protected readonly IAreaRepo _areaRepo;
        public AreaService(IAreaRepo areaRepo) : base(areaRepo)
        {
            _areaRepo = areaRepo;
        }
    }
}