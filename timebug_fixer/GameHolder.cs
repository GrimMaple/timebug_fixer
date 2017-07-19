using System;

namespace timebug_fixer
{
    public class GameHolder
    {
        Game game;
        GameProcess process;

        bool isUnknown = false;

        enum ProcessSizes
        {
            MW13 = 0x00678e4e
        }

        public void Refresh()
        {
            if(!process.IsOpen)
            {
                // In cases when the process is not open, but the game exists
                // The process had either crashed, either was exited on purpose
                if(game != null)
                    Console.WriteLine("Process lost (quit?)");
                game = null;
                return;
            }
            if(isUnknown) // If we couldn't determine game version, do nothing
            {
                return;
            }
            // If process is opened, but the game doesn't exist, we need to create it
            if(process.IsOpen && game == null)
            {
                Console.WriteLine("Opened process, size = 0x{0:X}", process.ImageSize);
                switch((ProcessSizes)process.ImageSize)              // Guessing version
                {
                    case ProcessSizes.MW13:
                        game = new MW.MW13(process);
                        break;
                    default:
                        Console.WriteLine("Unknown game type");
                        isUnknown = false;
                        break;
                }
            }
            // At last, update game
            game.Update();
        }

        public GameHolder(string proc)
        {
            process = GameProcess.OpenGameProcess(proc);
        }
    }
}
