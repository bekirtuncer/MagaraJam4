using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class roomLevelLoad : MonoBehaviour
{
    VideoPlayer _videoPlayer;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if (_videoPlayer.time.Equals(43))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
