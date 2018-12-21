using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incision1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (stepRecord.stepNum == 4)
        {
            if (other.gameObject.CompareTag("CheckArea"))
            {
                Debug.Log("Step4");
                stepRecord.stepNum = 5;
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
