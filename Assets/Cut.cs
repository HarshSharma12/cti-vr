using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public GameObject currentBody;
    public GameObject nextBody;
    Vector3 originalPos;

    // Use this for initialization
    void Start () {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        print("Cut Start");
        print(originalPos);
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider other)
    {
        stepRecord.currentIntrument = gameObject;
        stepRecord.currentIntrumentOriginalPos = originalPos;
        if (!stepRecord.IsActionCompleted)
        {
            stepRecord.IsStepCompleted = false;
            if (stepRecord.lastStepCompleted == 2 && stepRecord.currentStepNum == 3)
            {
                stepRecord.wrongStep = false;
                if (other.gameObject.CompareTag("CheckArea"))
                {
                    Debug.Log("Step3");
                    currentBody.SetActive(false);
                    nextBody.SetActive(true);
                    stepRecord.currentBody = nextBody;
                    stepRecord.IsActionCompleted = true;
                    stepRecord.IsStepCompleted = false;
                }
            }
            else
            {
                if (other.gameObject.CompareTag("CheckArea"))
                {
                    stepRecord.wrongStep = true;
                    Debug.Log("WrongStep");
                }
            }
        }
    }

}