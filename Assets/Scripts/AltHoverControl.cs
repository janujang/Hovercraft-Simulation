using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltHoverControl : MonoBehaviour
{
    public float forceUp = 4.905f;
    public float forceForward = 1f;
    public float fanDistance = 0.1f;

    public Rigidbody massObject;
    public float mass = 0.5f;

    public Text addedMassTxt;
    public Text upwardForceTxt;
    public Text forwardForceTxt;

    public Button upFanBtn;
    public Button fwdFanBtn;

    private bool fan = false;
    private bool thrust = false;
    private Rigidbody hoverObject;
    private Color originalColor;
    private Color activeColor;


    void Start ()
    {
        hoverObject = GetComponent<Rigidbody>();
        originalColor = upFanBtn.image.color;
        activeColor = new Color(231f / 255f, 76f / 255f, 60f / 255f, 255f / 255f);
    }

    public void ToggleHover()
    {
        fan = !fan;
        if (fan)
        {
            upFanBtn.image.color = activeColor;
        }
        else
        {
            upFanBtn.image.color = originalColor;
        }
    }

    public void ToggleThrust()
    {
        thrust = !thrust;
        if (thrust)
        {
            fwdFanBtn.image.color = activeColor;
        }
        else
        {
            fwdFanBtn.image.color = originalColor;
        }
    }

    public void CutFans()
    {
        fan = false;
        thrust = false;
        fwdFanBtn.image.color = originalColor;
        upFanBtn.image.color = originalColor;
    }

    public void FullStop()
    {
        massObject.velocity = new Vector3(0, 0, 0);
        hoverObject.velocity = new Vector3(0, 0, 0);
    }
	
	void FixedUpdate ()
    {
        if (Physics.Raycast(transform.position - (transform.up * 0.01f), -transform.up, fanDistance))
        {
            if (fan)
            {
                hoverObject.AddForce(new Vector3(0, forceUp, 0));
            }

            if (thrust)
            {
                hoverObject.AddForce(-transform.right * forceForward);
            }
        }
	}
    public void changeAddedMass()
    {
        if (addedMassTxt.text != "" && addedMassTxt.text != ".")
        {
            mass = float.Parse(addedMassTxt.text);
            massObject.mass = mass/1000;
        }
    }
    public void changeUpwardForce()
    {
        if (upwardForceTxt.text != "" && upwardForceTxt.text != ".")
        {
            forceUp = float.Parse(upwardForceTxt.text);

            float tempMass = massObject.mass;
            if (!massObject.gameObject.activeInHierarchy)
                tempMass = 0f;
            if (forceUp > (tempMass + hoverObject.mass) * 9.8f)
            {
                forceUp = (tempMass + hoverObject.mass) * 9.8f;
                int temp = (int)(forceUp * 100f);
                forceUp = ((float)(temp)) / 100f;
                upwardForceTxt.text = forceUp.ToString();
            }
                
        }
    }
    public void changeForwardForce()
    {
        if (forwardForceTxt.text != "" && forwardForceTxt.text != ".")
        {
            forceForward = float.Parse(forwardForceTxt.text);
        }
    }
}
