using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Kickstarter : MonoBehaviour
{

    public UnityEvent OnStart;
    public UnityEvent OnAwake;
    public UnityEvent OnEnableEvent;

    private void Start()
    {
        OnStart.Invoke();
    }

    private void Awake()
    {
        OnAwake.Invoke();
    }

    private void OnEnable()
    {
        OnEnableEvent.Invoke();
    }
}
