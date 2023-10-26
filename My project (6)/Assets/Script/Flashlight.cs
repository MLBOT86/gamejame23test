using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Flashlight : MonoBehaviour
{
    public TextMeshProUGUI SecondsLight;
    Vector2 MousePose;
    public GameObject LightSpote;
    public float TimeLight;
   public float CurrentTime;
    bool lighting = false;
    public  Camera cam;
    Rigidbody2D rb;
    public Rigidbody2D Player;
    private void Start()
    {
        CurrentTime = TimeLight;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SecondsLight.text = Mathf.Round(CurrentTime).ToString();
        MousePose = cam.ScreenToWorldPoint(Input.mousePosition);
        Lighting();
        if (lighting && CurrentTime >= 0)
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime <= 0)
            {
                LightSpote.SetActive(false);
                lighting = false;
            }
        }
           
        if (lighting==false&&CurrentTime<=TimeLight)
        {    
            CurrentTime += Time.deltaTime;
        }
       
    }
    private void FixedUpdate()
    {
        Vector2 Look = MousePose - rb.position;
        float angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.position = Player.position;
    }
    void Lighting()
    {
        if (Input.GetButtonDown("Fire1")&&lighting ==false)
        {
            lighting = true;
            LightSpote.SetActive(true);       
            return;    
        }
        else if (Input.GetButtonDown("Fire1") && lighting == true)
        {
            lighting = false;
            LightSpote.SetActive(false);     
            return;
        }
    }
    
}
