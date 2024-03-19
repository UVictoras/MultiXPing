using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{
    struct Map
        {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        private List<List<char>> _tab = new List<List<char>>();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public dynamic Tab
        {
            get => _tab; 
            set => _tab = value;
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

         
        public Map() {
            InitMap();
        }

        public void InitMap()
        {
            int count = 0;
            string text = File.ReadAllText(Constants.PROJECTPATH + "MultiXPing\\source\\Maps\\Map1.txt");
            int countMax = text.Length;
            for (int i = 0; i < Constants.HEIGHT; i++)
            {
                Tab.Add(new List<char>());
                for (int j = 0; j < Constants.WIDTH; j++)
                {
                    if (count > countMax)
                    {
                        return;
                    }
                    if (text[count] == '\n')
                    {
                        count++;
                        break;
                    }
                        

                    Tab[i].Add(text[count]);
                    count++;

                }
            }
            
        }

        #endregion Methods
        
    }

}

