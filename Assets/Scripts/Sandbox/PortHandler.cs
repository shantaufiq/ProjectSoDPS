
using UnityEngine;

namespace Sandbox
{
    public class PortHandler : MonoBehaviour
    {
        public CableController cableHandler;

        public PortIdentity portSection;

        private void OnTriggerEnter(Collider other)
        {
            PinHandler pinDetected = other.GetComponent<PinHandler>();

            if (portSection == PortIdentity.first) cableHandler.OnPortConnected(portSection, pinDetected.pinName, pinDetected.hardwareName);
            else cableHandler.OnPortConnected(portSection, pinDetected.pinName, pinDetected.hardwareName);
        }

        private void OnTriggerExit(Collider other)
        {
            if (portSection == PortIdentity.first) cableHandler.OnPortDisconnected(portSection);
            else cableHandler.OnPortDisconnected(portSection);
        }
    }
}