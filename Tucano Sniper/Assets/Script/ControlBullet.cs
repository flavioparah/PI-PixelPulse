using UnityEngine;

public class ControlBullet : MonoBehaviour
{
    [Header("Shoot Settings")]
    public float force = 10f;
    public float fireRate = 0.5f;   // Intervalo entre tiros (0.5 segundos)
    private float nextFireTime = 0f;

    [Header("References")]
    public Transform shootPoint;      // _Pos
    public GameObject bulletPrefab;

    [Header("Effects")]
    public ParticleSystem hitEffect;
    public ParticleSystem enemySmoke;
    public GameObject itemDrop;

    public static ControlBullet instance;

    void Awake()
    {
        instance = this;
    }

    // =========================================
    //   UNÇÃO PRINCIPAL DE TIRO COM COOLDOWN
    // =========================================
    public void Shoot()
    {
        // Ainda não pode atirar
        if (Time.time < nextFireTime)
            return;

        // Atualiza cooldown
        nextFireTime = Time.time + fireRate;

        // Instancia a bala
        GameObject bala = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // Aplica força
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        rb.AddForce(shootPoint.right * force, ForceMode2D.Impulse);

        // Destroi depois de 1 segundo
        Destroy(bala, 5f);
    }


    public void effectEnemy(Transform posEnemy)
    {
        Instantiate(enemySmoke, posEnemy.position, Quaternion.identity);
        Instantiate(itemDrop, posEnemy.position, Quaternion.identity);
    }
}
