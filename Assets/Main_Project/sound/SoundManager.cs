using UnityEngine;
using UnityEngine.UI;

namespace kantapon.GameDev3.Chapter11
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] protected SoundSettings m_SoundSettings;
        
        public Slider m_SliderMasterVolume;
        public Slider m_SliderMusicVolume;
        public Slider m_SliderMasterSFXVolume;
        public Slider m_SliderSFXVolume;
        public Slider m_SliderUIVolume;

        void Start()
        {
            InitialiseVolumes();
        }

        private void InitialiseVolumes()
        {
            SetMasterVolume(m_SoundSettings.MasterVolume);
            SetMusicVolume(m_SoundSettings.MusicVolume);
            SetMasterSFXVolume(m_SoundSettings.MasterSFXVolume);
            SetSFXVolume(m_SoundSettings.SFXVolume);
            SetUIVolume(m_SoundSettings.UIVolume);
        }

        public void SetMasterVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.MasterVolumeName ,vol);

            m_SoundSettings.MasterVolume = vol;

            m_SliderMasterVolume.value = m_SoundSettings.MasterVolume;
        }

        public void SetMusicVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.MusicVolumeName ,vol);
            m_SoundSettings.MusicVolume = vol;
            m_SliderMusicVolume.value = m_SoundSettings.MusicVolume;
        }

        public void SetMasterSFXVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.MasterSFXVolumeName ,vol);

            m_SoundSettings.MasterSFXVolume = vol;
            
            m_SliderMasterSFXVolume.value = m_SoundSettings.MasterSFXVolume;
        }

        public void SetSFXVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.SFXVolumeName ,vol);

            m_SoundSettings.SFXVolume = vol;
            
            m_SliderSFXVolume.value = m_SoundSettings.SFXVolume;
        }

        public void SetUIVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.UIVolumeName ,vol);

            m_SoundSettings.UIVolume = vol;

            m_SliderUIVolume.value = m_SoundSettings.UIVolume;
        }
    }
}