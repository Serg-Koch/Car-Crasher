using UnityEngine;
using System;

public class ObjectDestroy : MonoBehaviour
{
    public static event Action<GameObject> DestroyFromMouse;
    public static event Action DestroyFromFloor;
    public static event Action DestroyFromGoodCar;
    public static event Action DestroyFromBadCar;
    private void MouseDestroy()
    {
        gameObject.transform.DetachChildren();
        DestroyFromMouse?.Invoke(gameObject);
        Destroy(gameObject);
    }
    private void FloorDestroy()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.tag = "Inactive";
        }
        gameObject.transform.DetachChildren();
        DestroyFromFloor?.Invoke();
        Destroy(gameObject);
    }
    private void GoodCarDestroy()
    {
        gameObject.transform.DetachChildren();
        DestroyFromGoodCar?.Invoke();
        Destroy(gameObject);
    }
    private void BadCarDestroy()
    {
        gameObject.transform.DetachChildren();
        //DestroyFromBadCar?.Invoke();
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        MouseDestroy();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Floor":
                FloorDestroy();
                break;
            case "BadPart":
                BadCarDestroy();
                break;
            case "GoodPart":
                GoodCarDestroy();
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
