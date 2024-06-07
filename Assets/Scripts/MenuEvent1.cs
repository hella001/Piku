using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvent1 : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
       mixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
