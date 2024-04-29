using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmove : MonoBehaviour
{

public float enemiesLeft = 0;
public float enemycount;

void Update () {
	GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		enemiesLeft = enemies.Length;
	
		if(enemiesLeft == 0)
		{
		    
            gameObject.SetActive(false);

		}
	}
}
