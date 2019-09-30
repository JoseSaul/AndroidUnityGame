using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        offset = (target.position + new Vector3(0,-1,0)) - transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        var position = target.position;
        transform.position = position - offset;
        transform.LookAt(new Vector3(0,1,0) + position);
    }
    
    
}
