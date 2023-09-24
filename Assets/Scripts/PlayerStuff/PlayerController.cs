using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float m_speed;

    [SerializeField]
    private Transform m_cameraTransform;

    [SerializeField]
    private PlayerAttackInfo[] m_attack;

    [SerializeField]
    private int m_health;

    [SerializeField]
    private HUDController m_HUD;
    #endregion

    #region Cached References
    private Animator cr_anim;
    private Renderer cr_renderer;
    #endregion

    #region Cached Components
    private Rigidbody cc_Rb;

    #endregion

    #region Private Variables
    //player direction
    private Vector2 p_velocity;

    private float p_frozenTime;

    //default color
    private Color p_defaultColor;

    private float p_curHealth;
    #endregion

    
    #region Intialization
    private void Awake()
    {
        p_velocity = Vector2.zero;
        cc_Rb = GetComponent<Rigidbody>();
        cr_anim = GetComponent<Animator>();
        cr_renderer = GetComponentInChildren<Renderer>();
        p_defaultColor = cr_renderer.material.color;

        p_frozenTime = 0;
        p_curHealth = m_health;
<<<<<<< HEAD
        
=======
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75

        for ( int i  = 0; i < m_attack.Length;  i++ )
        {
            PlayerAttackInfo attack = m_attack[i];
            attack.CD = 0;

            if ( attack.windupTime > attack.frozenTime)
            {
                Debug.LogError(attack.attackName + " has a windup time that is larger than the player is frozen for");
            }
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
<<<<<<< HEAD
        KillCountManager.singleton.Reset();
=======
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75
    }
    #endregion

    #region MainUpdates
    private void Update()
    {

        if ( p_frozenTime > 0 ) 
        {
            p_velocity = Vector3.zero;
            p_frozenTime -= Time.deltaTime;
            return;
        }
        else
        {
            p_frozenTime = 0;
        }

        for( int i = 0; i < m_attack.Length; i ++)
        {
            PlayerAttackInfo attack = m_attack[i];

<<<<<<< HEAD
            if ( attack.isReady() && attack.meetsKCReq(PlayerPrefs.GetInt("KC")))
=======
            if ( attack.isReady())
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75
            {
                if ( Input.GetButtonDown(attack.Button))
                {
                    p_frozenTime = attack.frozenTime;
                    DecreaseHealth(attack.healthCost);
                    StartCoroutine(UseAttack(attack));
                    break;
                }
            }
            else if ( attack.CD > 0)
            {
                attack.CD -= Time.deltaTime;
            }
        }

<<<<<<< HEAD
        m_HUD.UpdateKillCounter();
=======
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75

        //how hard the player presses buttons
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        //updating animation
        cr_anim.SetFloat("Speed", Mathf.Clamp01(forward + Mathf.Abs(right)));

        float movementTheshold = 0.3f;

        if ( forward > 0 && forward < movementTheshold)
        {
            forward = 0;
        }
        else if ( forward < 0 && forward > -movementTheshold)
        {
            forward = 0;
        }
        if (right > 0 && right < movementTheshold)
        {
            right = 0;
        }
        else if (right < 0 && right > -movementTheshold)
        {
            right = 0;
        }
        
        p_velocity.Set(right, forward);
    }

    private void FixedUpdate()
    {
        //update player position
        cc_Rb.MovePosition(cc_Rb.position + m_speed * Time.fixedDeltaTime * transform.forward * p_velocity.magnitude);

        //update camera position
        cc_Rb.angularVelocity = Vector3.zero;

        if ( p_velocity.sqrMagnitude > 0 ) 
        { 
            float camRotAngle = Mathf.Deg2Rad * Vector2.SignedAngle(Vector2.up, p_velocity);
            Vector3 camForward = m_cameraTransform.forward;
            Vector3 newRot = new Vector3(Mathf.Cos(camRotAngle) * camForward.x - Mathf.Sin(camRotAngle) * camForward.z, 0,
                Mathf.Cos(camRotAngle) * camForward.z + Mathf.Sin(camRotAngle) * camForward.x);

            float theta = Vector3.SignedAngle(transform.forward, newRot, Vector3.up );
            cc_Rb.rotation = Quaternion.Slerp(cc_Rb.rotation, cc_Rb.rotation * Quaternion.Euler(0, theta, 0), 0.2f);
        }

    }

    #endregion

    #region Health Functions
    public void DecreaseHealth(float amount)
    {
        p_curHealth -= amount;
        m_HUD.UpdateHealth(1.0f * p_curHealth / m_health);
        if ( p_curHealth <= 0 )
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    public void IncreaseHealth(int amount) 
    {
        p_curHealth += amount;
        if ( p_curHealth > m_health)
        {
            p_curHealth = m_health;
        }
        m_HUD.UpdateHealth(1.0f * p_curHealth / m_health);
    }
    #endregion

    #region Attack Methods
    
    private IEnumerator UseAttack(PlayerAttackInfo attack)
    {

        cc_Rb.rotation = Quaternion.Euler(0, m_cameraTransform.eulerAngles.y, 0);
        cr_anim.SetTrigger(attack.triggerName);
        IEnumerator toColor = ChangeColor(attack.abilityColor, 10);
        StartCoroutine(toColor);
        yield return new WaitForSeconds(attack.windupTime);

        Vector3 offset = transform.forward* attack.offset.z + transform.right *attack.offset.x + transform.up * attack.offset.y;
        GameObject go = Instantiate(attack.abilityGO, transform.position + offset, cc_Rb.rotation);
        go.GetComponent<Ability>().Use(transform.position + offset);


        StopCoroutine(toColor);
        StartCoroutine(ChangeColor(p_defaultColor, 50));
        yield return new WaitForSeconds(attack.CD);

        attack.ResetCD();
    }

    #endregion

    #region Miscellaenous Methods
    private IEnumerator ChangeColor(Color newColor, float speed)
    {
        Color currrentColor = cr_renderer.material.color;
        while ( currrentColor != newColor)
        {
            currrentColor = Color.Lerp(currrentColor, newColor, speed / 100);
            cr_renderer.material.color = currrentColor;
            yield return null;

        }
    }
    #endregion

    #region Collision Methods
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("HealthPill"))
        {
            IncreaseHealth(other.GetComponent<HealthPill>().healthGain);
            Destroy(other.gameObject);
        }
    }
    #endregion
}
