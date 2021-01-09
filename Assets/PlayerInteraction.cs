using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	
	public float rate = 0.25f;                                        // Number in seconds which controls how often the player can fire
    public float range = 50f;
	private Camera fpsCam;                                                // Holds a reference to the first person camera
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	private float nextFire; 
	
    // Start is called before the first frame update
    void Start()
    {
        fpsCam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
        {
			nextFire = Time.time + rate;
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
			RaycastHit hit;
			
			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, range))
			{
				print("Found an object - distance: " + hit.distance);
			}
		}
    }
}
