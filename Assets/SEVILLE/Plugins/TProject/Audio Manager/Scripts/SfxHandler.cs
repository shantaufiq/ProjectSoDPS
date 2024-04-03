using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tproject.AudioManager
{
    public class SfxHandler : MonoBehaviour
    {
        [SerializeField] private AudioManager audioManager;
        public AudioClip sfxClip;

        // Start is called before the first frame update
        void Start()
        {
            if (AudioManager.Instance != null) audioManager = AudioManager.Instance;
            else Debug.LogWarning("please add Audio Manager for the audio video output");
        }

        public void PlaySfxClip()
        {
            audioManager.PlayMandatorySFX(sfxClip);
        }

        public void StopSfx()
        {
            audioManager.sfxSource.Stop();
        }
    }
}