using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class RandomEvent : ScriptableObject
{
    public Sprite Icon;
    public string Description;
    public UnityEvent OnAppeared;

}
