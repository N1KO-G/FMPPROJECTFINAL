using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickups : MonoBehaviour
{

    healthmanager Healthmanager;

    public void Start()
    {
        Healthmanager = FindAnyObjectByType<healthmanager>();
    }
 
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") && Healthmanager.health < 7)
    {
        other.gameObject.GetComponent<healthmanager>().healthregeneration(2);
        Destroy(this.gameObject);
    }
}
}
