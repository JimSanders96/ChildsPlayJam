using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    public GameObject[] Targets;
    public bool NextActiveStatus = true;

    private bool shouldActivate;

    private void Awake()
    {
        shouldActivate = NextActiveStatus;
    }

    public void ActivateAllByParameter()
    {
        if (shouldActivate)
            ActivateAll();
        else
            DeactivateAll();
    }

    public void ToggleSetActiveParameter()
    {
        shouldActivate = !shouldActivate;
    }

    public void DeactivateAll()
    {
        foreach (GameObject obj in Targets)
            obj.SetActive(false);
        shouldActivate = true;
    }

    public void ActivateAll()
    {
        foreach (GameObject obj in Targets)
            obj.SetActive(true);
        shouldActivate = false;
    }

    public void ActivateForTime(float time)
    {
        ActivateAll();
        Invoke("DeactivateAll", time);
    }
}
