using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class InputFieldClick : MonoBehaviour
{
    public Button massBtn;
    public Button upwardForceBtn;
    public Button forwardForceBtn;
    public Text massTxt;
    public Text upwardForceTxt;
    public Text forwardForceTxt;
    public NumPadController numPadController;

    public void setNumPadToMass()
    {
        upwardForceBtn.image.color = Color.white;
        forwardForceBtn.image.color = Color.white;
        numPadController.UseNumPad(massTxt, massBtn);
        FindObjectOfType<AltHoverControl>().changeUpwardForce();
        FindObjectOfType<AltHoverControl>().changeForwardForce();
    }
    public void setNumPadToUpwardForce()
    {
        massBtn.image.color = Color.white;
        forwardForceBtn.image.color = Color.white;
        numPadController.UseNumPad(upwardForceTxt, upwardForceBtn);
        FindObjectOfType<AltHoverControl>().changeForwardForce();
        FindObjectOfType<AltHoverControl>().changeAddedMass();
    }
    public void setNumPadToForwardForce()
    {
        forwardForceBtn.image.color = Color.white;
        upwardForceBtn.image.color = Color.white;
        numPadController.UseNumPad(forwardForceTxt, forwardForceBtn);
        FindObjectOfType<AltHoverControl>().changeUpwardForce();
        FindObjectOfType<AltHoverControl>().changeAddedMass();
    }
}
