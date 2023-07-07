using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    private float zombieHealth = 10f;
    private float projectilePower = 5f;
    private float bulletSpeed = 10f;
    private float speed = 0.1f;

    private SpawnManager spawnMqanager;
    private GameObject playerClone;
    private Vector3 startPosition;
    private Vector3 vectorDistance;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        playerClone = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ZombieAI();
        if (zombieHealth <= 0)
        {
            DestroyZombie();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            vectorDistance = playerClone.transform.position - collision.transform.position;
            distance = vectorDistance.magnitude;
            zombieHealth -= projectilePower / distance;
            transform.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - collision.transform.position) * bulletSpeed, ForceMode.Impulse);
            Destroy(collision.gameObject);
        }
    }
    private void ZombieAI()
    {
        Vector3 targetPos = playerClone.transform.position;
        transform.LookAt(playerClone.transform);
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPos, Time.deltaTime* speed);
        transform.position = newPosition;
    }
    void DestroyZombie()
    {
        Destroy(transform.gameObject);
    }

}
