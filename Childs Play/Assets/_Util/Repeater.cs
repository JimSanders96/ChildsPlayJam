using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Repeater : MonoBehaviour {

    public float RepeatTime = 1f;
    public float StartDelay = 1f;
    public UnityEvent OnRepeat;

    private void OnEnable()
    {
        InvokeRepeating("InvokeEvent", StartDelay, RepeatTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    private void InvokeEvent()
    {
        OnRepeat.Invoke();
    }

}
