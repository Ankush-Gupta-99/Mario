using System.Collections;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public Canvas canvas;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    float JumpPower = 15;
    float DownPower = -7;
    public bool IsGrounded;
    private int coinCount = 0;
    public GameObject CoinBoxReplace;
   
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }

   
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            UiManager.instance.GameOverFun();
        }
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            transform.Translate(5 * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
            animator.SetBool("Walk", true);
            animator.SetBool("Jump", false);
            animator.SetBool("Wait", false);
            animator.SetBool("Duck", false);
            animator.SetBool("Drift", false);

        }

        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            transform.Translate(-5 * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
            animator.SetBool("Walk", true);
            animator.SetBool("Jump", false);
            animator.SetBool("Wait", false);
            animator.SetBool("Duck", false);
            animator.SetBool("Drift", false);


        }
        if ((Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D))) && (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A))))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Wait", false);
            animator.SetBool("Duck", false);
            animator.SetBool("Drift", true);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow)|| (Input.GetKey(KeyCode.W)))
        {
            

            if (IsGrounded)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Jump", true);
                animator.SetBool("Wait", false);
                animator.SetBool("Duck", false);
                animator.SetBool("Drift", false);
                rb.AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);
                    IsGrounded = false;
            }
            
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)|| (Input.GetKey(KeyCode.S)))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Wait", false);
            animator.SetBool("Duck", true);
            animator.SetBool("Drift", false);

            rb.AddForce(new Vector2(0, DownPower), ForceMode2D.Impulse);
        }
        if (Input.anyKey==false && Input.anyKeyDown==false)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Wait", true);
            animator.SetBool("Duck", false);
        }
        
    }
    

    private GameObject Child;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin Collider"))
        {
            coinCount++;
            Child = collision.transform.GetChild(0).gameObject;
            Child.SetActive(true);
            UiManager.instance.CoinCount.SetText("Coin: " + coinCount.ToString());
            GameObject coll = collision.gameObject;
            StartCoroutine(DelayCounter(Child,coll));
            Vector3 positionBalancer = new Vector3(0, 0.49f, 0);
            Instantiate(CoinBoxReplace, collision.gameObject.transform.position + positionBalancer, Quaternion.identity);
        }
             


        if (collision.gameObject.CompareTag("Coin Box") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Black Box") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            IsGrounded = true;
        }
        
    }
    
    

    IEnumerator DelayCounter(GameObject gameObj,GameObject coll)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        gameObj.SetActive(false);
        coll.gameObject.SetActive(false);
    }

}
