﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incision2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (stepRecord.stepNum == 5)
        {
            if (other.gameObject.CompareTag("CheckArea"))
            {
                Debug.Log("Step5");
                stepRecord.stepNum = 6;
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
