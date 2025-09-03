using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    // Start is called before the first frame update
    public static LifeText instance; // 싱글턴 인스턴스 변수
    public Text life_text;

    public int life;

    void Start()
    {
        life = 5;
    }
    

    // Update is called once per frame
    void Update()
    {
        //life_text.text = life.ToString();
    }

    public void Dead()
    {
        life -= 1;
    }

    public void Heal()
    {
        life += 1;
    }
}