using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public static EnemyBody instance;
    public int move = 5;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision!=null)
        {
            move = - move;
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            UiManager.instance.GameOverFun();
        }
        
    }

}
