using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTap : MonoBehaviour
{
    public PivotTap Pivot;
    public LayerMask Capa;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public Vector3 GetTargets()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, Mathf.Infinity,Capa))
        {
            return hit.point;
        }
        else{
            return transform.position;
        }

        }
    }


   
