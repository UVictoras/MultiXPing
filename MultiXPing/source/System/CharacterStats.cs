
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
        List<string> _tank;
        List<float> _tankMultiplicator;
        List<string> _magician;
        List<float> _magicianMultiplicator;
        List<string> _swordsman;
        List<float> _swordsmanMultiplicator;
        List<string> _support;
        List<float> _supportMultiplicator;

        Dictionary<string, List<string>> _dicStats;
        Dictionary<string, List<float>> _dicMultiplicator;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public List<string> Tank { get => _tank; private set => _tank = value; }
        public List<string> Magician { get => _magician; private set => _magician = value; }
        public List<string> Swordsman { get => _swordsman; private set => _swordsman = value; }
        public List<string> Support { get => _support; private set => _support = value; }
        public List<float> MagicianMultiplicator { get => _magicianMultiplicator; set => _magicianMultiplicator = value; }
        public List<float> TankMultiplicator { get => _tankMultiplicator; set => _tankMultiplicator = value; }
        public List<float> SwordsmanMultiplicator { get => _swordsmanMultiplicator; set => _swordsmanMultiplicator = value; }
        public List<float> SupportMultiplicator { get => _supportMultiplicator; set => _supportMultiplicator = value; }
        public Dictionary<string, List<string>> DicStats { get => _dicStats; set => _dicStats = value; }
        public Dictionary<string, List<float>> DicMultiplicator { get => _dicMultiplicator; set => _dicMultiplicator = value; }
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
            _tank = new List<string>();
            _magician = new List<string>();
            _support = new List<string>();
            _swordsman= new List<string>();
            _tankMultiplicator = new List<float>();
            _magicianMultiplicator= new List<float>();
            _swordsmanMultiplicator= new List<float>();
            _supportMultiplicator= new List<float>();
            _dicStats = new Dictionary<string, List<string>>();
            _dicMultiplicator= new Dictionary<string, List<float>>();
        }
        public void InitializeCSVStats(string filepathStats, string filepathMultiplicator )
        {
            List<List<string>> CSVStat = Parser.CSVParserString(filepathStats);
            List<List<float>> CSVMultiplicator = Parser.CSVParser(filepathMultiplicator);
            // Verification size of CSVlist
            if (CSVStat.Count != 4 || CSVMultiplicator.Count != 4) { return; }
            for (int i = 0; i < CSVStat.Count; i++)
            {
                if (CSVStat[i].Count() != 9 || CSVMultiplicator[i].Count() != 7) { return; }
            }

            // Fill the list with the stats

            for (int i = 0;i < CSVStat[0].Count; i++)
            {
                Tank.Add(CSVStat[0][i]);
            }
            for (int i = 0; i < CSVMultiplicator[0].Count; i++)
            {
                TankMultiplicator.Add(CSVMultiplicator[0][i]);
            }
            for (int i = 0; i < CSVStat[1].Count; i++)
            {
                Magician.Add(CSVStat[1][i]);
            }
            for (int i = 0; i < CSVMultiplicator[1].Count; i++)
            {
                MagicianMultiplicator.Add(CSVMultiplicator[1][i]);
            }
            for (int i = 0; i < CSVStat[2].Count; i++)
            {
                Swordsman.Add(CSVStat[2][i]);
            }
            for (int i = 0; i < CSVMultiplicator[2].Count; i++)
            {
                SwordsmanMultiplicator.Add(CSVMultiplicator[2][i]);
            }
            for (int i = 0; i < CSVStat[3].Count; i++)
            {
                Support.Add(CSVStat[3][i]);
            }
            for (int i = 0; i < CSVMultiplicator[3].Count; i++)
            {
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
            
            DicMultiplicator.Add("tankmultiplicator", TankMultiplicator);
            DicMultiplicator.Add("magicianmultiplicator", MagicianMultiplicator);
            DicMultiplicator.Add("swordmanmultiplicator", SwordsmanMultiplicator);
            DicMultiplicator.Add("supportmultiplicator", SupportMultiplicator);
        }
        #endregion Methods
    }
}