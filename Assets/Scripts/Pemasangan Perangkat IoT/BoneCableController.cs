using InstalasiIoT;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace InstalasiIoT
{
    public class BoneCableController : MonoBehaviour
    {
        [SerializeField] private CableController cableController;
        public CableController CableController { get => cableController; set => cableController = value; }
    }
}
