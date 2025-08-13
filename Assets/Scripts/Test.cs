using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private InoutSO Inout;

    private void Start()
    {
        foreach (var aa in Inout.InoutDictionary.Keys)
        {
            Debug.Log(aa);
        }
    }
}
