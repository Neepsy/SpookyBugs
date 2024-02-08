using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlightController : MonoBehaviour
{
	private RaycastHit mHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(10);
		transform.LookAt(point);
    }
}
