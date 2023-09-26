using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    [SerializeField] Vehicle m_VehicleController;

    public void OnMove(InputAction.CallbackContext context)
    {
        m_VehicleController.SetDirection(context.ReadValue<Vector2>()); 
    }
}
