    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Transform target;
    void Start()
    {
        //line = GetComponent<LineRenderer>();
        var diameter = gameObject.GetComponent<SphereCollider>().radius * 2;
        SetLinePosition(diameter);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z);
    }

    private void SetLinePosition(float diameter)
    {
        Vector3[] points = new Vector3[] 
        {
            new Vector3(transform.position.x, 0, transform.position.z),
            new Vector3(target.position.x, 0, target.position.z)
        };
            
        line.SetPositions(points);

        line.startWidth = diameter;
    }
}
