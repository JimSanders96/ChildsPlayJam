using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{

    public RandomEventDisplay Display;
    public RandomEvent[] AllEvents;
    public float OccurrancePercentage = 0.1f;

    public void TryGenerateRandomEvent()
    {
        if (Random.Range(0f, 1f) <= OccurrancePercentage)
        {
            Display.Init(GetRandomEvent());
            Display.gameObject.SetActive(true);
        }
        else
        {
            Display.gameObject.SetActive(false);
        }
    }

    private RandomEvent GetRandomEvent()
    {
        return RandomUtil.RandomElement(AllEvents);
    }
}
