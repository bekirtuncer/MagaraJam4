using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class BossLevelLoader : MonoBehaviour
{
    VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if(videoPlayer.time.Equals(46))
        {
            SceneManager.LoadScene("BossLevel");
        }
    }
}
