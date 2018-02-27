using System;

namespace BombZ
{
#if WINDOWS || LINUX

    public static class EntryPoint
    {
        [STAThread]
        static void Main()
        {
            using (var game = new BombZ())
                game.Run();
        }
    }
#endif
}
