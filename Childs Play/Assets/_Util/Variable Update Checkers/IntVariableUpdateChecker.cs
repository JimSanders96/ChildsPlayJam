
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntVariableUpdateChecker : MonoBehaviour
{

    public IntVariable Variable;
    public GameEvent OnVariableUpdated;
    public bool OnlyCheckHigherValues;

    private int value = 0;

    void Update()
    {
        CheckVariable();
        value = Variable.Value;
    }

    private void CheckVariable()
    {
        if (value != Variable.Value)
        {
            if (OnlyCheckHigherValues && Variable.Value < value)
                return;

            value = Variable.Value;
            OnVariableUpdated.Raise();
            Debug.Log(Variable.name + " was updated!");
        }
    }
}
