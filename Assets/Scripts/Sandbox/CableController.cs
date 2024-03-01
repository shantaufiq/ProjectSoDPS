using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sandbox
{
    public enum HardwareName
    {
        ESP32, SENSORDHT11, LCDM, Default
    }

    public enum PortName
    {
        first, second
    }

    public class CableController : MonoBehaviour
    {
        enum CableState
        {
            Connected, Lookfor, Idle
        }
        private CableState _cableState = CableState.Idle;

        // Pin Connected Group
        public PinHandler.PinName pinName1Connected = PinHandler.PinName.Default;
        public PinHandler.PinName pinName2Connected = PinHandler.PinName.Default;

        // Hardware Connected Group
        public HardwareName hardwareName1Connected = HardwareName.Default;
        public HardwareName hardwareName2Connected = HardwareName.Default;

        [Space]
        [Header("Connection On Events")]
        [Space]
        public UnityEvent ESPAndSensorConnected;
        public UnityEvent ESPAndSensorDisconnected;

        [Space]
        [Space]
        public UnityEvent ESPAndLCDConnected;
        public UnityEvent ESPAndLCDDisconnected;

        [Space]
        [Space]
        public UnityEvent InvalidConnection;

        private Action DisconnectEvent;

        private void Start()
        {
            ResetPin();
        }

        private void ResetPin()
        {
            pinName1Connected = PinHandler.PinName.Default;
            pinName2Connected = PinHandler.PinName.Default;
        }

        public void OnPortConnected(PortName port, PinHandler.PinName pinConnected, HardwareName hwConnected)
        {
            if (_cableState == CableState.Idle) _cableState = CableState.Lookfor;
            else if (_cableState == CableState.Lookfor) _cableState = CableState.Connected;

            if (port == PortName.first)
            {
                hardwareName1Connected = hwConnected;
                pinName1Connected = pinConnected;
            }
            else
            {
                hardwareName2Connected = hwConnected;
                pinName2Connected = pinConnected;
            }

            // Debug.Log($"port {port} has connected to {pinDetected.ToString()}");
            CheckHardwareConnection(hardwareName1Connected, hardwareName2Connected);
        }

        public void OnPortDisconnected(PortName port)
        {
            if (_cableState == CableState.Connected) _cableState = CableState.Lookfor;
            else if (_cableState == CableState.Lookfor) _cableState = CableState.Idle;

            if (port == PortName.first)
            {
                hardwareName1Connected = HardwareName.Default;
                pinName1Connected = PinHandler.PinName.Default;
            }
            else
            {
                hardwareName2Connected = HardwareName.Default;
                pinName2Connected = PinHandler.PinName.Default;
            }

            // Debug.Log($"pin {port.ToString()} has disconnected");
            CheckHardwareConnection(hardwareName1Connected, hardwareName2Connected);
        }

        public void CheckHardwareConnection(HardwareName hw1, HardwareName hw2)
        {
            if (_cableState == CableState.Connected)
            {
                if (GeneratePinConnection(pinName1Connected, pinName2Connected))
                {
                    if (hw1 == HardwareName.ESP32 && hw2 == HardwareName.SENSORDHT11 ||
                    hw2 == HardwareName.ESP32 && hw1 == HardwareName.SENSORDHT11)
                    {
                        DisconnectEvent = EPSandSensorDisconn;
                        ESPAndSensorConnected?.Invoke();
                    }
                    else if (hw1 == HardwareName.ESP32 && hw2 == HardwareName.LCDM ||
                    hw2 == HardwareName.ESP32 && hw1 == HardwareName.LCDM)
                    {
                        DisconnectEvent = EPSandLCDDisconn;
                        ESPAndLCDConnected?.Invoke();
                    }
                    else InvalidConnection?.Invoke();
                }
                else InvalidConnection?.Invoke();
            }
            else
            {
                if (IsDisconnected() && DisconnectEvent != null) DisconnectEvent.Invoke();
            }
        }

        private bool IsDisconnected()
        {
            return (pinName1Connected == PinHandler.PinName.Default || pinName2Connected == PinHandler.PinName.Default) ? true : false;
        }

        private void EPSandSensorDisconn() => ESPAndSensorDisconnected.Invoke();
        private void EPSandLCDDisconn() => ESPAndLCDDisconnected.Invoke();

        bool GeneratePinConnection(PinHandler.PinName pin1, PinHandler.PinName pin2)
        {
            bool currentConn = false;

            switch ((pin1, pin2))
            {
                case (PinHandler.PinName.GND, PinHandler.PinName.GND):
                    currentConn = true;
                    break;
                case (PinHandler.PinName.VCC, PinHandler.PinName.VCC):
                    currentConn = true;
                    break;
                case (PinHandler.PinName.D, PinHandler.PinName.D):
                    currentConn = true;
                    break;
                default:
                    currentConn = false;
                    break;
            }

            return currentConn;
        }
    }
}