﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MultiXPing
{
    abstract public class GameItem : NodeObject
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         | 
        \* ----------------------------------------------------- */
        #region Field
        int _id;
        string _description;
        int _numberUse;

        #endregion Field

        /* ----------------------------------------------------- *\
        |                                                         |
        |                        Property                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Property
        public int Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public int NumberUse { get => _numberUse; set => _numberUse = value; }
        #endregion Property

        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods
        new public bool Use(Character target)
        {
            return true;
        }
        #endregion Methods
    }
}
