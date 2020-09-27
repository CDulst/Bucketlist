using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{ 
    public Rigidbody2D MyRigidbody;
    [SerializeField] public float runspeed = 5f;
    [SerializeField] public float jump = 5f;
    [SerializeField] public float pulldown = 2f;
    [SerializeField] public float pullleft = -10f;
    [SerializeField] public float ThrowbackX = 5f;
    [SerializeField] public float ThrowbackY = 5f;
    [SerializeField] public AudioClip Deathsound;
    
    public Animator playercontroller;
    public LayerMask ground;
    public CapsuleCollider2D boxcollider;
    public bool Death;
    public SpriteRenderer san;
    public bool Cutscene;
    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        ground = LayerMask.GetMask("Ground");
        boxcollider = GetComponent<CapsuleCollider2D>();
        playercontroller = GetComponent<Animator>();
        san = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Death){
            Running();
            Checkfalling();
            if (boxcollider.IsTouchingLayers(ground))
            {
                Jumping();
            }
            Inair();
            Flipsprite();
        }
        else
        {
            if (!Cutscene){
                if (boxcollider.IsTouchingLayers(ground))
                {
                    playercontroller.SetBool("Death ground", true);
                    StartCoroutine(Despawn());
                }
            }
           
        }
     
    }
    public IEnumerator Despawn(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    public void Die(){
        Death = true;
        AudioSource.PlayClipAtPoint(Deathsound, Camera.main.transform.position, 1);
        playercontroller.SetBool("Death air", true);
        san.color = Color.red;
        float check = transform.localScale.x;
        if (check == 1f){
            Vector2 playerVelocity = new Vector2(-(ThrowbackX), ThrowbackY);
            MyRigidbody.velocity = playerVelocity;
        }
        else
        {
            Vector2 playerVelocity = new Vector2(ThrowbackX, ThrowbackY);
            MyRigidbody.velocity = playerVelocity;
        }





    }



    private void Running(){
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runspeed, MyRigidbody.velocity.y);
        MyRigidbody.velocity = playerVelocity;
        bool PlayerHasHorizontalSpeed = Mathf.Abs(MyRigidbody.velocity.x) > Mathf.Epsilon;
        playercontroller.SetBool("running", PlayerHasHorizontalSpeed);
        
        


    }
    private void Jumping(){
        if (Input.GetButtonDown("Jump")){
            GetComponent<AudioSource>().Play(0);
            playercontroller.SetBool("jump up", true);
            Vector2 JumpVelocity = new Vector2(MyRigidbody.velocity.x, jump);
            MyRigidbody.velocity += JumpVelocity;
          

            
        }
      
    }
    private void Inair(){
        if (!boxcollider.IsTouchingLayers(ground)){
            if (Mathf.Abs(MyRigidbody.velocity.y) < Mathf.Epsilon)
            {
                Vector2 Downword = new Vector2(MyRigidbody.velocity.x, pulldown);
                MyRigidbody.velocity -= Downword; 
            }
        }
       }
    private void Flipsprite(){
       
            bool PlayerHasHorizontalSpeed = Mathf.Abs(MyRigidbody.velocity.x) > Mathf.Epsilon;
            if (PlayerHasHorizontalSpeed)
            {
                Vector2 Direction = new Vector2(Mathf.Sign(MyRigidbody.velocity.x), 1f);
                transform.localScale = Direction;
            }

    }
    private void Checkfalling(){
        if (MyRigidbody.velocity.y < -0.1)
        {
            playercontroller.SetBool("jump up", false);
            playercontroller.SetBool("jump down", true);
           

        }
        if (boxcollider.IsTouchingLayers(ground))
        {
            playercontroller.SetBool("jump down", false);
            bool PlayerHasHorizontalSpeed = Mathf.Abs(MyRigidbody.velocity.x) > Mathf.Epsilon;
            playercontroller.SetBool("running", PlayerHasHorizontalSpeed);
            if (PlayerHasHorizontalSpeed == false){
                playercontroller.SetBool("idle", true);
            }

        }


    }
}
