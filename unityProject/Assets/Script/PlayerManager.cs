using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed,skor=0;
    

    bool dead = false;

    Transform muzzle;
    public Transform bullet;

    //bool mouseIsNotOverUI;

    //Healtbarý scripte baðlamak için
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //Namlu yönü sabitlemek
        muzzle = transform.GetChild(1);

        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIdead();
    }
    public void GetSkor(float puan)
    {
        skor = skor + puan;
        DataManager.Instance.Skor+=puan;
        
    }

    void AmIdead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }
    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet= Instantiate(bullet,muzzle.position,Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }
}
