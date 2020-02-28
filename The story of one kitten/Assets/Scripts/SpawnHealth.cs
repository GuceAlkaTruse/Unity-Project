using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    [SerializeField] private GameObject coins;

    private float randomX;
    private Vector2 whereToSpawn;

     void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            StartCoroutine(RespawnCoin(collider.gameObject));
        }
    }
    private IEnumerator RespawnCoin(GameObject obj)
    {
        randomX = Random.Range(-10f, 10f);
        whereToSpawn = new Vector2(randomX, transform.position.y);
        Instantiate(coins, whereToSpawn, Quaternion.identity);
        Destroy(obj);
        yield return new WaitForSeconds(2f);
    }
}
