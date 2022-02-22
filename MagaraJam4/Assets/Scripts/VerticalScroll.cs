using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float scrollRate = 0.3f;

    private void Update()
    {
        float xMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector3(xMove, 0));
    }

    
}
