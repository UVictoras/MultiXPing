using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class PlayerData
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                          Field                          |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Field

        [JsonInclude] public List<ItemData> _inventoryData = new List<ItemData>();
        [JsonInclude] public List<HunterData> _huntersData = new List<HunterData>();

        #endregion Field
    }
}
