using UnityEngine;
using UnityEngine.UI;
public class SFXVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 0.3f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("sfxVolume", musicSlider.value);
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }
}
