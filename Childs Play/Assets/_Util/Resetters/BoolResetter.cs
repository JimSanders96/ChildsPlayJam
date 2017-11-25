
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolResetter : ScriptableObject
{
    public bool SaveOnReset = true;
    public BoolVariable[] BoolVariables;
    public bool BoolResetValue = false;

    public void ResetAll()
    {
        foreach (BoolVariable var in BoolVariables)
        {
            var.Value = BoolResetValue;
            TrySaveVariable(var);
        }
        Debug.Log(name + ": Reset completed.");
    }

    private void TrySaveVariable(BoolVariable var)
    {
        if (!SaveOnReset)
            return;

        SaveLoader.SaveBool(var);
    }
}
