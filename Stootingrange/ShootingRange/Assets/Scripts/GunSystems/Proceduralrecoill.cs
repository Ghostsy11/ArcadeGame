using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceduralrecoill : MonoBehaviour
{
    Vector3 currentRotation;
    Vector3 targetRotation;


    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;
    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;

    void Start()
    {

    }

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void recoilFire()
    {
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));

    }

}