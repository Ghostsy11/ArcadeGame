using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public int maxAmmo = 30;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Camera fpsCamp;
    public ParticleSystem muzzelflash;
    public GameObject impactEffect;
    public float impactForce;
    private float nextTimeTofire = 0f;
    public Animator animator;
    private new AudioSource audio;
    public TextMeshProUGUI text;

    //private AudioSource empty;


    //public ProceduralRecoil recoil;
    //---Recoil--//
    //public Proceduralrecoill recoil;
    //Vector3 currentRotatiom, targetRotation, targetPosition, currentPosition, intialGunPosition;
    //public Transform cam;
    //[SerializeField] float recoilX;
    //[SerializeField] float recoilY;
    //[SerializeField] float recoilZ;
    //[SerializeField] float kickBackZ;
    //public float snappiness, returnAmount;
    private void Start()
    {
        currentAmmo = maxAmmo;
        audio = GetComponent<AudioSource>();


        //recoil = GetComponent<Proceduralrecoill>();
        //intialGunPosition = transform.localPosition; 
    }

    private void OnEnable()
    {
        isReloading= false;
        animator.SetBool("Reloading", false);
    }

    private void Update()
    {

        text.SetText(currentAmmo + "/" + maxAmmo);

        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        { 

            StartCoroutine(Reload());
            return; 
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeTofire)
        {   
             nextTimeTofire = Time.time + 1f / fireRate;
             Shoot();
        }


        //targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * returnAmount);
        //currentRotatiom = Vector3.Slerp(currentRotatiom, targetRotation, Time.fixedDeltaTime * snappiness);
        //transform.localRotation = Quaternion.Euler(currentRotatiom);
        //fpsCamp.transform.localRotation= Quaternion.Euler(currentRotatiom);
        //cam.localRotation = Quaternion.Euler(currentRotatiom);
        //back();
    }

    IEnumerator Reload()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            isReloading = true;
            audio.Play();
            animator.SetBool("Reloading", true);
            yield return new WaitForSeconds(reloadTime - .25f);
            animator.SetBool("Reloading", false);
            yield return new WaitForSeconds(.25f);
            currentAmmo = maxAmmo;
            isReloading = false;
        }

    }
    private void Shoot ()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    audio.Play();
        //}

        muzzelflash.Play();
        currentAmmo--;

       // recoil.recoil();
        //recoil();
        RaycastHit hit;
        if (Physics.Raycast(fpsCamp.transform.position, fpsCamp.transform.forward, out hit, range))
        {
            DamageTarget target = hit.transform.GetComponent<DamageTarget>();
            if (target != null)
            {
                target.TakeDamgae(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }
    //public void recoil()
    //{
    //    targetPosition -= new Vector3(0, 0, kickBackZ);
    //    targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    //}
    //private void back()
    //{
    //    targetPosition = Vector3.Lerp(targetPosition, intialGunPosition, Time.deltaTime * returnAmount);
    //    currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.fixedDeltaTime * snappiness);
    //    transform.localPosition = currentPosition;
    //}

    private void FireRates()
    {

    }
}
