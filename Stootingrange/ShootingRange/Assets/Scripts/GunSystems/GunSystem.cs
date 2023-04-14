using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GunSystem : MonoBehaviour
{
    // gun stats
    public float damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShots;


    //bools
    bool shooting, readyToshoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayhit;
    public LayerMask whatIsEnemy;

    public GameObject muzzleFlash, bulletHoleGraphic;
    public shake shakeCAmera;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToshoot = true;
    }
    private void Update()
    {
        GunInputs();
        text.SetText(bulletsLeft + "/ " + magazineSize);

    }
    private void GunInputs()
    {
        shooting = Input.GetKey(KeyCode.Mouse0);
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting= Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToshoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShots = bulletsPerTap;
            Shoot();
        }

    }

    private void Shoot()
    {
        readyToshoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);    

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if(Physics.Raycast(fpsCam.transform.position, direction, out rayhit, range, whatIsEnemy))
        {
            if (rayhit.collider.CompareTag("Enemy"))
                rayhit.collider.GetComponent<ShootingAi>().TakeDamage(damage);

        }
        shakeCAmera.Shake(camShakeDuration, camShakeMagnitude);

        Instantiate(bulletHoleGraphic, rayhit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShots--;
        Invoke("ResetShot", timeBetweenShooting);
    }
    private void ResetShot()
    {
        readyToshoot = true;
    }
    private void Reload()
    {
        reloading= true;
        Invoke("ReloadFinished", reloadTime);
        if (bulletsShots > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading=false;
    }
}

internal class ShootingAi
{
    internal void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

}