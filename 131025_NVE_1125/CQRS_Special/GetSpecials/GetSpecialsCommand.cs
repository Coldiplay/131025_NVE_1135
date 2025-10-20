using _131025_NVE_1125.DB;
using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Special.GetSpecials
{
    public class GetSpecialsCommand : IRequest<IEnumerable<SpecialDTO>>
    {
        public class GetSpecialsCommandHandler(Db131025Context db) : IRequestHandler<GetSpecialsCommand, IEnumerable<SpecialDTO>>
        {
            public readonly Db131025Context db = db;
            public async Task<IEnumerable<SpecialDTO>> HandleAsync(GetSpecialsCommand request, CancellationToken ct = default)
            {
                return db.Specials.Select(s => (SpecialDTO)s);
            }
        }
    }
}
