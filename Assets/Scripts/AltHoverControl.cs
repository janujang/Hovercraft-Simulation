using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class AltHoverControl : MonoBehaviour, IInputClickHandler
{
    public GameObject dialog;

    public float forceUp = 4.905f;
    public float forceForward = 1f;
    public float fanDistance = 0.1f;

    public Rigidbody massObject;
    public float mass = 0.5f;

    public Text addedMassTxt;
    public Text upwardForceTxt;
    public Text forwardForceTxt;
    public Text massTxt;

    public Button upFanBtn;
    public Button fwdFanBtn;

    public Toggle loopToggle;

    private bool fan = false;
    private bool thrust = false;
    private Rigidbody hoverObject;
    private Color originalColor;
    private Color activeColor;
    private EnvironmentControl environmentControl;


    void Start ()
    {
        hoverObject = GetComponent<Rigidbody>();
        originalColor = upFanBtn.image.color;
        activeColor = new Color(231f / 255f, 76f / 255f, 60f / 255f, 255f / 255f);
        ChangeMassText();
        environmentControl = FindObjectOfType<EnvironmentControl>();
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
            ChangeMassText();
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
    public void OnInputClicked(InputClickedEventData eventData)
    {
        dialog.SetActive(true);
        ToggleThrust();
        ToggleHover();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (loopToggle.isOn && other.CompareTag("Finish"))
        {
            Debug.Log("Crash");
            environmentControl.Loop();
        }

    }

    public void ChangeMassText()
    {
        if (massObject.gameObject.activeInHierarchy)
        {
            massTxt.text = ((hoverObject.mass + massObject.mass) * 1000).ToString();
        }
        else
        {
            massTxt.text = (hoverObject.mass * 1000).ToString();
        }
    }
}
