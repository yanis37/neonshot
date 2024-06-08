using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 6.0f; // 6 seconds
    public float currentStamina;
    public float CurrentStamina { get { return currentStamina; } }

    public StaminaBar staminaBar;
    public float loseStaminaCooldown = 0.1f;
    public bool flagStaminaCooldown = false;


    PlayerDash playerDash;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        playerDash = GetComponent<PlayerDash>();
    }

    void Update()
    {
        if (currentStamina < maxStamina)
        {
            regainStaminaOverTime(1.0f);
        }

        if (currentStamina <= 0)
        {
            currentStamina = 0;
            staminaBar.SetStamina(0);
        }

        if (playerDash.IsDashing && !flagStaminaCooldown && currentStamina > 3.0f)
        {
            loseStamina(3.0f);
            flagStaminaCooldown = true;
            Invoke("resetStamina", loseStaminaCooldown);
        }
    }

    void loseStamina(float stamina)
    {
        currentStamina -= stamina;
        staminaBar.SetStamina(currentStamina);
    }

    // to call in Update()
    void regainStaminaOverTime(float stamina)
    {
        currentStamina += stamina * Time.deltaTime;
        staminaBar.SetStamina(currentStamina);
    }

    void resetStamina()
    {
        flagStaminaCooldown = false;
    }
}
