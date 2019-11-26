using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoints = 2;
    private int _hitPoints;
    public bool indestructible = false;
    public ParticleSystem destroyEffect;
    public ParticleSystem hitEffect;
    public int Score = 0;
    private SpriteRenderer spriteRenderer;
    public Bonus bonus = null;
    private Bonus _bonus = null;
    public GameObject _destroyEffect;
    public GameObject _hitEffect;

    void Start()
    {
        _hitPoints = hitPoints;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = BrickManager.Instance.Sprites[hitPoints - 1];
    }

    public void Reset()
    {
        _hitPoints = hitPoints;
        spriteRenderer.sprite = BrickManager.Instance.Sprites[hitPoints - 1];
        gameObject.SetActive(true);
        if (_bonus != null)
            _bonus.gameObject.SetActive(false);
        Destroy(_destroyEffect);
        Destroy(_hitEffect);
    }



    private void Hit(int demage)
    {
       

        _hitPoints -= demage;
        if (_hitPoints <= 0)
        {
            if (bonus != null && _bonus == null)
            {
                Vector3 position = gameObject.transform.position;
                _bonus = Instantiate(bonus, position, Quaternion.identity);
                _bonus.gameObject.transform.parent = gameObject.GetComponentInParent<Board>().gameObject.transform;
                
            }
            else if(_bonus != null)
            {
                Vector3 position = gameObject.transform.position;
                _bonus.transform.position = position;
                _bonus.gameObject.SetActive(true);
                _bonus.Move();

            }
            GameManager.Instance.TotalScore += Score;
          
            ShowDestroyEffect(destroyEffect);
            gameObject.SetActive(false);
        }
        else
        {
            ShowHitEffect(hitEffect);
            if (_hitPoints - 1 >= 0)
            {
                spriteRenderer.sprite = BrickManager.Instance.Sprites[_hitPoints - 1];

            }
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Bull"))
        {
            if (!indestructible)
            {
              
                Hit(1);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball" )
        {
    
            if (!indestructible)
            {
                Ball obj = coll.gameObject.GetComponent<Ball>();
                if(obj)
                    Hit(obj._demage);
            }
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }



    private void ShowHitEffect(ParticleSystem particleEffect)
    {

        Vector3 brickPosition = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(brickPosition.x, brickPosition.y, brickPosition.z + 2f);
        _hitEffect = Instantiate(particleEffect.gameObject, spawnPosition, Quaternion.identity);
        MainModule mm = _hitEffect.GetComponent<ParticleSystem>().main;
        mm.startColor = spriteRenderer.color;
        _hitEffect.GetComponent<ParticleSystem>().Play();
        Destroy(_hitEffect, particleEffect.main.startLifetime.constant); 
    }
    private void ShowDestroyEffect(ParticleSystem particleEffect)
    {

        Vector3 brickPosition = gameObject.transform.position;
        Vector3 spawnPosition = new Vector3(brickPosition.x, brickPosition.y, brickPosition.z + 2f);
        _destroyEffect = Instantiate(particleEffect.gameObject, spawnPosition, Quaternion.identity);
        MainModule mm = _destroyEffect.GetComponent<ParticleSystem>().main;
        mm.startColor = spriteRenderer.color;
        _destroyEffect.GetComponent<ParticleSystem>().Play();
        Destroy(_destroyEffect, particleEffect.main.startLifetime.constant);
    }
}
