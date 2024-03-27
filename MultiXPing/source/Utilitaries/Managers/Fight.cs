using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Utilitaries.Managers
{
    class Fight: Window
    {
        /* ----------------------------------------------------- *\
       |                                                         |
       |                          Field                          |
       |                                                         |
       \* ----------------------------------------------------- */
        #region Field
        int _turn;
        List<Character> _actionOrder;
        Character _characterTurn;
        Player _mainPlayer;
        Team _characterTeam = new Team();
        Attack _selectedAttack;
        List<Enemy>_enemies = new List<Enemy>();
        Tree _fightingCharacter;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public int Turn { get => _turn; set => _turn = value; }
        public List<Character> ActionOrder { get => _actionOrder; set => _actionOrder = value; }
        public Character CharacterTurn { get => _characterTurn; set => _characterTurn = value; }
        public Player MainPlayer
        {
            get => _mainPlayer;
            set => _mainPlayer = value;
        }
        public Tree FightingCharacter { get => _fightingCharacter; set => _fightingCharacter = value; }
        internal Team CharacterTeam { get => _characterTeam; set => _characterTeam = value; }
        public Attack SelectedAttack { get => _selectedAttack; set => _selectedAttack = value; }
        public List<Enemy> Enemies { get => _enemies; set => _enemies = value; }

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
        public Fight()
        {
        }

        public void DetermineOrder()
        {
            ActionOrder = CharacterTeam.ListTeam.OrderByDescending(x => x.Speed).ToList();
        }
        public void GenerateEnemies(EnemyList enemyList) 
        {
            Random randomEnemy = new Random();
            int rand = 0;
            int spawnGobriel = enemyList.GetEnemyByName("gobriel").SpawnProba;
            int spawnDanycayou = enemyList.GetEnemyByName("danycayou").SpawnProba;
            int spawnFlashmcqueen = enemyList.GetEnemyByName("flashmcqueen").SpawnProba;
            int spawnNayar = enemyList.GetEnemyByName("nayar").SpawnProba;

            for (int i = 0; i < 4; i++) 
            {
                rand = randomEnemy.Next(1,100);
                if (rand <= spawnGobriel)
                {
                    Enemies.Add(enemyList.GetEnemyByName("gobriel"));
                }
                else if (rand > spawnGobriel && rand <= spawnGobriel + spawnDanycayou)
                {
                    Enemies.Add(enemyList.GetEnemyByName("danycayou"));
                }
                else if (rand > spawnGobriel + spawnDanycayou && rand <= spawnGobriel + spawnDanycayou + spawnFlashmcqueen)
                {
                    Enemies.Add(enemyList.GetEnemyByName("flashmcqueen"));
                }
                else if (rand > spawnGobriel + spawnDanycayou + spawnFlashmcqueen)
                {
                    Enemies.Add(enemyList.GetEnemyByName("nayar"));
                }

            }
        }

        #endregion Methods
    }
}
