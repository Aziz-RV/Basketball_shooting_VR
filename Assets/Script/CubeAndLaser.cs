using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR.Extras;

public class CubeAndLaser : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject sceneManager;
    public GameObject player;
    public bool selected;

    // Start is called before the first frame update
    void Start()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
        selected = false;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void PointerInside(object sender, PointerEventArgs e)
    {

        if (e.target.name == gameObject.name && selected == false)
        {
            Debug.Log("inside: " + e.target.name);
            selected = true;
        }
    }
    public void PointerOutside(object sender, PointerEventArgs e)
    {

        if (e.target.name == gameObject.name && selected == true)
        {
            selected = false;
        }
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == gameObject.name)
        {
            Debug.Log("pointer click on object " + e.target.name);
            sceneManager.SetActive(true);
        }
        selected = false;
    }

    public bool get_selected_value()
    {
        return selected;
    }
}
