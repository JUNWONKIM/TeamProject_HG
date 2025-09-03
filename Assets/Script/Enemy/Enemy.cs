using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3f;

    public float pushForce = 0.5f;
    public float pushForce2 = 0.1f;
    public float pushDuration = 0.5f;
    public float pushDuration2 = 0.2f;
    public bool isPushing = false;


    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;

    public int hp = 3;

    public GameObject itemDropPrefab;

    public AudioClip monsterDieClip; 
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

     
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("checkDie") == false)
        {
            Move();
            LookAt();
        }
    }



    void Move()
    {
        if (isPushing == false) //�÷��̾�� �浹 Ȯ��
        {
            Vector2 direction = player.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            //�÷��̾�� �ٰ���

        }
   }

    void LookAt() //�ִϸ��̼�
    {
        Vector2 direction = player.position - transform.position;
        direction.y = 0;

        if (direction.x > 0)
        {
            animator.SetBool("moveLeft", false);
        }
        else
        {
            animator.SetBool("moveLeft", true);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾�� �浹 ��
        {
            isPushing = true; 
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position; //�÷��̾� �浹 ���� ����.
                StartCoroutine(AddForceCoroutine(rb, pushDirection.normalized)); //�浹 �� �о
            }
        }
        else if (collision.gameObject.CompareTag("Enemy")) //���� �浹 ��
        {
            isPushing = true;
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position; //������ �浹 ���� ����
                StartCoroutine(AddForceCoroutine2(rb, pushDirection.normalized)); //�浹 �� �о
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_P")) //�÷��̾� �Ѿ˰� �浹 ��
        {
            hp -= 1;
            if (hp == 0) //������
            {
                Instantiate(itemDropPrefab, transform.position, Quaternion.identity); //������ ���
                animator.SetBool("checkDie", true);
                audioSource.clip = monsterDieClip; //�״� �Ҹ�
                audioSource.Play();
                Destroy(gameObject,0.15f);
            }
        }

    }
    IEnumerator AddForceCoroutine(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // �ڽ��� �о
        yield return new WaitForSeconds(pushDuration); // ���� �ð� ���
        enemyRb.linearVelocity = Vector2.zero; //�ڽ��� �ӵ� �ʱ�ȭ
        isPushing = false;
    }

    IEnumerator AddForceCoroutine2(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce2, ForceMode2D.Impulse); // �ڽ��� �о
        yield return new WaitForSeconds(pushDuration2); // ���� �ð� ���
        enemyRb.linearVelocity = Vector2.zero; //�ڽ��� �ӵ� �ʱ�ȭ
        isPushing = false;
    }
}
