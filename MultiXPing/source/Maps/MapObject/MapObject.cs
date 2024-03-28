using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MultiXPing
{
    public class MapObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        private Vector2 _pos;           // Object position on the map
        protected PlayerSprite _sprite = new PlayerSprite();

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property

        public Vector2 Position
        {
            get => _pos;
            set => _pos = value;
        }

        public PlayerSprite Sprite
        {
            get => _sprite;
            set => _sprite = value;
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
        public MapObject(int x, int y)
        {
            _pos = new Vector2(x,y);
            
        }
        public void Move(int x, int y)
        {
            _pos.X += x;
            _pos.Y += y;
        }

        #endregion Methods
    }
}
