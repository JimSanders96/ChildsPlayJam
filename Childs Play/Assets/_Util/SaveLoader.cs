
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoader
{

    #region Loading
    #region Int
    public static int LoadInt(IntVariable var)
    {
        return PlayerPrefs.GetInt(var.name);
    }

    public static int LoadInt(IntReference reference)
    {
        return PlayerPrefs.GetInt(reference.Variable.name);
    }

    public static int LoadInt(string id)
    {
        return PlayerPrefs.GetInt(id);
    }
    #endregion

    #region String
    public static string LoadString(string id)
    {
        return PlayerPrefs.GetString(id);
    }
    #endregion

    #region Bool
    public static int LoadBool(BoolVariable var)
    {
        return PlayerPrefs.GetInt(var.name);
    }

    public static int LoadBool(BoolReference reference)
    {
        return PlayerPrefs.GetInt(reference.Variable.name);
    }

    public static int LoadBool(string id)
    {
        return PlayerPrefs.GetInt(id);
    }
    #endregion

    #endregion

    #region Saving
    #region Int
    public static void SaveInt(IntVariable var)
    {
        PlayerPrefs.SetInt(var.name, var.Value);
    }

    public static void SaveInt(IntReference reference)
    {
        PlayerPrefs.SetInt(reference.Variable.name, reference);
    }

    public static void SaveInt(string id, int value)
    {
        PlayerPrefs.SetInt(id, value);
    }
    #endregion

    #region String
    public static void SaveString(string id, string value)
    {
        PlayerPrefs.SetString(id, value);
    }
    #endregion

    #region Bool
    public static void SaveBool(BoolVariable var)
    {
        PlayerPrefs.SetInt(var.name, var.Value == true ? 1 : 0);
    }

    public static void SaveBool(BoolReference reference)
    {
        PlayerPrefs.SetInt(reference.Variable.name, reference == true ? 1 : 0);
    }

    public static void SaveBool(string id, int value)
    {
        PlayerPrefs.SetInt(id, value);
    }
    #endregion
    #endregion
}
