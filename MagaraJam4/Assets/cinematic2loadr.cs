using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class cinematic2loadr : MonoBehaviour
{
    VideoPlayer VideoPlayer;

    private void Start()
    {
        VideoPlayer = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if (VideoPlayer.time.Equals(18))
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}
