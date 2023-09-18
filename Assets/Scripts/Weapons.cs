using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


//Christian
public class Weapons : MonoBehaviour
{
    [SerializeField] private LineRenderer laser;
    [SerializeField] private Transform gunSpawn;
    [SerializeField] private RectTransform buttonRect;
    [SerializeField] private RectTransform Crosshair;
    [SerializeField] private Vector3 laserOffset;
    [SerializeField] private float maxDistance;
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private Vector3 rayOffset;
    private Vector3 localDirection;
    private Vector3 worldDirection;
    private bool soundPlayed;
    

    private void Awake()
    {
       
        laser.enabled = false;
        soundPlayed = false;
    }


    /// <summary>
    /// Enables the laser line renderer and plays the laser sound once
    /// </summary>
    private void LaserActivate()
    {
        laser.enabled = true;
        if(!soundPlayed)
        {
            audioSources[0].Play();
            soundPlayed = true;
        }
    }

    /// <summary>
    /// Stops the laser and audio
    /// Resets the laser start and end positions
    /// </summary>
    private void LaserDeactivate()
    {
        laser.enabled = false;
        soundPlayed = false;
        audioSources[0].Stop();
        laser.SetPosition(0, gunSpawn.position);
        laser.SetPosition(1, gunSpawn.position);
        
    }

    /// <summary>
    /// Activates the laser if a stationary touch is found on the right side of the screen
    /// Not sure if the magnitude check was necessary, but it made it feel better imo
    /// </summary>
    private void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touchInfo;
            touchInfo = Input.GetTouch(0);
       
            //Debug.Log("Touching " + touchInfo.fingerId.ToString());

            if ((touchInfo.phase == TouchPhase.Stationary && RectTransformUtility.RectangleContainsScreenPoint(buttonRect, touchInfo.position, Camera.main)) || (touchInfo.phase == TouchPhase.Moved && touchInfo.deltaPosition.magnitude < 5 && RectTransformUtility.RectangleContainsScreenPoint(buttonRect, touchInfo.position, Camera.main)))//if (touchInfo.phase == TouchPhase.Stationary && RectTransformUtility.RectangleContainsScreenPoint(buttonRect, touchInfo.position, Camera.main))
                LaserActivate();
                
            else
                LaserDeactivate();
    
        }

        

    }
    
    /// <summary>
    /// Sets the laser start position to the gun spawn transform with a small offset
    /// Sets the laser end position to the positon of the crosshair with a max distance to determin ray length
    /// </summary>
        private void FixedUpdate()
    {
        localDirection = transform.InverseTransformPoint(Crosshair.position) * maxDistance;
        worldDirection = transform.TransformDirection(localDirection);
        
        

        //Debug.Log("local " + localDirection + "  world " + worldDirection);
        Debug.DrawRay(gunSpawn.position + laserOffset, worldDirection);
        
        
        if (!laser.enabled)
            return;


        else
        {

            Ray ray = new Ray(gunSpawn.localPosition + laserOffset, worldDirection);

            ray.origin = ray.GetPoint(maxDistance);
            ray.direction = -ray.direction;

            laser.SetPosition(0, gunSpawn.localPosition + laserOffset);
            laser.SetPosition(1, localDirection);
            

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.collider.tag == "SmallShip")
                {
                    Debug.Log("SS destroyed");
                    Destroy(hit.collider.transform.gameObject);
                }
            }
        }

    }
}
