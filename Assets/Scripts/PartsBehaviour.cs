using UnityEngine;

public class Parts : MonoBehaviour
{
    Rigidbody rb;
    private void AddRigidbody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
    }
    private void OnTransformParentChanged()
    {
        if (transform.parent == null)
        {
            //Debug.Log("it works false");
            switch (gameObject.tag)
            {
                case "LeftSide":
                    AddRigidbody();
                    rb.AddForce(Vector3.left * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.right * 2, ForceMode.Impulse);
                    break;
                case "RightSide":
                    AddRigidbody();
                    rb.AddForce(Vector3.right * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.left * 2, ForceMode.Impulse);
                    break;
                case "RearSide":
                    AddRigidbody();
                    rb.AddForce(Vector3.back * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.forward * 2, ForceMode.Impulse);
                    break;
                case "FrontSide":
                    AddRigidbody();
                    rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.back * 2, ForceMode.Impulse);
                    break;
                case "GoodBody":
                case "GoodEngine":
                    gameObject.tag = "GoodPart";
                    AddRigidbody();
                    rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.down * 3, ForceMode.Impulse);
                    break;
                case "BadBody":
                case "BadEngine":
                    AddRigidbody();
                    gameObject.tag = "BadPart";
                    rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
                    rb.AddTorque(Vector3.down * 5, ForceMode.Impulse);
                    break;
                default:
                    AddRigidbody();
                    rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
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
    void Start()
    {
    }
}
