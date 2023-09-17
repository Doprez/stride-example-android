using Stride.Engine;

namespace AndroidTest
{
    class AndroidTestApp
    {
        static void Main(string[] args)
        {
            using (var game = new CustomGameWindows())
            {
                game.Run();
            }
        }
    }
}
