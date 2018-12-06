using UnityEngine;

//적 클래스
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 10.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            tag = "Untagged";
            Destroy(gameObject, 0.5f);

            GameMgr.instance.audioSource.PlayOneShot(GameMgr.instance.enemyDead);
            GameMgr.instance.score += 0.5f;
        }
    }
}