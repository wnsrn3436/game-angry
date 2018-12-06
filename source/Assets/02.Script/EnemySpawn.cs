using System.Collections;
using UnityEngine;

//적 생성 클래스
public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 1.0f) - GameMgr.instance.score / 150);

            Vector3 view = new Vector3(1.0f, Random.Range(0.0f, 1.0f), 0.0f);
            view = mainCamera.ViewportToWorldPoint(view);

            GameObject newEnemy = Instantiate(enemy, enemy.transform.position, enemy.transform.rotation);
            newEnemy.transform.position = new Vector2(view.x, view.y);
        }
    }
}