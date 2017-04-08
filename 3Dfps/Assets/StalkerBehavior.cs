using UnityEngine;
using System.Collections;

public class StalkerBehavior : MonoBehaviour {

    public GameObject followTarget;
    public float stopDistance;
    public float stalkSpeed;
    public float targetViewDistance;
    Renderer renderer;

    void Start () {
        stopDistance = 2.0f;
        stalkSpeed = 0.0008f;
        targetViewDistance = 10f;
        renderer = GetComponent<Renderer>();
    }
	
	void Update () {
        if(Vector3.Distance(transform.position, followTarget.transform.position) < stopDistance){
            triggerGameOver();
        }
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (isInPlayerView())
            return;
        //calculate distance between self and target
        float distance = Vector3.Distance(transform.position, followTarget.transform.position);
        if(distance > stopDistance)
        {
            //move the stalker in X and Z
            Vector3 direction = followTarget.transform.position - transform.position;
            direction = Vector3.ClampMagnitude(direction * stalkSpeed, 1.0f);
            transform.Translate(direction, Space.World);
            transform.position = new Vector3(transform.position.x, 0.661f, transform.position.z);
        }
        else
        {
            triggerGameOver();
        }
    }

    bool isInPlayerView()
    {
        if(Vector3.Distance(transform.position, followTarget.transform.position) > targetViewDistance)
            return false;//if too far, move regardless of visibility
        if (renderer.isVisible)
            return true;//if is visible, don't move
        return false;//otherwise, move
    }

    void triggerGameOver()
    {
        print("GAME OVER");
    }

}
