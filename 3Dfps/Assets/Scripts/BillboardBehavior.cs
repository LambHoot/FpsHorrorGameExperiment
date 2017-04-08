using UnityEngine;
using System.Collections;

public class BillboardBehavior : MonoBehaviour {

    public GameObject target;

    void Start () {
	
	}
	
	void Update () {
        lookAtTarget();
    }

    //from http://wiki.unity3d.com/index.php?title=CameraFacingBillboard
    void lookAtTarget()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward,
            target.transform.rotation * Vector3.up);
    }

}
