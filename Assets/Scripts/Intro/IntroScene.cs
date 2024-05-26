using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
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
