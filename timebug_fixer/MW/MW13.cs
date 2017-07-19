namespace timebug_fixer.MW
{
    class MW13 : Game
    {
        public MW13(GameProcess proc) : base(proc)
        {
            globalIgtAddress = 0x009885D8;
            raceIgtAddress = 0x009142DC;
        }
    }
}
