using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotTap : MonoBehaviour {

    public RaycastTap RCTap;
   
    public HingeJoint2D joint;

    public LineRenderer line;

    public SpriteRenderer pivote;

    public Transform car;

    Vector3[] positions = new Vector3[2];



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown (0))
        {
            Taped(RCTap.GetTargets());
        }
        positions[0] = transform.position;
        positions[1] = car.position;

        line.SetPositions(positions);
	}
    public void Taped(Vector3 positionTap){
        transform.position = positionTap;
        joint.enabled = true;
        line.enabled = true;
        pivote.enabled = true;
    }
}
