using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private bool stopKilling;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() )stopKilling = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Player>() && !stopKilling)
        {
            stopKilling = other.GetComponent<Player>().Dead();
        }
    }
}
