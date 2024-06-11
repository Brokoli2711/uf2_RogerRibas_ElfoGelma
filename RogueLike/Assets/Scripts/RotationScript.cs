using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    InputManager inputManager;
    SpriteRenderer spriteRenderer;
    public bool flip;
    public float offset;

    private void Update()
    {
        MoveWeapon();
        RotateWeapon();
    }


    private void MoveWeapon()
    {
        float posX = 0;
        float posY = 0;
        if (inputManager.attackInput.x > 0)
        {
            posX = 0.1f;
        }
        else if (inputManager.attackInput.x < 0)
        {
            posX = -0.1f;
            posY = 0.1f;
        }
        else if (inputManager.attackInput.y > 0)
        {
            posY = 0.2f;
            posX = -0.05f;
        }
        else if (inputManager.attackInput.y < 0)
        {
            posY = -0.05f;
            posX = 0.05f;
        }

        transform.localPosition = new Vector2(posX, posY);

    }

    private void RotateWeapon()
    {

        if (inputManager.attackInput.x < 0)
        {
            spriteRenderer.flipY = true;
            spriteRenderer.flipX = true;
        }
        else if (inputManager.attackInput.y < 0)
        {
            spriteRenderer.flipY = true;
            spriteRenderer.flipX = false;
        }
        else if (inputManager.attackInput.y > 0)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = false;
        }
        else
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }



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
