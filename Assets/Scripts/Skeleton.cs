using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Animator animator;
    public Transform patroulTarget;
    private Vector3 startposition;
    private bool goingTowardsTarget;
    public float speed = 1;
    public float waitTime = 1;
    private float lastTimeReachedTarget = -1000;
    public float rotationDamping = 5;
    public bool patroulActive = true;
    public bool loopPatroul = true;
    public Collider[] colliders;
    
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        patroulTarget.SetParent(null);
        goingTowardsTarget = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(!patroulActive)
        {
            animator.SetBool("walking", false);
            return;
        }

        Vector3 targetPosition;

        if(goingTowardsTarget)
        {
            targetPosition = patroulTarget.position;
        } else
        {
            targetPosition = startposition;
        }

        bool isWaiting = Time.time - lastTimeReachedTarget < waitTime;
        animator.SetBool("walking", !isWaiting);
        if(isWaiting)
        {
            rotateTowardsTarget(targetPosition);
            return;
        }

        moveTowardsPoint(targetPosition);
        if (isCloseToPoint(targetPosition))
        {
            if(loopPatroul)
            {
                goingTowardsTarget = !goingTowardsTarget;
            } else
            {
                patroulActive = false;
            }
            lastTimeReachedTarget = Time.time;
        }
    }

    void moveTowardsPoint(Vector3 point)
    {
        Vector3 direction = (point - transform.position).normalized;
        Vector3 distanceToTravel = direction * speed * Time.deltaTime;
        transform.position += distanceToTravel;

        if(!isCloseToPoint(point, 0.25f))
        {
            //Vector3 isCurrentlyLookingAt = transform.position + (1000 * transform.forward);
            //Vector3 newLookAtPoint = (isCurrentlyLookingAt + point) / 2;
            transform.LookAt(point);
        }
        
    }

    bool isCloseToPoint(Vector3 point, float closeDistance = 0.1f)
    {
        float distanceToPatroulTarget = Vector3.Distance(point, transform.position);
        return distanceToPatroulTarget < closeDistance;
    }

    void rotateTowardsTarget(Vector3 targetPosition)
    {
        var lookPos = targetPosition - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    public void setPatroulActive()
    {
        patroulActive = true;
    }

    public void die()
    {
        animator.SetBool("isDead", true);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].gameObject.layer = LayerMask.NameToLayer("Props");
            colliders[i].gameObject.tag = "Untagged";
        }
        gameObject.layer = LayerMask.NameToLayer("Props");
        gameObject.tag = "Untagged";
    }

    private void OnCollisionEnter(Collision collision)
    {
        SwingingTrap trap = collision.collider.GetComponent<SwingingTrap>();

        if(trap != null)
        {
            die();
        }
    }
}
