using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    public Rigidbody2D playerRigidBody;
    public float jumpStrenght;
    public bool isPlayerAlive = true;
    public bool isOnGround = true;
    public Vector3 PlayerPosition;
    public LogicScript logicScript;

    private float bottomAxePosition = -3f;
    private float middleAxePosition = 6.7f;

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    public float bonusTimer = 0f;

    public bool switchBonus = false;
    public bool invincibilityBonus = false;

    public float score = 0f;
    public int scoreInt = 0;

    private Animator animator;

    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        isPlayerAlive = true;
        score = 0;
        scoreInt = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerAlive && invincibilityBonus == false && switchBonus == false)
        {
            transform.Rotate(_rotation * _speed * Time.deltaTime);
            _speed -= 5f * Time.deltaTime;
        }

        PlayerPosition = transform.position;

        //Permet au joueur de sauter
        if (isPlayerAlive)
        {
            score += 1 * Time.deltaTime;
            scoreInt = Mathf.RoundToInt(score);

            if (Input.GetKeyDown(KeyCode.Space) == true && isOnGround == true)
            {
                playerRigidBody.velocity = Vector2.up * jumpStrenght;

            }
            BonusActivated();

            score += 1 * Time.deltaTime;
            scoreInt = Mathf.RoundToInt(score);
        }
        else
        {
            bonusTimer = 0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Obstacle")) {

            if (invincibilityBonus == false)
            {
                isPlayerAlive = false;
                logicScript.Death();
            }
            else
            {
                Destroy(collision.gameObject);
                invincibilityBonus = false;
                animator.SetBool("isInvincibleBonusActivated", invincibilityBonus);

            }
        }
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            if (GameManager.instance.axe == 1)
            {
                transform.position = new Vector3(transform.position.x, bottomAxePosition, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, middleAxePosition, transform.position.z);
            }
        }

        if (other.CompareTag("SwitchBonus"))
        {
            
            switchBonus = true;
            transform.rotation = startRotation;
            animator.SetBool("isSwitchBonusActivated", switchBonus);
            bonusTimer = 0;
            Destroy(other.gameObject);
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.sonOs);

        }
        if (other.CompareTag("InvincibleBonus"))
        {

            invincibilityBonus = true;
            transform.rotation = startRotation;
            animator.SetBool("isInvincibleBonusActivated", invincibilityBonus);
            bonusTimer = 0;
            Destroy(other.gameObject);
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.sonOs);

        }
    }

    void BonusActivated()
    {
        bonusTimer += Time.deltaTime;

        float bonusOver = 10f;
        float switchUpStrenght = 30f;

        if (switchBonus == true && (bonusTimer < bonusOver))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && GameManager.instance.axe != 2 && isOnGround == true)
            {
                playerRigidBody.velocity = Vector2.up * switchUpStrenght;
                isOnGround = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && GameManager.instance.axe != 0 && isOnGround == true)
            {
                if (GameManager.instance.axe == 1)
                {
                    transform.position = new Vector3(transform.position.x, bottomAxePosition, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, middleAxePosition, transform.position.z);
                }
            }
        }

        else
        {
            switchBonus = false;
            animator.SetBool("isSwitchBonusActivated", switchBonus);
        }
    }
}
