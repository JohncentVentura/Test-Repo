using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 160f;
    private Transform rotateAround;
    private float rotateDistance;

    private Vector3 vectorToTarget;

    void Update()
    {
        //Rotate ship (TIME LIMIT MAKES ME DIDN'T COMPLETE THE ROTATION)
        if (rotateAround)
        {
            vectorToTarget = rotateAround.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }

        //Move to a planet  
        if (rotateAround && rotateDistance > 1.5f)
        {
            rotateDistance = Vector3.Distance(transform.position, rotateAround.position);
            transform.position = Vector3.MoveTowards(transform.position, rotateAround.position, rotateDistance * Time.deltaTime);
        }
        //Rotate around a planet
        else if (rotateAround && rotateDistance < 1.5f)
        {
            rotateDistance = Vector3.Distance(transform.position, rotateAround.position);
            transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            //transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

        //Change planet to Rotate Around
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
        {
            if (transform.CompareTag("Ship0"))
            {
                ChangePlanet();
            }
        }
        else if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.W))
        {
            if (transform.CompareTag("Ship1"))
            {
                ChangePlanet();
            }
        }
        else if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.E))
        {
            if (transform.CompareTag("Ship2"))
            {
                ChangePlanet();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            ChangePlanet();
        }

    }

    private void ChangePlanet()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.gameObject.name);
            rotateAround = null;
            rotateAround = hit.collider.transform;
            rotateDistance = Vector3.Distance(transform.position, rotateAround.position);
        }
    }
}
