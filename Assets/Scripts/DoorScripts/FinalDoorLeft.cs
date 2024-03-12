using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorLeft : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golden_Key"))
        {
            myDoor.Play("FinalDoorLeftOpen", 0, 0.0f);
            Destroy(other.gameObject);
        }
    }
}
