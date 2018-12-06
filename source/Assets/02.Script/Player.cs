using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//플레이어 클래스
public class Player : MonoBehaviour
{
    [Header("Self")]
    public float speed = 10.0f;
    public Transform childBird;
    public SpriteRenderer chargeBar;

    [Header("Bullet")]
    public GameObject bullet;
    public float bulletSpeed = 50.0f;
    public float chargeSpeed = 0.1f;
    bool hasCharge;
    float bulletEnergy;

    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        ToInsideCamera();
    }

    void Update()
    {
        //이동
#if UNITY_EDITOR
        float v = Input.GetAxis("Vertical");
#else
        float v = CrossPlatformInputManager.GetAxis("Vertical");
#endif
        if (v != 0.0f)
            Move(v);

        //공격
        if (Input.GetKeyDown(KeyCode.Space))
            FireCharge();
        else if (Input.GetKeyUp(KeyCode.Space))
            Fire();

        //챠지
        if (hasCharge)
            bulletEnergy = Mathf.Clamp01(bulletEnergy + chargeSpeed);

        chargeBar.size = new Vector2(bulletEnergy, 0.3f);

        //점수보상
        transform.localScale = new Vector3(0.5f + (GameMgr.instance.score / 100), 0.5f + (GameMgr.instance.score / 100), 1.0f);
    }

    public void Move(float axis)
    {
        transform.Translate(Vector2.up * (axis * speed * Time.deltaTime));
        ToInsideCamera();
    }

    public void FireCharge()
    {
        hasCharge = true;
    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(bullet, childBird.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().speed = bulletSpeed;
        newBullet.transform.localScale = new Vector3(bulletEnergy, bulletEnergy, 1.0f);

        if (bulletEnergy == 1.0f)
        {
            newBullet.GetComponent<ParticleSystem>().Play();
            GameMgr.instance.audioSource.PlayOneShot(GameMgr.instance.bigBulletShoot);
        }
        else
            GameMgr.instance.audioSource.PlayOneShot(GameMgr.instance.bulletShoot);

        bulletEnergy = 0.0f;
        hasCharge = false;
    }

    void ToInsideCamera()
    {
        Vector3 view = mainCamera.WorldToViewportPoint(transform.position);
        view.x = 0.1f;
        view.y = Mathf.Clamp01(view.y);
        transform.position = mainCamera.ViewportToWorldPoint(view);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameMgr.instance.LoadGameEnd(false);
            Destroy(gameObject);
        }
    }
}