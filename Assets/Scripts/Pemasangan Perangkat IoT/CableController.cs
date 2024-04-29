using Sandbox;
using Seville;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT
{
    public class CableController : MonoBehaviour
    {
        public List<SocketInteractorTwoAttach> sockets = new List<SocketInteractorTwoAttach>();

        public List<PinType> socketsType;

        // The supposed pin that should be connected to this cable based on cable color
        // Black (GND), RED (VCC), YELLOW & GREEN (DATA)
        public PinType supposedPinConnect; 
    }
}
