using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing
{

    public enum Items
    {
        EGG = 0,
        MEAT = 1,
        FEATHER = 2,
        GLASSES = 3,
        HEALING = 4,
        MANA = 5,

    }

    public struct Maps
        {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        private List<List<char>> _tab = new List<List<char>>();

        string _text = String.Empty;

        private int _width = 0;
        private int _height = 0;

        private List<Sign> _tabSign = new();

        string _id = String.Empty;

        


        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public List<List<char>> Tab
        {
            get => _tab; 
            set => _tab = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }
        public int Height
        {
            get => _height;
            set => _height = value;
        }
        public List<Sign> TabSign { get => _tabSign; set => _tabSign = value; }
        public string Id { get => _id; set => _id = value; }

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


        public Maps(string map){
            Id = map;
            InitMap(map);
        }

        public void InitMap(string map)
        {
            _text = File.ReadAllText(Constants.PROJECTPATH + "MultiXPing\\source\\Maps\\MapDesign\\"+ map +".txt");
            _width = WidthMap();
            _height = HeightMap();

            int count = 0;
            Tab.Add(new List<char>());
            foreach (char c in Text)
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

        public int WidthMap()
        {
            return (Text.IndexOf("\n"))-1;
        }

        public int HeightMap()
        {
            int count = 0;
            foreach (char c in Text)
            {
                if(c == '\n')
                {
                    count++;
                }
            }
            return count+1;
        }

        public void InitInteractive(List<Interactive> list, Player player, Window window)
        {
            for(int i = 0; i < Tab.Count; i++) 
            {
                for(int j = 0; j < Tab[i].Count; j++)
                {
                    if (Tab[i][j] == 'C')
                    {
                        //x = 53
                        //y = 15

                        Chest chest = new Chest(j, i);

                        Items itemrand = (Items)Rand.GetInstance().Randint(5);

                        switch (itemrand)
                        {
                            case Items.EGG:
                                chest.AddItem(new Egg());
                                break;
                            case Items.MEAT:
                                chest.AddItem(new Meat());
                                break;
                            case Items.GLASSES:
                                chest.AddItem(new Glasses());
                                break;
                            case Items.MANA:
                                chest.AddItem(new ManaPotion());
                                break;
                            case Items.FEATHER:
                                chest.AddItem(new Feather());
                                break;
                            case Items.HEALING:
                                chest.AddItem(new HealingPotion());
                                break;

                        }

                        player.onUse += chest.Interact;
                        chest.PrintText += window.DrawWindowInteractive;
                        list.Add(chest);

                    }
                    else if(Tab[i][j] == 'M')
                    {
                        Sign sign  = new Sign(j, i);
                        player.onUse += sign.Interact;
                        sign.PrintText += window.DrawWindowInteractive;
                        list.Add(sign);
                        TabSign.Add(sign);
                    }
                }
            }

            InitSigns();

        }

        public void InitSigns()
        {
            //Non générique, il faut set tous les paneaux ici 
            

        }

        #endregion Methods
        
    }

}

