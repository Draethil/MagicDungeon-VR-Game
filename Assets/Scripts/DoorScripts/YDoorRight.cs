using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YDoorRight : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door_Key"))
        {
            myDoor.Play("DoubleDoorRightOpen", 0, 0.0f);
            Destroy(other.gameObject);
        }
    }
}
