using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] players;
	// Use this for initialization
	void Start ()
    {
        int i = PlayerPrefs.GetInt("Players", 2);
        spawn(i);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void spawn(int i)
    {
        switch (i)
        {
            case 2:
                Instantiate(players[0], new Vector3(-4, 2.5f, 0), Quaternion.identity);
                Instantiate(players[1], new Vector3(4, 2.5f, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(players[0], new Vector3(-4, 2.5f, 0), Quaternion.identity);
                Instantiate(players[1], new Vector3(0, 0, 0), Quaternion.identity);
                Instantiate(players[2], new Vector3(4, 2.5f, 0), Quaternion.identity);
                break;
            case 4:
                Instantiate(players[0], new Vector3(-8, -2.5f, 0), Quaternion.identity);
                Instantiate(players[1], new Vector3(-4, 2.5f, 0), Quaternion.identity);
                Instantiate(players[2], new Vector3(4, 2.5f, 0), Quaternion.identity);
                Instantiate(players[3], new Vector3(8, -2.5f, 0), Quaternion.identity);
                break;
        }
    }
}
