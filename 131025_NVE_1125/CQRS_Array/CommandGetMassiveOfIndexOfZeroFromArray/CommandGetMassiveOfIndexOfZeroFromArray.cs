using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Array.CommandGetMassiveOfIndexOfZeroFromArray
{
    public class CommandGetMassiveOfIndexOfZeroFromArray : IRequest<IEnumerable<int>>
    {
        public int[] Array { get; set; }
        public class GetMassiveOfIndexOfZeroFromArrayCommandHandler : IRequestHandler<CommandGetMassiveOfIndexOfZeroFromArray, IEnumerable<int>>
        {
            public async Task<IEnumerable<int>> HandleAsync(CommandGetMassiveOfIndexOfZeroFromArray request, CancellationToken ct = default)
            {
                if (request.Array.Length > 0)
                {
                    int length = 0;
                    for (int i = 0; i < request.Array.Length; i++)
                    {
                        if (request.Array[i] == 0)
                            length++;
                    }

                    int[] result = new int[length];

                    int j = 0;
                    for (int i = 0; i < request.Array.Length; i++)
                    {
                        if (request.Array[i] == 0)
                            result[j++] = i;
                    }

                    return result.AsEnumerable();
                }
                else
                    throw new Exception("Массив пустой");
            }
        }
    }
}
