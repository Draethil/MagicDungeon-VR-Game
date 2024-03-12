using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PillarGroup : MonoBehaviour
{
    [SerializeField] private Animator myGrid = null;
    [SerializeField] private Animator myLeftDoor = null;
    [SerializeField] private Animator myRightDoor = null;

    bool blueActiv = false;
    bool redActiv = false;
    bool yellowActiv = false;
    bool gridIsOpen = false;

    public Transform[] pillarLockTransforms;
    private bool[] pillarfulStatus = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedCrystal") && !redActiv)
        {
            redActiv = true;
            myLeftDoor.Play("DoubleDoorLeftOpen", 0, 0.0f);
            myRightDoor.Play("DoubleDoorRightOpen", 0, 0.0f);
            LockToClosestPillarTransform(other.gameObject);
        }

        if (other.CompareTag("BlueCrystal"))
        {
            blueActiv = true;
            LockToClosestPillarTransform(other.gameObject);
        }

        if (other.CompareTag("YellowCrystal"))
        {
            yellowActiv = true;
            LockToClosestPillarTransform(other.gameObject);
        }

        if (blueActiv && redActiv && yellowActiv && !gridIsOpen)
        {
            gridIsOpen = true;
            myGrid.Play("MyGridOpen", 0, 0.0f);
        }
    }

    private void LockToClosestPillarTransform(GameObject gobj)
    {
        int closestPillarTransformIndex = -1;
        float shortestDistance = 9999999999;

        for (int i = 0; i < pillarLockTransforms.Length; i++)    
        {
            if(!pillarfulStatus[i])
            {
                float distance = Vector3.Distance(gobj.transform.position, pillarLockTransforms[i].position);
                
                if(distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestPillarTransformIndex = i;
                }
            }
        }

        if(closestPillarTransformIndex < 0)
        {
            return;
        }

        Transform closestPillar = pillarLockTransforms[closestPillarTransformIndex];

        gobj.transform.position = closestPillar.position;
        gobj.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gobj.GetComponent<XRGrabInteractable>());
    }
}
