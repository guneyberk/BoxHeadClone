using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private SpawnManager spawnManager;


    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            ActivatePistol();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) ) 
        {
            ActivateMachinePistol();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            ActivateLauncher();
        }
    }

    void ActivatePistol()
    {
        foreach (var obj in spawnManager.guns)
        {
            obj.gameObject.SetActive(false);
        }
        spawnManager.guns[0].SetActive(!spawnManager.guns[0].activeSelf);
    }
    void ActivateMachinePistol()
    {
        foreach (var obj in spawnManager.guns)
        {
            obj.gameObject.SetActive(false);
        }
        spawnManager.guns[1].SetActive(!spawnManager.guns[1].activeSelf);
    }
    void ActivateLauncher()
    {
        foreach (var obj in spawnManager.guns)
        {
            obj.gameObject.SetActive(false);
        }
        spawnManager.guns[2].SetActive(!spawnManager.guns[2].activeSelf);
    }
}
