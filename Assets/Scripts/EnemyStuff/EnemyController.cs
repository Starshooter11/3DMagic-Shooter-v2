using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float m_maxHealth;

    [SerializeField]
    private float m_speed;

    [SerializeField]
    private float m_damage;

    [SerializeField]
    private ParticleSystem m_deathEvent;

    [SerializeField]
    private float m_healthPillDropRate;

    [SerializeField]
    private GameObject m_healthPill;

    [SerializeField]
    private int m_score;
    #endregion

    #region Private Variables
    private float p_curHealth;
    #endregion

    #region Cached Components
    private Rigidbody cc_rb;
    #endregion

    #region Cached References
    private Transform cr_player;
    #endregion

    #region Intialization
    private void Awake()
    {
        p_curHealth = m_maxHealth;

        cc_rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        cr_player = FindObjectOfType<PlayerController>().transform;

    }
    #endregion

    #region Main Updates
    private void FixedUpdate()
    {
        Vector3 direc = cr_player.position - transform.position;
        direc.Normalize();
        cc_rb.MovePosition(cc_rb.position + direc * m_speed*Time.fixedDeltaTime);
    }
    #endregion

    #region Collisions
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DecreaseHealth(m_damage);    
        }
    }
    #endregion

    #region Health Function

    public void DecreaseHealth(float amount)
    {
        p_curHealth -= amount;
        if (p_curHealth <= 0)
        {
            ScoreManager.singleton.IncreaseScore(m_score);
            if ( Random.value < m_healthPillDropRate)
            {
                Instantiate(m_healthPill, transform.position, Quaternion.identity);
            }
            Instantiate(m_deathEvent, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
    #endregion
}
