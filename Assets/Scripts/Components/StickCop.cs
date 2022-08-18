using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCop : MonoBehaviour
{
    [SerializeField] private float firstPower;
    [SerializeField] private Transform midPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Bot"))
        {
            Vector3 direction = midPoint.position - collision.transform.position;
            direction = Vector3.right * direction.x + Vector3.forward * direction.z;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-direction * firstPower);
        }
    }
}
