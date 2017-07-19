using System;

namespace timebug_fixer
{
    public abstract class Game
    {
        private float lastTime;
        private GameProcess game;

        /// <summary>
        /// Synch-timer's address
        /// </summary>
        protected int raceIgtAddress;               
        
        /// <summary>
        /// Timer-to-sync address
        /// </summary>
        protected int globalIgtAddress;

        private void ResetTime()
        {
            byte[] data = { 0, 0, 0, 0 };
            game.WriteMemory(globalIgtAddress, data);
        }

        public void Update()
        {
            float tmp = game.ReadFloat(raceIgtAddress);
            if (tmp < lastTime)
            {
                ResetTime();
                Console.WriteLine("Timer reset");
            }
            lastTime = tmp;
        }

        public Game(GameProcess proc)
        {
            game = proc;
            lastTime = -2; // Why not anyway
        }
    }
}
