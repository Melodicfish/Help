using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;            //Array of all the back and forgrounds to be parallaxed;
    private float[] parallaxScales;           //proportion of the cameras movement to move the layers by
    [Range(0.1f,10)] public float smoothing;  // how smooth he parallax is going to be.

    private Transform cam;                   // reference to the main cameras transform;
    private Vector3 previousCamPos;         // the position od the camera in the previous frame


    private void Awake()
    {
        //set cam reference
        cam = Camera.main.transform;

    }

    void Start()
    {
        //the previous frame had the current frames camera position
        previousCamPos = cam.position;

        // asigning coresponding parallaxsacles
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    
    void Update()
    {
        //for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //the parallax is the opposite of the cameras movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //set target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create taget position which is the backgrounds current position with it's target x postion
            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }
        //set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
