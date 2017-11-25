using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject ObjectToSpawn;
    public GameObject Parent;

    public void Spawn()
    {
        Instantiate(ObjectToSpawn).transform.SetParent(Parent.transform);
    }
}
