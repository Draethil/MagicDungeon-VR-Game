using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustyDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rusty_Key"))
        {
            myDoor.Play("RustyDoorOpen", 0, 0.0f);
            Destroy(other.gameObject);
        }
    }
}
