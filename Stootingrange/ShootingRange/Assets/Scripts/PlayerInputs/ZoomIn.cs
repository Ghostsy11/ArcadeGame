using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{

    [SerializeField] private bool canZoom = true;
    [SerializeField] private KeyCode zoomKey = KeyCode.Mouse1;
    [SerializeField] private float timeToZoom = 0.3f;
    [SerializeField] private float zoomFOV =30f;
    private float defaultFOV;
    private Coroutine zoomRoutine;
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {

        defaultFOV = playerCamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (canZoom)
        
            HandleZoom();
        
    }
    private void HandleZoom()
    {
        if (Input.GetKeyDown(zoomKey))
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }
            zoomRoutine = StartCoroutine(ToggleZoom(true));
        }

        if (Input.GetKeyUp(zoomKey))
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }
            zoomRoutine = StartCoroutine(ToggleZoom(false));
        }

    }
    private IEnumerator ToggleZoom(bool isEnter)
    {
        float targetFOV =  isEnter ? zoomFOV : defaultFOV;
        float startingFOV = playerCamera.fieldOfView;
        float timeElapsed = 0;

        while (timeElapsed < timeToZoom)
        {
            playerCamera.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapsed / timeToZoom);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        playerCamera.fieldOfView = targetFOV;
        zoomRoutine = null;

    }
}
