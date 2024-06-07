using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
{
    public GameObject buttonSkip;
    public GameObject buttonScreen;
    public string skipScene; // Nama scene yang ingin dipindah

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

        // Pastikan tombol Skip tidak terlihat saat memulai
        buttonSkip.SetActive(false);
    }

    // Callback ketika video selesai diputar
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Dipanggil saat tombol Screen ditekan
    public void BtnScreen()
    {
        buttonScreen.SetActive(false);
        buttonSkip.SetActive(true);
    }

    // Dipanggil saat tombol Skip ditekan
    public void Skip()
    {
        SceneManager.LoadScene(skipScene);
    }
}
