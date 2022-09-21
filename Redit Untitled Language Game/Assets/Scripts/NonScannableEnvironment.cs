using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonScannableEnvironment : MonoBehaviour
{
    private Renderer _myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _myRenderer = GetComponent<Renderer>();
    }
    void ScanTriggered()
    {
        //_myRenderer.material.SetFloat("_HoloStrength", 0);
        _myRenderer.material.SetFloat("_Holo", 1);
       // _myRenderer.material.SetFloat("_Saturation", 0.5f);
        // _myRenderer.material.SetInteger("_Holo", 1);
        Debug.Log("Scanned");

    }
    void ScanUnTriggered()
    {
        _myRenderer.material.SetFloat("_Holo", 0);
        Debug.Log("UnScanned");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
