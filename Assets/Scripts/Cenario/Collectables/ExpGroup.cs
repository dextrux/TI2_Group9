using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGroup : MonoBehaviour
{
    [SerializeField]private Transform[] _childrens;
    public void SetActiveXp()
    {
        
        foreach (Transform t in _childrens)
        {
            t.gameObject.SetActive(true);
        }
    }
}
