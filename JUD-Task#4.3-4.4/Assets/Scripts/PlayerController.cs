using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    public Rigidbody rb;
     
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float RotateSpeed = 20.0f;
    private float jumpHeight = 5.0f;
    private float gravityValue = -9.81f;

    public GameObject[] bombType;
    public int bombtypeSelector;
    public GameObject CurrentBomb;
    private bool canThrow = true;
    private int bombCount;
    public BombBehaviorScript instantiatedBomb;
    public Transform shootPosition;

    public Dictionary<string, int> BombsHeldByPlayer;
    private int maximumBombs = 1;

    private bool hasMultibombsPowerUp = false;
    private bool hasStickybombsPowerUp = false;

    public int health = 10;
    public int Lives = 1;
    public Slider healthUI;
    public Text livesUI;
    public GameObject RestartUI;
    public Vector3 startpos;
    private int damage = 2;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        BombsHeldByPlayer = new Dictionary<string, int>();
        BombsHeldByPlayer.Add(transform.name, 0);
        RestartUI.SetActive(false);
        // controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;
        handleLives();
        if(transform.position.y < -1)
        {
            transform.position = startpos;
            Lives -= 1;
        }

        if (hasMultibombsPowerUp)
            maximumBombs = 3;
        else
            maximumBombs = 1;

        if (hasStickybombsPowerUp)
            bombtypeSelector = 1;
        else
            bombtypeSelector = 0;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        movementDirection.Normalize();



      //  Move(movementDirection);
      //  Rotation(movementDirection);
      //  Jump();
        Shoot();

        if (health <= 0)
        {
            Lives -= 1;
            health = 10;
        }





    }
    void handleLives()
    {
        livesUI.text = "Lives : " + Lives;

        if (Lives <= 0)
        {
            RestartUI.SetActive(true);
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene(0);
            Debug.Log("GameOver");
        }
    }
    void ReduceHealth()
    {
        health -= 1;
       
    }
    void Shoot()
    {
        if(CurrentBomb == null)
        {
            BombsHeldByPlayer[transform.name] = 0;
        }
        if (Input.GetKey(KeyCode.Q) && BombsHeldByPlayer[transform.name] < maximumBombs)
        {

            //if (canThrow || bombCount < 3) 
            //{ 
            //CurrentBomb =  Instantiate(bomb, shootPosition.position, shootPosition.rotation);
            //    bombCount++;
            //    Mathf.Clamp(bombCount, 0, 3);
            
                
                
            //}
            //if(bombCount == 3 && canThrow)
            //{
            //    StartCoroutine(WaitForTime());               
            //    bombCount = 0;
            //    return;
            //}
            CurrentBomb = Instantiate(bombType[bombtypeSelector], shootPosition.position, shootPosition.rotation);
            BombsHeldByPlayer[transform.name] += 1;


            //StartCoroutine(WaitForTime());
            CurrentBomb.GetComponent<BombBehaviorScript>().bombState = BombBehaviorScript.BombState.OnPlayer;          
        }
        //if (Input.GetKeyUp(KeyCode.Q))
        //{
        //    CurrentBomb.GetComponent<BombBehaviorScript>().bombState = BombBehaviorScript.BombState.IsThrown;
        //}
    }
    IEnumerator WaitForTime()
    {
        canThrow = false;
        yield return new WaitForSeconds(3);
        canThrow = true;
    }
    //void Rotation(Vector3 moveDirection)
    //{
    //   // transform.rotation *= Quaternion.Euler(0f, horizontal * Time.deltaTime * RotateSpeed, 0f);
    //   // transform.rotation = Quaternion.LookRotation(rb.velocity);

    //    if (moveDirection != Vector3.zero)
    //    {
    //        //transform.forward = Vector3.Lerp(transform.position,moveDirection,Time.deltaTime * RotateSpeed );
    //        transform.forward = moveDirection;
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MultibombPowerUp"))
        {
            StartCoroutine(hasMultibombs());
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("StickyBombPowerUp"))
        {
            StartCoroutine(HasStickyBombPowerUp());
            Destroy(other.gameObject);
        }
    }
    IEnumerator hasMultibombs()
    {
        hasMultibombsPowerUp = true;
        Lives += 1;
        yield return new WaitForSeconds(10f);
        hasMultibombsPowerUp = false;
    }
    IEnumerator HasStickyBombPowerUp()
    {
        hasStickybombsPowerUp = true;
        Lives += 1;
        yield return new WaitForSeconds(3f);
        hasStickybombsPowerUp = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Players"))
        {
            Dodamage(collision.gameObject);
            // collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 10f, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("MultibombPowerUp"))
        {
            StartCoroutine(hasMultibombs());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("StickyBombPowerUp"))
        {
            StartCoroutine(HasStickyBombPowerUp());
            Destroy(collision.gameObject);
        }


    }
    void Dodamage(GameObject go)
    {
        go.GetComponent<PlayerHealth>().ReduceHealth(damage);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            groundedPlayer = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            groundedPlayer = false;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            groundedPlayer = false;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    void Move(Vector3 moveDirection)
    {
        //controller.Move((Vector3.forward * horizontal) + (Vector3.right * vertical) * Time.deltaTime);
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // controller.Move(move * Time.deltaTime * playerSpeed);

        //transform.Translate(moveDirection * playerSpeed * Time.deltaTime, Space.World);
        controller.Move(moveDirection * playerSpeed * Time.deltaTime);
        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

    }
}
