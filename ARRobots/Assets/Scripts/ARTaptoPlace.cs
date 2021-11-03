using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTaptoPlace : MonoBehaviour
{
    public GameObject spawnPrefeb; //to be spawn (instantiated)
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject spawnedPrefeb;
    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {


        if(spawnedPrefeb == null)
        {
            if (Input.touchCount > 0) //Identify the number of touches
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;

                    spawnedPrefeb = Instantiate(spawnPrefeb, hitPose.position, hitPose.rotation);
                }
            }
        }
        
    }
}
