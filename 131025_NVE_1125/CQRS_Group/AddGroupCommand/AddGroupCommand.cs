using _131025_NVE_1125.DB;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace _131025_NVE_1125.CQRS_Group.AddGroupCommand
{
    public class AddGroupCommand : IRequest<Unit>
    {
        public string? Title { get; set; }
        public int? IdSpecial { get; set; }


        public class AddGroupCommandHandler(Db131025Context db) : IRequestHandler<AddGroupCommand, Unit>
        {
            private readonly Db131025Context db = db;

            public async Task<Unit> HandleAsync(AddGroupCommand request, CancellationToken ct = default)
            {
                db.Groups.Add(new Group {Title = request.Title, IdSpecial = request.IdSpecial });
                await db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
