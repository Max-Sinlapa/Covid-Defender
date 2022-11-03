using UnityEngine;
using UnityEngine.UI;

namespace kantapon.GameDev3.Chapter11
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] protected SoundSettings m_SoundSettings;
        
        public Slider m_SliderMasterVolume;
        

        void Start()
        {
            InitialiseVolumes();
        }

        private void InitialiseVolumes()
        {
            SetMasterVolume(m_SoundSettings.MasterVolume);
            
        }

        public void SetMasterVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.MasterVolumeName ,vol);

            m_SoundSettings.MasterVolume = vol;

            m_SliderMasterVolume.value = m_SoundSettings.MasterVolume;
        }

        
        
    }
}