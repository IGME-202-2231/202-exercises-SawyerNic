using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    [SerializeField] Vehicle m_VehicleController;

    Vector2 direction;

    public void OnMove(InputAction.CallbackContext context)
    {
        m_VehicleController.SetDirection(context.ReadValue<Vector2>()); 
        
    }

    
}
