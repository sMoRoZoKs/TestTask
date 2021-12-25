using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Finish();
        }
    }
}
