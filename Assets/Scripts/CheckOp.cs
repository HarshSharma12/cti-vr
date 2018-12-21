using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckOp : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckArea"))
        {
            Debug.Log("PENGDAOLE");
        }

    }

}