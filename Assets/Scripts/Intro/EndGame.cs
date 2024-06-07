using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndGame : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referensi ke VideoPlayer
    public string nextSceneName; // Nama scene yang ingin dipindah

    void Start()
    {
        // Mendaftarkan callback untuk event video selesai diputar
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("VideoPlayer tidak diatur pada skrip.");
        }
    }

    // Callback ketika video selesai diputar
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
