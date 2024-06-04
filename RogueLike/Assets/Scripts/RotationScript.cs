using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    InputManager inputManager;
    SpriteRenderer spriteRenderer;


    private void Start()
    {
        inputManager = GetComponentInParent<InputManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        MoveWeapon();
        RotateWeapon();
    }


    private void MoveWeapon()
    {
        if(inputManager.attackInput.y > 0)
        {
            transform.localPosition = new Vector2(inputManager.attackInput.x,
            inputManager.attackInput.y + 0.05f);
            if (inputManager.attackInput.x == 0) transform.localPosition = new Vector2(0.1f, inputManager.attackInput.y + 0.1f);
        }
        else
        {
            transform.localPosition = new Vector2(inputManager.attackInput.x,
            inputManager.attackInput.y);
        }
        
        if (inputManager.attackInput.y < 0 && inputManager.attackInput.x == 0) transform.localPosition = new Vector2(-0.1f, inputManager.attackInput.y);
    }

    private void RotateWeapon()
    {
        float angle = Mathf.Atan2(inputManager.attackInput.y, inputManager.attackInput.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if(inputManager.attackInput.x < 0) spriteRenderer.flipY = true;
        else spriteRenderer.flipY = false;

    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //private Vector3 target;
    //public Transform centerObject;
    //public Vector3 centerPosition;
    //public float orbitRadius = 0.001f;

    //[SerializeField] private Camera camera;
    //[SerializeField] private float initialAngle;


    //// Update is called once per frame
    //void Update()
    //{
    //    Vector2 finalCenterPosition = centerObject.position + centerPosition;
    //    target = camera.ScreenToWorldPoint(Input.mousePosition);

    //    float angleRadians = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
    //    float angleDegree = (180 / Mathf.PI) * angleRadians - initialAngle;
    //    transform.rotation = Quaternion.Euler(0f, 0f, angleDegree);

    //    Vector2 orbitPosition = new Vector2(
    //        finalCenterPosition.x + orbitRadius * Mathf.Cos(angleDegree * Mathf.Deg2Rad),
    //        finalCenterPosition.y + orbitRadius * Mathf.Sin(angleDegree * Mathf.Deg2Rad));

    //    transform.position = orbitPosition;
    //    Debug.Log(centerObject.position);
    //}



}
