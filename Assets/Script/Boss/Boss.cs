using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트 배열
    public GameObject Tornado;

    private Coroutine activationCoroutine;
    private GameObject previousObject;
    public Slider healthSlider;

    public GameObject LeftKick;
    public GameObject RightKick;
    
    private Animator animator;

    private Transform playerTransform; // 플레이어의 위치

    private float bossPositionX;
    private float playerPositionX;
    private int maxHp;
    private int hp;

    

    //private bool paze = false;

    public AudioClip soundClip;
    public AudioClip soundClip2;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 100;
        hp = maxHp;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // 모든 오브젝트를 비활성화합니다.
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }

        // 랜덤한 시간 간격으로 오브젝트 활성화 코루틴을 시작합니다.
        StartActivationCoroutine();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        healthSlider.value = (float)hp / maxHp;
        playerPositionX = playerTransform.position.x;
        bossPositionX = transform.position.x;
        if (hp >= 50)
        {
            if (audioSource.clip != soundClip)
            { audioSource.clip = soundClip;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        if (hp < 50)
        {
            //paze = true;
            animator.SetBool("change", true);
            StartCoroutine(SetBoolAfterDelaychange(2f));
            Tornado.SetActive(true);
            if (audioSource.clip != soundClip2)
            { audioSource.clip = soundClip2;
                audioSource.loop = true;
                audioSource.Play();
            }
        }

        if (hp <= 0)
        {
            SceneManager.LoadScene(7);
        }

       
       
    }

    private void StartActivationCoroutine()
    {
        // 랜덤한 대기 시간을 계산합니다.
        

        // 이전에 실행 중인 코루틴이 있다면 중지합니다.
        if (activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }

        // 지정된 대기 시간 후에 오브젝트 활성화 코루틴을 시작합니다.
        activationCoroutine = StartCoroutine(ActivateRandomObjectAfterDelay(10.0f));
    }

    private IEnumerator ActivateRandomObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 랜덤한 확률로 오브젝트를 선택하여 활성화합니다.
        GameObject selectedObject = GetRandomObjectWithProbability();
        if (selectedObject != null)
        {
            selectedObject.SetActive(true);
            
            animator.SetBool("Pattern", true);
            StartCoroutine(SetBoolAfterDelay(2f));
                    
            // 이전 오브젝트가 있다면 비활성화합니다.
            if (previousObject != null)
            {
                previousObject.SetActive(false);
            }

            // 현재 오브젝트를 이전 오브젝트로 설정합니다.
            previousObject = selectedObject;
           
        }

        // 다음 오브젝트가 활성화될 때 이전 오브젝트를 비활성화하도록 코루틴을 재시작합니다.
        StartActivationCoroutine();
    }

    private GameObject GetRandomObjectWithProbability()
    {
        // 오브젝트 활성화 확률을 계산합니다.
        float[] probabilities = new float[objectsToActivate.Length];
        float totalProbability = 0f;
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            probabilities[i] = Random.value;
            totalProbability += probabilities[i];
        }

        // 확률에 따라 오브젝트를 선택합니다.
        float randomValue = Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                return objectsToActivate[i];
            }
        }

        return null;
    }
    IEnumerator SetBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // delay 후에 값을 false로 변경
        animator.SetBool("Pattern", false);
    }

    IEnumerator SetBoolAfterDelayLkick(float delay)
    {
        yield return new WaitForSeconds(delay);

       
        
        animator.SetBool("leftkick", false);
    }

    IEnumerator SetBoolAfterDelayRkick(float delay)
    {
        yield return new WaitForSeconds(delay);

      
        animator.SetBool("rightkick", false);
    }

    IEnumerator SetBoolAfterDelaychange(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetBool("change", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playerPositionX <= bossPositionX && other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("leftkick", true);
            StartCoroutine(SetBoolAfterDelayLkick(1f));
        }

        if (playerPositionX > bossPositionX && other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("rightkick", true);
            StartCoroutine(SetBoolAfterDelayRkick(1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_P"))
        {
            hp -= 1;
            Debug.Log(hp);
        }
    }

    public void SetActiveLKick()
    {
        LeftKick.SetActive(true);
    }

    public void SetActiveLKickFalse()
    {
        LeftKick.SetActive(false);
    }

    public void SetActiveRKick()
    {
       RightKick.SetActive(true);
    }

    public void SetActiveRKickFalse()
    {
        RightKick.SetActive(false);
    }

}