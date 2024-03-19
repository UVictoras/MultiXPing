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

        public void InitMap(int width, int height)
        {
            for(int i = 0; i < height; i++)
            {
                Tab.Add(new List<char>());
                for (int j = 0; j < width; j++)
                {
                    Tab[i].Add('_'); ;
                }
            }
        }

        #endregion Methods
        
    }

}

