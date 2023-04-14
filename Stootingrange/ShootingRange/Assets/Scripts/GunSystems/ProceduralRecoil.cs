using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralRecoil : MonoBehaviour
{
    Vector3 currentRotatiom, targetRotation, targetPosition, currentPosition, intialGunPosition;
    public Transform cam;

    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;
    [SerializeField] float kickBackZ;
    public float snappiness, returnAmount;

    void Start()
    {
        intialGunPosition = transform.localPosition;
    }

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * returnAmount);
        currentRotatiom = Vector3.Slerp(currentRotatiom, targetRotation, Time.fixedDeltaTime * snappiness);
        transform.localRotation = Quaternion.Euler(currentRotatiom);
        cam.localRotation = Quaternion.Euler(currentRotatiom);
        back();
    }

    public void recoil()
    {
        targetPosition -= new Vector3(0, 0, kickBackZ);
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }

    private void back()
    {
        targetPosition = Vector3.Lerp(targetPosition, intialGunPosition, Time.deltaTime * returnAmount);
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.fixedDeltaTime * snappiness);
        transform.localPosition = currentPosition;
    }
}


