using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPadController : MonoBehaviour {

    private Text txt;
    private Button btn;
    public GameObject numPadUI;
    private bool noPoint;

	// Use this for initialization

    public void UseNumPad(Text current, Button button)
    {
        numPadUI.SetActive(true);
        txt = current;
        txt.text = "";
        noPoint = true;
        btn = button;
        btn.image.color = Color.grey;
    }

    public void add0()
    {
        if(txt)
            txt.text += "0";
    }
    public void add1()
    {
        if (txt)
            txt.text += "1";
    }
    public void add2()
    {
        if (txt)
            txt.text += "2";
    }
    public void add3()
    {
        if (txt)
            txt.text += "3";
    }
    public void add4()
    {
        if (txt)
            txt.text += "4";
    }
    public void add5()
    {
        if (txt)
            txt.text += "5";
    }
    public void add6()
    {
        if (txt)
            txt.text += "6";
    }
    public void add7()
    {
        if (txt)
            txt.text += "7";
    }
    public void add8()
    {
        if (txt)
            txt.text += "8";
    }
    public void add9()
    {
        if (txt)
            txt.text += "9";
    }
    public void addDot()
    {
        if (txt && noPoint) {
            txt.text += ".";
            noPoint = false;
        }
            
    }
    public void done()
    {
        if (txt)
        {
            btn.image.color = Color.white;
            txt = null;
            btn = null;
            numPadUI.SetActive(false);
            FindObjectOfType<AltHoverControl>().changeAddedMass();
            FindObjectOfType<AltHoverControl>().changeForwardForce();
            FindObjectOfType<AltHoverControl>().changeUpwardForce();
        }
    }
}
