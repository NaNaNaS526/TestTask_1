using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed;
    public float distance;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.forward * speed ;
        if (transform.position.z >= distance)
        {
            Destroy(gameObject);
        }
    }
}