using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.forward * verticalInput * speed * Time.deltaTime;
        Vector3 turnMovement = Vector3.right * horizontalInput * speed * Time.deltaTime;

        ApplyMovement(movement);
        TurnMovement(turnMovement);
    }

    private void ApplyMovement(Vector3 movement)
    {
        transform.Translate(movement);
    }
    private void TurnMovement(Vector3 turnMovement)
    {
        transform.Translate(turnMovement);
    }


}

