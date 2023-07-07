using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private SpawnManager spawnManager;

    private Transform target;
    private float lerpSpeed = 10f;
    private float cameraOffset = 30f;
    // Update is called once per frame
    private void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
    }
    void FixedUpdate()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        Vector3 targetPos = spawnManager.playerClone.transform.position;
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.y = cameraOffset;
        Camera.main.transform.position = Vector3.Lerp(cameraPos, targetPos, lerpSpeed * Time.deltaTime);
    }
}
