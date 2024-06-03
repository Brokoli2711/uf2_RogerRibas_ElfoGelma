using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private Transform parent;
    InputManager inputManager;
    SpriteRenderer spriteRenderer;


    private void Start()
    {
        inputManager = GetComponentInParent<InputManager>();
        parent = GetComponentInParent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        MoveWeapon();
        RotateWeapon();
    }


    private void MoveWeapon()
    {
        transform.localPosition = new Vector2(inputManager.attackInput.x, 
            inputManager.attackInput.y);
    }

    private void RotateWeapon()
    {
        float angle = Mathf.Atan2(inputManager.attackInput.y, inputManager.attackInput.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
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
