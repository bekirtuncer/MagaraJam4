using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossBar : MonoBehaviour
{

    public Slider bossBar;
    private float maxStamina = 100f;
    private float bossStamina = 100f;

    public static BossBar instance;


    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bossBar.maxValue = maxStamina;
        bossBar.value = bossStamina;
    }

    private void Update()
    {
        if (bossBar.value == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PickBossPower(int amount)
    {
        if (bossStamina - amount >= 0)
        {
            bossBar.value -= amount;
        }

       
    }

   

 
}
