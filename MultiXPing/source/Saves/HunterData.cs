using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class HunterData
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        [JsonInclude] public int _maximumHealth;
        [JsonInclude] public int _health;
        [JsonInclude] public int _maximumMana;
        [JsonInclude] public int _mana;
        [JsonInclude] public int _level;
        [JsonInclude] public int _experience;
        [JsonInclude] public int _experienceRequired;

        [JsonInclude] public float _physicalDamage;
        [JsonInclude] public float _magicalDamage;
        [JsonInclude] public float _physicalDefense;
        [JsonInclude] public float _magicalDefense;
        [JsonInclude] public float _speed;
        [JsonInclude] public float _accuracy;

        [JsonInclude] public bool _isAlive;

        [JsonInclude] public string _name = String.Empty;
        [JsonInclude] public string _sprite = String.Empty;

        [JsonInclude] public Dictionary<int, AttackData> _possibleAttacks = new Dictionary<int, AttackData>();
        [JsonInclude] public List<AttackData> _attacks = new List<AttackData>();

        [JsonInclude] public Node _nodeRef = default;

        #endregion Field
    }
}
