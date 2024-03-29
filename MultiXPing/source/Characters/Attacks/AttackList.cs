using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiXPing.source.Characters.Attacks
{
    public struct AttackList
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        private static List<Attack> _listAttack = new List<Attack>();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public List<Attack> ListAttack { get => _listAttack; set => _listAttack = value; }

        public Attack this[int key]
        {
            get => _listAttack[key];
            set => _listAttack[key] = value;
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

        public AttackList()
        {

        }

        public void InitAttacks()
        {
            List<List<string>> list = Parser.CSVParserString(Constants.PROJECTPATH + "MultiXPing\\source\\Data\\Attaques.csv");
            for (int i = 1; i < list.Count; i++)
            {
                ListAttack.Add(
                    new Attack
                    {
                        Name = list[i][0],
                        Element = list[i][1],
                        Damage = int.Parse(list[i][2]),
                        Accuracy = int.Parse(list[i][3]),
                        MagicCost = int.Parse(list[i][4]),
                        Function = null,
                        Descriptor = list[i][6],
                        Class = list[i][7],
                    });
            }
        }

        public Attack GetAttackByName(string name)
        {
            foreach (Attack attack in _listAttack)
            {
                if (attack.Name == name)
                {
                    return attack;
                }
            }

            throw new NullReferenceException("N'est pas cencé ne pas trouver l'attaque");

        }

        public void InitAttack()
        {
            GetAttackByName("Paume Currative").BindFunction();
            GetAttackByName("Soins").BindFunction();
        }

        

        #endregion Methods
    }
}
