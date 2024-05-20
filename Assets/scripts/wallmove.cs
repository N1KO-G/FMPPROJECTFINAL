using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallmove : MonoBehaviour
{

public float enemiesLeft = 0;
public float enemycount;
public float enemiescheck;

void Update () {
	GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		enemiesLeft = enemies.Length;
	
		if(enemiesLeft == enemiescheck)
		{
		    
            gameObject.SetActive(false);

		}
	}
}
