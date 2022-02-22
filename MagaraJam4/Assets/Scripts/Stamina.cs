using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;
    private float maxStamina = 100f;
    private float currentStamina = 100f;

    public static Stamina instance;

    PlayerMovement playerMovement;

    private bool isWalking;
    private float staminaDrain = 0.5f;

    public float lValue = 0.5f;
    public float jValue = 5f;

    Animator animator;



    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            DecreaseEnergy();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            DecreaseEnergy();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            JumpCost();
        }

        Die();
        
    }

    public void PickPowerUps(int amount)
    {
        if (currentStamina + amount <= 200)
        {
            staminaBar.value += amount;
        }

        else
        {
            Debug.Log("Artacak yer Kalmadý");
        }
    }

    public void PickEvilPowerUps(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            staminaBar.value -= amount;
        }

        else
        {
            Debug.Log("Game Over");
        }
    }

    public void DPRHÝT(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            staminaBar.value -= amount;
        }
    }


    public void LevelOneHit(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            staminaBar.value -= amount;
        }
    }

    public void DecreaseEnergy()
    {
        if (currentStamina != 0)
        {
            staminaBar.value -= lValue * Time.deltaTime;
        }
    }

    public void JumpCost()
    {
        if(currentStamina != 0)
        {
            staminaBar.value -= jValue * Time.deltaTime;
        }
    }

    

    public void Die()
    {
        if(staminaBar.value == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
