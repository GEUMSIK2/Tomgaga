using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerState;
    public Vector3 savedSpawnPoint;
    public PlayerDie playerDie;

    Spawn spawn;
    void Start()
    {
        playerDie = GetComponent<PlayerDie>();
        playerState = true;

        spawn = GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            playerState = false;
        }

        if (playerDie.pushZ == true)
        {
            spawn.ReSpawn();
        }

        if(spawn.completeRespawn == true)
        {

        }
    }

    IEnumerator coroutine;
    private void OnTriggerEnter(Collider other)
    {
        
        print(other.gameObject.name);
        if(other.gameObject.name == "TreasureChest")
        {
            print("�����");
            coroutine = dieDelay();
            if (coroutine != null)
            {
                StartCoroutine(coroutine);
            }
        }
    }

    IEnumerator dieDelay()
    {
        print("�ڷ�ƾ �����");
        yield return new WaitForSeconds(3f);
        coroutine = null;
        playerState = false;
    }
}


