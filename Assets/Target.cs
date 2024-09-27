using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform missile;
    public float rotateSpeed = 5f;
    public float verticalSpeed = 10f;
    public float maxHeight = 300f;
    public float moveAwaySpeed = 5f;
    public Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (missile)
        {
            HandleInput();

            MoveAwayFromMissile();
        }

        
    }

    void HandleInput()
    {
        // Rotate around the missile with "A" and "D" keys
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(missile.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(missile.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        // Vertical movement with "W" and "S" keys
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, verticalSpeed * Time.deltaTime, 0);
        }

        // Clamp the height to the maximum limit
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, maxHeight), transform.position.z);
    }


    void MoveAwayFromMissile()
    {
        Vector3 moveDir = transform.position - missile.position;
        moveDir.y = 0;
        moveDir.Normalize();

        rb.velocity = moveDir * moveAwaySpeed * Time.deltaTime;
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
