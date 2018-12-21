using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (stepRecord.stepNum == 6)
        {
            if (other.gameObject.CompareTag("CheckArea"))
            {
                Debug.Log("Step6");
                stepRecord.stepNum = 7;
            }
            
        }
        else
        {
            if (other.gameObject.CompareTag("CheckArea"))
            {
                Debug.Log("WrongStep");
            }
        }

    }
}
