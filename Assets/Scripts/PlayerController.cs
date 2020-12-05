    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform target;

    [SerializeField] private GameObject bullet; 

    [SerializeField] private float ballVolume = 5f;



    void Start()
    {
        SetLinePosition(target.position);
    }

    void Update()
    {

        SetTransform();
        if (Input.GetMouseButtonDown(0))
        {
            FireBall();
        }
    }

    private void FireBall()
    {
        var bull = Instantiate(bullet, transform.position, Quaternion.identity);
        bull.transform.LookAt(target);
        bull.GetComponent<Rigidbody>().velocity = bull.transform.forward * 10f;
    }

    private void SetTransform()
    {
        var radius = ballVolume / 2;
        var bottomPos = new Vector3(transform.localPosition.x, transform.localPosition.y - radius, transform.localPosition.z);

        transform.localScale = new Vector3(ballVolume, ballVolume, ballVolume);
        transform.position = new Vector3(bottomPos.x, 0 + transform.position.y - bottomPos.y, bottomPos.z);
    }

    private void SetLinePosition(Vector3 targetPos)
    {
        Vector3[] points = new Vector3[] 
        {
            new Vector3(transform.position.x, 0.1f, transform.position.z),
            new Vector3(targetPos.x, 0.1f, targetPos.z)
        };
            
        line.SetPositions(points);
    }
}
