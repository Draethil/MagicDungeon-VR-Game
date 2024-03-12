using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorRight : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golden_Key"))
        {
            myDoor.Play("FinalDoorRightOpen", 0, 0.0f);
            Destroy(other.gameObject);
        }
    }
}
