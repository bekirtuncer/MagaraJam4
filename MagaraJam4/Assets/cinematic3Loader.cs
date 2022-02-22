using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class cinematic3Loader : MonoBehaviour
{
    VideoPlayer _videoPlaye;

    private void Start()
    {
        _videoPlaye = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if (_videoPlaye.time.Equals(19))
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}
