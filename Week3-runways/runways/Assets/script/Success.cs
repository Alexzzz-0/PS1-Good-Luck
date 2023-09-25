using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Success : MonoBehaviour
{
    [SerializeField] private GameObject explode1;
    [SerializeField] private GameObject explode2;
    [SerializeField] private TextMeshProUGUI success;
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Success");
            Instantiate(explode1);
            Instantiate(explode2);

            success.text = "Welcome To The Stage!!!";
            success.DOFade(100f, 1f);
        }
    }

    
}
