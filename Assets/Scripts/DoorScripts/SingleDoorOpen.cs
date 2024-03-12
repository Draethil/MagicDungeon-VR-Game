using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoorOpen : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door_Key"))
        {
            myDoor.Play("SingleDoorOpen", 0, 0.0f);
            Destroy(other.gameObject);
        }
    }
}