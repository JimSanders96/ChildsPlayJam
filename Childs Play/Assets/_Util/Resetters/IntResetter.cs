
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntResetter : ScriptableObject
{
    public bool SaveOnReset = true;
    public IntVariable[] IntVariables;
    public int IntResetValue = 0;


    public void ResetAll()
    {
        foreach (IntVariable var in IntVariables)
        {
            var.Value = IntResetValue;
            TrySaveVariable(var);
        }
        Debug.Log(name + ": Reset completed.");
    }

    private void TrySaveVariable(IntVariable var)
    {
        if (!SaveOnReset)
            return;

        SaveLoader.SaveInt(var);
    }
}
