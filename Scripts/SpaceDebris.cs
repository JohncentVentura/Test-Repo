using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDebris : MonoBehaviour
{
    private Vector3 randomVector;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        randomVector = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50));
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, randomVector, speed * Time.deltaTime);

        if (transform.position == randomVector)
        {
            randomVector = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50));
        }
    }
}
