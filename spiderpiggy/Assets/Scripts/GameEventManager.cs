using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public event Action OnItemTriggerEnter;
    public static GameEventManager current;


    private void Awake()
    {
        current = this;
    }

    

    public void ItemTriggerEnter()
    {
        if (OnItemTriggerEnter != null)
        {
            OnItemTriggerEnter();
        }
    }

}
