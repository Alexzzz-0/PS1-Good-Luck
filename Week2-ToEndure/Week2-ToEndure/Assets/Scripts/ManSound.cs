using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManSound : MonoBehaviour
{
    [SerializeField] private AudioSource hit;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("ball hit the man");
            hit.Play();
        }
    }
}
