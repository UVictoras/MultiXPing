using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class ItemData
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        [JsonInclude] public int _id;
        [JsonInclude] public int _numberUse;

        [JsonInclude] public float _boost;

        [JsonInclude] public string _name = String.Empty;
        [JsonInclude] public string _description = String.Empty;

        [JsonInclude] public Node _nodeRef = default;

        #endregion Field
    }
}
