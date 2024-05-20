using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kontroll : MonoBehaviour
{
    public Button btn;
    public float jumpforce = 2f;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    private Animator animator;
    

    public Text zzaman, ccan,durumm;
    float zamanSayaci = 100;
    float canSayaci = 30;

    bool oyunDevam = true;
    bool oyunTamam = false;

    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
       animator= GetComponent<Animator>(); 
    }

    void Update()
    {
       
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zzaman.text = (int)zamanSayaci + "";

        }
        else if (!oyunTamam)
        {
            durumm.text = "OYUN TAMAMLANAMADI";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci <= 0)
        {
                oyunDevam = false;
        }
        
    }
        private void FixedUpdate()
    {

        if (oyunDevam &&!oyunTamam)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("runn", true);
                transform.Translate(new Vector3(0, 0, 2f) * Time.deltaTime);
            }
            else
            {
                animator.SetBool("runn", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                animator.SetBool("jumpp", true);
                playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                isOnGround = false;
                /*transform.Translate(new Vector3(0, 2f, 0) * Time.deltaTime);*/
            }
            else
            {
                animator.SetBool("jumpp", false);
                isOnGround = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("walkback", true);
                transform.Translate(new Vector3(0, 0, -2f) * Time.deltaTime);
            }
            else
            {
                animator.SetBool("walkback", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("walkleft", true);
                transform.Translate(new Vector3(-2f, 0, 0) * Time.deltaTime);
            }
            else
            {
                animator.SetBool("walkleft", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("walkright", true);
                transform.Translate(new Vector3(2f, 0, 0) * Time.deltaTime);
            }
            else
            {
                animator.SetBool("walkright", false);
            }
        }
        else
        {
          
            playerRb.velocity= Vector3.zero;
            playerRb.angularVelocity= Vector3.zero;
        }
        
    }
    public void OnCollisionEnter(Collision other) 
    {
        string ObjIsmi=other.gameObject.name;
        if (ObjIsmi.Equals("Finish"))
        {
            // print("Oyunu Kazandýnýz");
            oyunTamam = true;
            durumm.text = "OYUN TAMAMLANDI.TEBRÝKLER :)";
            btn.gameObject.SetActive(true);
        }
        else if (!ObjIsmi.Equals("Finish") && !ObjIsmi.Equals("zemin") && !ObjIsmi.Equals("duvar") && !ObjIsmi.Equals("Barrel_6") && !ObjIsmi.Equals("stonefloor")&&!ObjIsmi.Equals("column"));
        {
            canSayaci -= 1;
            ccan.text = canSayaci + "";

            if (canSayaci <= 0)
            {
                oyunDevam = false;
            }
        }
    }
}
