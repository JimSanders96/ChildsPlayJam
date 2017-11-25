using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{

    public RandomEventDisplay Display;
    public RandomEvent[] AllEvents;
    public float OccurrancePercentage = 0.1f;
    public int MinCooldownRounds = 1;

    private int roundsPlayedSinceLastEvent = 0;
    private bool cooldownActive = false;

    public void TryGenerateRandomEvent()
    {
        

        if (cooldownActive)
        {
            Display.gameObject.SetActive(false);
            Debug.Log("Cooldown active");
            roundsPlayedSinceLastEvent++;
            if (roundsPlayedSinceLastEvent >= MinCooldownRounds)
                cooldownActive = false;
            return;
        }

        if (Random.Range(0f, 1f) <= OccurrancePercentage)
        {
            Display.Init(GetRandomEvent());
            Display.gameObject.SetActive(false);
            Display.gameObject.SetActive(true);
            cooldownActive = true;
        }

    }

    private RandomEvent GetRandomEvent()
    {
        return RandomUtil.RandomElement(AllEvents);
    }

    private void UpdateCooldown()
    {
        if (cooldownActive)
        {
            roundsPlayedSinceLastEvent++;
            if (roundsPlayedSinceLastEvent >= MinCooldownRounds)
                cooldownActive = false;
        }
    }
}
