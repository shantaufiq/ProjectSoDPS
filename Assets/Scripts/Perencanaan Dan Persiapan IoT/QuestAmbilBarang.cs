using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace PerencanaanPersiapanIoT
{

    public class QuestAmbilBarang : MonoBehaviour
    {
        public List<QuestList> questLists;
        public Image questStatusDone;
        
    
    }

    public struct QuestList
    {
        public TextMeshPro questName;
    }


}

