using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerZone : MonoBehaviour
{
    public UnityEvent entryEvent;
    public bool singleUse;

    private bool alreadyTriggered;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entry");
        if (singleUse && alreadyTriggered) return;

        alreadyTriggered = true;
        entryEvent.Invoke();
    }
}
