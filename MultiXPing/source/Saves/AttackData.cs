using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class AttackData
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        [JsonInclude] public int _damage;
        [JsonInclude] public int _magicCost;
        [JsonInclude] public float _accuracy;
        [JsonInclude] public string _name = String.Empty;
        [JsonInclude] public string _element = String.Empty;
        [JsonInclude] public string _description = String.Empty;
        [JsonInclude] public string _class = String.Empty;
        [JsonInclude] public bool _targetAllies;
        [JsonInclude] public object _function = null;
        [JsonInclude] public Node _nodeRef = default;

        #endregion Field
    }
}
