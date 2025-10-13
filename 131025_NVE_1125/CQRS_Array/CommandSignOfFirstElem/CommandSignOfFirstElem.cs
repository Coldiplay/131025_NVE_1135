using MyMediator.Interfaces;

namespace _131025_NVE_1125.CQRS_Array.CommandSignOfFirstElem
{
    public class CommandSignOfFirstElem : IRequest<string>
    {
        public int[] Array { get; set; }
        public class SignOfFirstElemCommandHandler : IRequestHandler<CommandSignOfFirstElem, string>
        {
            public async Task<string> HandleAsync(CommandSignOfFirstElem request, CancellationToken ct = default)
            {
                if (request.Array.Length > 0)
                {
                    return request.Array.First() > 0 ? "Первый элемент положительный" : "Первый элемент отрицательный";
                }
                else
                    throw new Exception("Массив пуст");
            }
        }
    }
}
