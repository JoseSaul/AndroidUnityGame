using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject fbx;
    [SerializeField] protected GameObject body;
    protected int life;
    protected bool inmune = false;
    
    
    public Enemy()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void ReceiveDamage()
    {
        if (!inmune)
        {
            life--;
            if (life == 0)
            {
                Instantiate(fbx, body.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }  
        }
    }

    public virtual void Attack()
    {
        
    }

    public virtual void LeftAttack()
    {
        
    }

}
