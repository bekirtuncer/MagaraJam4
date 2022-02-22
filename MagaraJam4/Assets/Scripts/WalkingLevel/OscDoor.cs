using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscDoor : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 moveVector;
    [SerializeField] [Range(0, 1)] float moveFactor;
    [SerializeField] float perio = 2f;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float cycles = Time.time / perio;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        moveFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = moveVector * moveFactor;
        transform.position = startPosition + offset;
    }
}
