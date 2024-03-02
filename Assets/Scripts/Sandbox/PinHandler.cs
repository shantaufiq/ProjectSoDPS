
using UnityEngine;

namespace Sandbox
{
    public class PinHandler : MonoBehaviour
    {
        public HardwareName hardwareName;

        public enum PinName
        {
            GND, VCC, D, Default
        }

        public PinName pinName;
    }
}