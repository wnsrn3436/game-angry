using UnityEngine;

//플레이어의 총알 클래스
public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * 1000.0f * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.localScale.x != 1.0f)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                Destroy(gameObject);
        }
    }
}