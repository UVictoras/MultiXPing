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
            
        }

        public void InitMap()
        {
            string text = File.ReadAllText(Constants.PROJECTPATH + "MultiXPing\\source\\Maps\\Map1.txt");

            int count = 0;
            Tab.Add(new List<char>());
            foreach (char c in text)
            {
                if (c == '\r')
                {
                    Tab.Add(new List<char>());
                    count ++;
                }
                else if (c == '\n')
                {
                    
                }
                else
                {
                    Tab[count].Add(c);
                }
            }
        }

        public int WidthMap(string text)
        {
            return text.IndexOf("\n");
        }

        public int HeightMap(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if(c == '\n')
                {
                    count++;
                }
            }
            return count;
        }

        #endregion Methods
        
    }

}

