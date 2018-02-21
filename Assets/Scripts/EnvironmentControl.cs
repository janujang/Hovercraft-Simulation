using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentControl : MonoBehaviour
{
    public Transform hoverCraft;
    public GameObject land;
    public GameObject water;
    public GameObject numPadUI;
    public Transform mass;
    public Transform stopBlock;

    public Button massBtn;
    public Button upwardForceBtn;
    public Button forwardForceBtn;

    public float offset;

    private Vector3 startPos;
    private Quaternion startRot;
    private Vector3 massStartPos;
    private Quaternion massStartRot;
    private AltHoverControl altHoverControl;

	// Use this for initialization
	void Start ()
    {
        altHoverControl = hoverCraft.GetComponent<AltHoverControl>();
	}

    public void StartOver()
    {
        hoverCraft.position = stopBlock.position + stopBlock.right * offset;
        hoverCraft.rotation = stopBlock.rotation;

        altHoverControl.CutFans();
        altHoverControl.FullStop();
        numPadUI.SetActive(false);
        upwardForceBtn.image.color = Color.white;
        forwardForceBtn.image.color = Color.white;
        massBtn.image.color = Color.white;
    }

    public void ToggleGround ()
    {
        land.SetActive(!land.activeInHierarchy);
        water.SetActive(!water.activeInHierarchy);
        StartOver();
    }
}
