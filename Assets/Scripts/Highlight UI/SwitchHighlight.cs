using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerencanaanPersiapanIoT
{
    public class SwitchHighlight : MonoBehaviour
    {
        public List<data> imageData;
        public Sprite highlight;
    }
    [System.Serializable]
    public struct data
    {
        public Sprite imageWindow;
        public Vector3 vector;
        public int width;
        public int heigt;

    }

}


