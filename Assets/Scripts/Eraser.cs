using System.Collections;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private float _speed = 15.0f;
    private Rigidbody rd;
    private IEnumerator EraserSwipe()
    {
        while (true)
        {
            while (transform.position.x > -26)
            {
                Vector3 newPos = transform.position + Vector3.left * _speed * Time.fixedDeltaTime;
                rd.MovePosition(newPos);
                yield return new WaitForFixedUpdate();
                
            }
            while (transform.position.x < 26)
            {
                Vector3 newPos = transform.position + Vector3.right * _speed * Time.fixedDeltaTime;
                rd.MovePosition(newPos);
                yield return new WaitForFixedUpdate();
            }
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        StartCoroutine(EraserSwipe());

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
