using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderFollow : MonoBehaviour
{
    public Transform target;  // The target (enemy) to follow

    private RectTransform sliderRectTransform;
    private Canvas canvas;
    public Camera mainCamera;

    void Start()
    {
        //-1493.15 -630.27 52.72
        //0 -0.66400 10.6
        sliderRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
       // mainCamera = Camera.main;
    }

    void Update()
    {
        if (target != null)
        {
            //this.position = new Vector3(target.transform.position.x - -1493.15f, target.transform.position.y - -629.606f, target.transform.position.z - -42.12f);
           // this.PosX = target.transform.position.x - -1493.15f;
            // Convert the 3D world position of the target to screen space

            
            sliderRectTransform.position = new Vector3(target.transform.position.x - (-1.0f * 1493.15f), target.transform.position.y - (-1.0f * 629.606f), target.transform.position.z - (-1.0f * 42.12f));

            // Ensure the slider stays in front of other UI elements
            //sliderRectTransform.SetAsLastSibling();
        }
            // Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

            // // Set the slider's position to the screen position
            // sliderRectTransform.position = screenPos;

            // // Ensure the slider stays in front of other UI elements
            // sliderRectTransform.SetAsLastSibling();
       // }
    }
}
