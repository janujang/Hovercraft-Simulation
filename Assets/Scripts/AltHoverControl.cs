using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltHoverControl : MonoBehaviour
{
    public float forceUp = 4.905f;
    public float forceForward = 1f;
    public float fanDistance = 0.1f;

    private bool fan = false;
    private bool thrust = false;
    private Rigidbody rigid;
    

	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
	}

    public void ToggleHover()
    {
        fan = !fan;
    }

    public void ToggleThrust()
    {
        thrust = !thrust;
    }

    public void CutFans()
    {
        fan = false;
        thrust = false;
    }

    public void FullStop()
    {
        rigid.velocity = new Vector3(0, 0, 0);
    }
	
	void FixedUpdate ()
    {
        if (Physics.Raycast(transform.position, -transform.up, fanDistance))
        {
            if (fan)
            {
                rigid.AddForce(new Vector3(0, forceUp, 0));
            }

            if (thrust)
            {
                rigid.AddForce(-transform.right * forceForward);
            }
        }
	}

}
