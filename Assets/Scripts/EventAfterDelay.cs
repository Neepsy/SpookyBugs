using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAfterDelay : MonoBehaviour
{
    public float delay;
    public UnityEvent e;

    public void OnTrigger()
    {
        StartCoroutine(RunDelay());
    }

    IEnumerator RunDelay()
    {
        yield return new WaitForSecondsRealtime(delay);
        e.Invoke();
        yield return null;
    }
}
