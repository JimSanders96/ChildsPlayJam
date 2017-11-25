using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventDisplay : MonoBehaviour
{

    public Image IconImage;

    public void Init(RandomEvent randomEvent)
    {
        IconImage.sprite = randomEvent.Icon;
        Debug.Log("Displaying: " + randomEvent.name);
    }

}
