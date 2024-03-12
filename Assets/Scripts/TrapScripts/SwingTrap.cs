using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTrap : MonoBehaviour
{
    [SerializeField] private Animator myTrap = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SwingTrapCrystal1"))
        {
            myTrap.Play("SwingTrap", 0, 0.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SwingTrapCrystal1"))
        {
            myTrap.Play("Idle", 0, 0.0f);
        }
    }
}
