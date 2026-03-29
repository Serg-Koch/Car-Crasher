using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{

    private void OnMouseDown()
    {
        ParentDestroy();
    }
    private void ParentDestroy()
    {
        gameObject.transform.DetachChildren();
        Destroy(gameObject);
    }
    private void FloorDestroy()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.tag = "Inactive";
        }
        gameObject.transform.DetachChildren();
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Floor":
                FloorDestroy();
                break;
            case "BadPart":
                ParentDestroy();
                break;
            case "GoodPart":
                ParentDestroy();
                break;
            default:
                break;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
