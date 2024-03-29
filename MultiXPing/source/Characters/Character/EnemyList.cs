using MultiXPing.source.Characters.Attacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiXPing
{
    public struct EnemyList
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        private static List<Enemy> _listEnemy = new List<Enemy>();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public List<Enemy> ListEnemy { get => _listEnemy; set => _listEnemy = value; }

        public Enemy this[int key]
        {
            get => _listEnemy[key];
            set => _listEnemy[key] = value;
        }

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

        public EnemyList()
        {

        }

        public void InitEnemy(AttackList listAtt)
        {
            List<List<string>> list = Parser.CSVParserString(Constants.PROJECTPATH + "MultiXPing\\source\\Data\\EnemyStat.csv");
            for (int i = 1; i < list.Count; i++)
            {
                ListEnemy.Add(
                    new Enemy
                    {
                        Name = list[i][0],
                        MaximumHealth = int.Parse(list[i][1]),
                        Health = int.Parse(list[i][1]),
                        MaximumMana = int.Parse(list[i][2]),
                        Mana = int.Parse(list[i][2]),
                        PhysicalDamage = int.Parse(list[i][3]),
                        PhysicalDefense = int.Parse(list[i][4]),
                        MagicalDamage = int.Parse(list[i][5]),
                        MagicalDefense = int.Parse(list[i][6]),
                        Speed = int.Parse(list[i][7]),
                        Element = list[i][8],
                        SpawnProba = int.Parse(list[i][9]),
                        CharacterSprite = list[i][10],
                        DroppedExperience = int.Parse(list[i][11]),
                    }) ;

            }

            for(int i = 0; i < ListEnemy.Count; i++)
            {
                ListEnemy[i].Initialize(ListEnemy[i].Name, listAtt);
            }

        }

        public Enemy GetEnemyByName(string name)
        {
            foreach (Enemy enemy in _listEnemy)
            {
                if (enemy.Name == name)
                {
                    return enemy;
                }
            }

            throw new NullReferenceException("N'est pas cencé ne pas trouver l'ennemie");

        }

        #endregion Methods
    }
}
