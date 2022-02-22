using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootSteps : MonoBehaviour
{
    CharacterController characterController;
    PlayerMovement playerMovement;
    AudioSource audioSource;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            audioSource.Play();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            audioSource.Play();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            audioSource.Play();
        }
    }
}
