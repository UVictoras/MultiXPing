
namespace MultiXPing
{
    public struct CharacterStats
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         | 
        \* ----------------------------------------------------- */
        #region Field
        List<float> _tank;
        List<float> _tankMultiplicator;
        List<float> _magician;
        List<float> _magicianMultiplicator;
        List<float> _swordsman;
        List<float> _swordsmanMultiplicator;
        List<float> _support;
        List<float> _supportMultiplicator;

        Dictionary<string, List<float>> _dicStats;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public List<float> Tank { get => _tank; private set => _tank = value; }
        public List<float> Magician { get => _magician; private set => _magician = value; }
        public List<float> Swordsman { get => _swordsman; private set => _swordsman = value; }
        public List<float> Support { get => _support; private set => _support = value; }
        public List<float> MagicianMultiplicator { get => _magicianMultiplicator; set => _magicianMultiplicator = value; }
        public List<float> TankMultiplicator { get => _tankMultiplicator; set => _tankMultiplicator = value; }
        public List<float> SwordsmanMultiplicator { get => _swordsmanMultiplicator; set => _swordsmanMultiplicator = value; }
        public List<float> SupportMultiplicator { get => _supportMultiplicator; set => _supportMultiplicator = value; }
        public Dictionary<string, List<float>> DicStats { get => _dicStats; set => _dicStats = value; }
        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Event                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Event

        #endregion Event

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods

        public CharacterStats()
        {
            _tank = new List<float>();
            _magician = new List<float>();
            _support = new List<float>();
            _swordsman= new List<float>();
            _tankMultiplicator = new List<float>();
            _magicianMultiplicator= new List<float>();
            _swordsmanMultiplicator= new List<float>();
            _supportMultiplicator= new List<float>();
            _dicStats = new Dictionary<string, List<float>>();
        }
        public void InitializeCSVStats(string filepathStats, string filepathMultiplicator )
        {
            List<List<float>> CSVStat = Parser.CSVParser(filepathStats);
            List<List<float>> CSVMultiplicator = Parser.CSVParser(filepathMultiplicator);
            // Verification size of CSVlist
            if (CSVStat.Count != 4 || CSVMultiplicator.Count != 4) { return; }
            for (int i = 0; i < CSVStat.Count; i++)
            {
                if (CSVStat[i].Count() != 7 || CSVMultiplicator[i].Count() != 7) { return; }
            }

            // Fill the list with the stats

            for (int i = 0;i < 7; i++)
            {
                Tank.Add(CSVStat[0][i]);
                TankMultiplicator.Add(CSVMultiplicator[0][i]);

            }
            for (int i = 0; i < 7; i++)
            {
                Magician.Add(CSVStat[1][i]);
                MagicianMultiplicator.Add(CSVMultiplicator[1][i]);
            }
            for (int i = 0; i < 7; i++)
            {
                Swordsman.Add(CSVStat[2][i]);
                SwordsmanMultiplicator.Add(CSVMultiplicator[2][i]);
            }
            for (int i = 0; i < 7; i++)
            {
                Support.Add(CSVStat[3][i]);
                SupportMultiplicator.Add(CSVMultiplicator[3][i]);
            }

            InitDico();

        }

        public void InitDico()
        {
            DicStats.Add("tank",Tank);
            DicStats.Add("magician", Magician);
            DicStats.Add("swordman", Swordsman);
            DicStats.Add("support", Support);
            
            DicStats.Add("tankmultiplicator", TankMultiplicator);
            DicStats.Add("magicianmultiplicator", MagicianMultiplicator);
            DicStats.Add("swordmanmultiplicator", SwordsmanMultiplicator);
            DicStats.Add("supportmultiplicator", SupportMultiplicator);
        }
        #endregion Methods
    }
}