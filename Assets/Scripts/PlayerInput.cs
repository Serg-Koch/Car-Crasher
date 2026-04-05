using UnityEngine;
using System;
public class PlayerInput : MonoBehaviour
{
    //public static event Action <bool> LMBClick;
    //public bool IsLMBClicked {get; private set;} = false;
    public static event Action LMBClickObject;
    public static event Action LMBClickEmpty;
    private LayerMask layerMask;
    private Camera _mainCamera;

    private void LClick(Vector3 cursorPosition)
    {
        Ray ray = _mainCamera.ScreenPointToRay(cursorPosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, layerMask))
        {
            if(hit.collider.TryGetComponent<ObjectDestroy>(out var obj))
            {
                //Debug.Log("Works!");
                obj.MouseDestroy();
                LMBClickObject?.Invoke();
            }
        }
        else
        {
            LMBClickEmpty?.Invoke();
            //Debug.Log("NOT Works!");
        }

    }
    void Awake()
    {
        _mainCamera = Camera.main;
        layerMask = LayerMask.GetMask("Cars");
    }

    private void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
            LClick(Input.mousePosition);
        }
        
    }
}
