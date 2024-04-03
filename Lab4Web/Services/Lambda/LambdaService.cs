namespace Lab4Web.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public Tuple<int, int,int> Test1(int value)
        {
            var lambdaExp = (int num) => new Tuple<int, int, int>(num % 10, (num /= 10) % 10, (num /= 10) % 10);
            return lambdaExp(value);
        }

        public bool Test2(string value)
        {
            return int.TryParse(value, out _);
        }

        public async Task<string> Test3Async(string value)
        {
            var lambaExp = async (string v) =>
            {
                await Delay();
                return value.ToLower();
            };

            return await lambaExp(value);
        }


        public Task Delay()
        {
            return Task.Delay(10000);
        }
    }
}
