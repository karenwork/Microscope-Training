using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class TaptoPlace : MonoBehaviour
{
    public GameObject microscopePrefab;
    private ARRaycastManager aRRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 touchposition;
    [HideInInspector] public MicroscopePart lastSelectedPart;
    private GameObject spawnObject;
    public Camera arcamera;
    public float waitseconds = 1f;
    public DeBugCanvas deBugCanvas;
 
    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount >0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
       if (!TryGetTouchPosition(out Vector2 touchposition))
       {
            return;
       }
       if (aRRaycastManager.Raycast(touchposition,hits,TrackableType.PlaneWithinPolygon))
       {
            var hitPose = hits[0].pose;
            if (spawnObject == null)
            { 
                spawnObject = Instantiate(microscopePrefab, hitPose.position, hitPose.rotation); 
            }
       }
        Ray ray = arcamera.ScreenPointToRay(touchposition);
        RaycastHit hitObject;
        if (Physics.Raycast (ray,out hitObject))
        {
            lastSelectedPart = hitObject.transform.GetComponent<MicroscopePart>();

            deBugCanvas.selectedPartText.text = lastSelectedPart.gameObject.name;

            if (InstructionManager.Instance.isActiveAndEnabled)
            {
                InstructionManager.Instance.NextStep();
            }
        }
    }

    private IEnumerator TimedNextStep()
    {
        yield return new WaitForSeconds(waitseconds);
        InstructionManager.Instance.NextStep();
    }
}
