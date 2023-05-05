using Damien.ProjectileSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    public ProjectileAgent Agent;
    public PlayerInput PlayerInput;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.actions["Shoot"].performed += OnLeftClick;
    }

    private void OnLeftClick(InputAction.CallbackContext obj)
    {
        Agent.CreateProjectile();
    }
}
