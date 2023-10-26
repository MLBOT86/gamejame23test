using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySistem : MonoBehaviour
{
    //на ключе/кнопке должен быть коллайдер c триггером  и тег "Key",на двери "Door"
   
    public GameObject keyText;
    float AllKeys;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            AllKeys++;
            Destroy(collision.gameObject);
        }
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door")&&AllKeys>0)
        {
            AllKeys--;
            Destroy(collision.gameObject);
        }
    }
    private void Update()
    {
        if (AllKeys > 0)
        {
            keyText.SetActive(true);
        }
        else
        {
            keyText.SetActive(false);
        }
    }

}
