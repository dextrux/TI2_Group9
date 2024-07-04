using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGroup : MonoBehaviour
{
    public void SetActiveXp()
    {
        Transform[] _childrens = GetComponentsInChildren<Transform>();
        foreach (Transform t in _childrens)
        {
            t.gameObject.SetActive(true);
        }
    }
}
