using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
   [SerializeField] private AudioMixer myMixer;
   [SerializeField] private Slider musicSlider;

   public void SetMusicVolume() {
    float volume = musicSlider.value;
    myMixer.SetFloat("music", math.log10(volume) * 20);
   }
}
