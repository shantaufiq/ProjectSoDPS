using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tproject.AudioManager
{
    public class SfxHandler : MonoBehaviour
    {
        private AudioManager audioManager;
        public Sound[] sfxClips;

        // Dictionary untuk menyimpan informasi tentang suara yang telah diputar
        private Dictionary<string, bool> playedSounds = new Dictionary<string, bool>();

        public bool isPlayOnStart;
        public string firstClipName;

        // Start is called before the first frame update
        void Start()
        {
            if (AudioManager.Instance != null) audioManager = AudioManager.Instance;
            else Debug.LogWarning("Please add AudioManager for the audio video output");
            if (isPlayOnStart) PlaySfxClip(firstClipName);
        }

        public void PlaySfxClip(string clipName)
        {
            // Cek apakah suara sudah pernah diputar sebelumnya
            if (playedSounds.ContainsKey(clipName) && playedSounds[clipName])
            {
                Debug.LogWarning("Sound " + clipName + " has already been played.");
                return;
            }

            // Cek apakah suara ada dalam daftar sfxClips
            if (!IsSoundInList(clipName))
            {
                Debug.LogWarning("Sound " + clipName + " is not in the sfxClips list.");
                return;
            }

            Sound sound = audioManager.FindSound(clipName, sfxClips);
            if (sound != null)
            {
                audioManager.PlayMandatorySFX(sound.clip);

                // Tandai suara sebagai sudah diputar
                playedSounds[clipName] = true;
            }
        }

        private bool IsSoundInList(string clipName)
        {
            foreach (Sound sound in sfxClips)
            {
                if (sound.name == clipName)
                {
                    return true;
                }
            }
            return false;
        }

        public void StopSfx()
        {
            audioManager.sfxSource.Stop();
        }
    }
}
