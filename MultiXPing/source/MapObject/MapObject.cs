﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MultiXPing
{
    internal class MapObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        Vector2         _pos;           // Object position on the map
        int             _x;
        int             _y;
        protected string  _sprite;

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
            private set => _pos = value;
        }
        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public string Sprite
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
        public MapObject() 
        {
        }
        public void Move(Vector2 dir)
        {
            _pos.X += dir.X;
            _pos.Y += dir.Y;
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        #endregion Methods
    }
}
