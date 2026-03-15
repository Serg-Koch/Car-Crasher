using UnityEngine;

public class Parts : MonoBehaviour
{
    Rigidbody rb;
    void OnTransformParentChanged()
    {
        if (transform.parent == null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            switch (gameObject.tag)
            {
                case "LeftSide":
                    rb.AddForce(Vector3.left * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.right * 2, ForceMode.Impulse);
                    break;
                case "RightSide":
                    rb.AddForce(Vector3.right * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.left * 2, ForceMode.Impulse);
                    break;
                case "RearSide":
                    rb.AddForce(Vector3.back * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.forward * 2, ForceMode.Impulse);
                    break;
                case "FrontSide":
                    rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.back * 2, ForceMode.Impulse);
                    break;
                case "Good":
                    gameObject.tag = "GoodPart";
                    rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.down * 3, ForceMode.Impulse);
                    break;
                case "Bad":
                    gameObject.tag = "BadPart";
                    rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.down * 5, ForceMode.Impulse);
                    break;
                default:
                    rb.AddTorque(Vector3.down * 2, ForceMode.Impulse);
                    return;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            gameObject.tag = "Inactive";
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Floor")
        {
            gameObject.tag = "Inactive";
        }
    }*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
