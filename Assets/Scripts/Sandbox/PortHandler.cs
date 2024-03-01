using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{
    public class PortHandler : MonoBehaviour
    {
        public CableController cableHandler;

        public PortName portSection;

        private void OnTriggerEnter(Collider other)
        {
            string incomingName = other.gameObject.name;
            // Debug.Log($"Telah masuk ke pin yang sesuai: {incomingName}");

            PinHandler pinDetected = other.GetComponent<PinHandler>();

            if (portSection == PortName.first) cableHandler.OnPortConnected(portSection, pinDetected.pinName, pinDetected.hardwareName);
            else cableHandler.OnPortConnected(portSection, pinDetected.pinName, pinDetected.hardwareName);
        }

        private void OnTriggerExit(Collider other)
        {
            string incomingName = other.gameObject.name;
            // Debug.Log($"Telah keluar dari pin yang sesuai: {incomingName}");

            if (portSection == PortName.first) cableHandler.OnPortDisconnected(portSection);
            else cableHandler.OnPortDisconnected(portSection);
        }
    }
}