using System.Net.Http.Json;
using System.Threading.Tasks;

namespace For131025
{
    internal class Program
    {
        static HttpClient client = new(){ BaseAddress = new("https://localhost:7031/api/") };
        static async Task Main(string[] args)
        {
            //await Task1();


            Console.ReadLine();
            Console.ReadLine();
        }


        public static async Task Task1()
        {
            int[] array = GetRandomMassiveInt(0, 1001);
            Console.WriteLine("Введите кратное число");
            int k = GetIntFromUser();

            var result = await client.PostAsJsonAsync($"Arrays/ArrayGetSummOfElementsMultiplesOfK?k={k}", array);
            Console.WriteLine(await result.Content.ReadFromJsonAsync<int>());
        }
        public static async Task Task2()
        {
            int[] array = GetRandomMassiveInt(0, 2);
            var result = await client.PostAsJsonAsync($"Arrays/MassiveOfIndexOfZeroFromArray", array);
            Console.WriteLine(await result.Content.ReadAsStringAsync());
        }
        public static async Task Task3()
        {
            
        }





        public static int GetIntFromUser()
        {
            int num;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out num))
            {
                Console.WriteLine("Неверный ввод числа");
                input = Console.ReadLine();
            }
            return num;
        }
        public static double GetDoubleFromUser()
        {
            double num;
            string input = Console.ReadLine();
            while (!double.TryParse(input, out num))
            {
                Console.WriteLine("Неверный ввод числа");
                input = Console.ReadLine();
            }
            return num;
        }
        public static int[] GetRandomMassiveInt(int min, int max)
        {
            Console.WriteLine("Введите продолжительность массива");
            Random random = new Random();
            int[] res = new int[GetIntFromUser()];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = random.Next(min, max) ;
            }
            return res;
        }
        public static double[] GetRandomMassiveDouble()
        {
            Console.WriteLine("Введите продолжительность массива");
            Random random = new Random();
            double[] res = new double[GetIntFromUser()];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = random.NextDouble();
            }
            return res;
        }
    }
}
