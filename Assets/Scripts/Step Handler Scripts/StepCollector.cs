using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCollector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {
        //Debug.Log("Tag is " + target.tag);

        if (target.tag == "Sandy" || target.tag == "Step")
        {
            //Debug.Log("Enters Conditional");
            target.gameObject.SetActive(false);
        }
    }
}
