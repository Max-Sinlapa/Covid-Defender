using UnityEngine;
using UnityEngine.Audio;

namespace kantapon.GameDev3.Chapter11
{
    [CreateAssetMenu(menuName = "GameDev3/Chapter11/SoundSettingsPreset", fileName = "SoundSettingsPreset")]
    public class SoundSettings : ScriptableObject
    {
        public AudioMixer AudioMixer;
        
        [Header("MasterVolume")]
        public string MasterVolumeName = "MasterVolume";
        [Range(-80,20)]
        public float MasterVolume;
    }

}