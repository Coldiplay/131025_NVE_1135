using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Array.CommandSummElementsMultiplesOfK
{
    public class CommandSummElementsMultiplesOfK : IRequest<int>
    {
        public int Multiplier { get; set; }
        public int[] Array { get; set; }
        public class SummElementsMultiplesOfKCommandHandler : IRequestHandler<CommandSummElementsMultiplesOfK, int>
        {
            public async Task<int> HandleAsync(CommandSummElementsMultiplesOfK request, CancellationToken ct = default)
            {
                if (request.Multiplier != 0 && request.Array.Length > 0)
                {
                    return request.Array.Where(num => num % request.Multiplier == 0).Sum();
                }
                else
                    throw new Exception();
            }
        }
    }
}
