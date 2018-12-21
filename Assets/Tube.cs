using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public GameObject currentBody;
    public GameObject nextBody;

    public GameObject emptyTube;
    public GameObject bloodTube;
    Animator anim1;
    Animator anim2;

    Vector3 originalPos;

    GameObject clamp;
    GameObject tube;


    bool collidingWithBody = false;
    bool collidingWithClamp = false;
    
    // Use this for initialization
    void Start()
    {
        anim1 = emptyTube.GetComponent<Animator>();
        anim2 = bloodTube.GetComponent<Animator>();
        tube = gameObject;
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        print("Cut Start");
        print(originalPos);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckArea"))
        {
            collidingWithBody = true;
            Debug.Log("collidingWithBody");
        }
        if (other.gameObject.CompareTag("KellyClamp"))
        {
            clamp = other.gameObject;
            collidingWithClamp = true;
            Debug.Log("collidingWithClamp");
        }

        stepRecord.currentIntrument = gameObject;
        stepRecord.currentIntrumentOriginalPos = originalPos;
        if (!stepRecord.IsActionCompleted)
        {
            stepRecord.IsStepCompleted = false;
            if (stepRecord.lastStepCompleted == 3 && stepRecord.currentStepNum == 4)
            {
                stepRecord.wrongStep = false;
                if (collidingWithBody && collidingWithClamp)
                {
                    Debug.Log("collidingWithBodyAndClamp");
                    Debug.Log("Step4");
                    currentBody.SetActive(false);
                    nextBody.SetActive(true);
                    clamp.SetActive(false);
                    tube.SetActive(false);
                    emptyTube.SetActive(true);
                    bloodTube.SetActive(true);
                    anim1.SetTrigger("bloodFlow");
                    anim2.SetTrigger("bloodStart");

                    stepRecord.currentBody = nextBody;
                    stepRecord.IsStepCompleted = true;
                    stepRecord.lastStepCompleted = stepRecord.currentStepNum;
                    stepRecord.currentStepNum += 1;
                    stepRecord.IsActionCompleted = false;
                    stepRecord.currentIntrument.transform.position = stepRecord.currentIntrumentOriginalPos;
                    
                }
            }
            else
            {
                if (collidingWithBody && collidingWithClamp)
                {
                    stepRecord.wrongStep = true;
                    Debug.Log("WrongStep");
                }
            }
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("CheckArea"))
        {
            collidingWithBody = false;
            Debug.Log("notCollidingWithBody");
        }
        else if (other.gameObject.CompareTag("KellyClamp"))
        {
            collidingWithClamp = false;
            Debug.Log("notCollidingWithClamp");
        }
    }

}