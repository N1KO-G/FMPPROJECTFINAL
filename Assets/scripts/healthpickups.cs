using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickups : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip pickupsound;
    healthmanager Healthmanager;

    public void Start()
    {
        Healthmanager = FindAnyObjectByType<healthmanager>();
    }
 
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player") && Healthmanager.health < 7)
    {
        AudioSource.PlayClipAtPoint(pickupsound, this.transform.position);
        other.gameObject.GetComponent<healthmanager>().healthregeneration(2);
        Destroy(this.gameObject);
    }
}
}
