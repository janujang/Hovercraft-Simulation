using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentControl : MonoBehaviour
{
    public Transform hoverCraft;
    public GameObject land;
    public GameObject water;

    private Vector3 startPos;
    private Quaternion startRot;
    private AltHoverControl altHoverControl;

	// Use this for initialization
	void Start ()
    {
        startPos = hoverCraft.position;
        startRot = hoverCraft.rotation;
        altHoverControl = hoverCraft.GetComponent<AltHoverControl>();
	}

    public void StartOver()
    {
        hoverCraft.position = startPos;
        hoverCraft.rotation = startRot;
        altHoverControl.CutFans();
        altHoverControl.FullStop();
    }

    public void ToggleGround ()
    {
        land.SetActive(!land.activeInHierarchy);
        water.SetActive(!water.activeInHierarchy);
        StartOver();
    }
}
