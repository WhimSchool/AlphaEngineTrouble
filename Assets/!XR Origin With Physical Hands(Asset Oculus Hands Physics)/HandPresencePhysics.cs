using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Renderer nonPhysicalhands;
    public float showNonPhysicalHandDistance = 0.05f;
    private Collider[] handCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handCollider = GetComponentsInChildren<Collider>();
    }

    public void EnableColliders()
    {
        foreach (var item in handCollider)
            item.enabled = true;
    }

    public void EnableCollidersDelay(float delay)
    {
        Invoke("EnableColliders", delay);
    }

    public void DesableColliders()
    {
        foreach (var item in handCollider)
            item.enabled = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > showNonPhysicalHandDistance)
        {
            nonPhysicalhands.enabled = true;
        }
        else
            nonPhysicalhands.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        //rotation
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
