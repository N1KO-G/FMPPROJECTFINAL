
using UnityEngine;

public class weaponpickup : MonoBehaviour
{
    weaponswitcher weaponswitcher;
    public GameObject weapon;
    public GameObject weaponholder;
    public AudioSource AudioSource;
    public AudioClip pickupsound;

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupsound, this.transform.position);
            weapon.transform.parent = weaponholder.transform;
            weapon.transform.localPosition = Vector2.zero;
            weapon.transform.localRotation = new Quaternion(0,0,0,0);
            Debug.Log(transform.position);
            Destroy(gameObject);
            
        }


    }
    
}
