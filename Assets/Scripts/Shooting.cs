using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public GameObject casing;

    [SerializeField] float explosionForce = 10f;

    private bool isReloadTime=false;
    private bool isReadyToShoot = true;

    private List<GameObject> newProjectile = new List<GameObject>();
    private List<GameObject> newCasings = new List<GameObject>();

    private float fireRate = 0.3f;

    private int ammoCount = 7;
    private float reloadTime = 5f;

    int deleteGameObjectIndex = 0;
    int listGameObjectIndex = 0;
    void Start()
    {

    }

    void Update()
    {
        SpawnProjectile();
    }

    void SpawnProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount > 0 && isReadyToShoot)
        {
            StartCoroutine(Shoot());
            
        }
        else if(ammoCount < 0 && !isReloadTime)
        {
            isReloadTime = true;
            StartCoroutine(ReloadTime());
        }

    }
    
    IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(reloadTime);
        ammoCount = 7;
        isReloadTime = false;
    }

    IEnumerator Shoot()
    {
        isReadyToShoot = false;
        newProjectile.Add(Instantiate(projectile, transform.position, transform.rotation));
        newCasings.Add(Instantiate(casing, transform.position, casing.transform.rotation));
        newProjectile[listGameObjectIndex].GetComponent<Rigidbody>().AddForce(transform.forward * explosionForce, ForceMode.Impulse);
        newCasings[listGameObjectIndex].GetComponent<Rigidbody>().AddForce(transform.right * Random.Range(3, 5), ForceMode.Impulse);
        listGameObjectIndex++;
        ammoCount--;
        yield return new WaitForSeconds(fireRate);
        isReadyToShoot = true;
        Invoke("DestroyCasings", 5f);

    }

    void DestroyCasings()
    {
        Destroy(newProjectile[deleteGameObjectIndex]);
        Destroy(newCasings[deleteGameObjectIndex]);
        deleteGameObjectIndex++;
    }

}
