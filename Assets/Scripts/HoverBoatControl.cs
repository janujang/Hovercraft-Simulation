using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoatControl : MonoBehaviour
{
    public float equilibrium = 4.905f;
    public float raiseFactor = 0.1f;

    public float hoverHeight;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        //rigid.AddForce(new Vector3(0, equilibrium, 0));

        Ray ray = new Ray(transform.position, new Vector3(0, -1f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            rigid.AddForce(new Vector3(0, 1, 0) * (equilibrium + ((hoverHeight - hit.distance) / hoverHeight) * raiseFactor));
        }
        else 
        {
            rigid.AddForce(new Vector3(0, equilibrium - raiseFactor, 0));
        }
    }
}
