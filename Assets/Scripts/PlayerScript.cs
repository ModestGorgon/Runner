using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    public float score;

    [SerializeField]
    bool IsGrounded = false;
    bool IsImmortal = false;

    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public Text ScoreTxt;
    public GameOver gameOver;

    public Sprite standing;
    public Sprite crouching;
    public Sprite dead;
    public Color color;

    public BoxCollider2D boxCollider;
    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;

        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standing;

        StandingSize = boxCollider.size;
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded == true)
            {
                rb.AddForce(Vector2.up * JumpForce);
                IsGrounded = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (IsGrounded == true)
            {
                spriteRenderer.sprite = crouching;
                boxCollider.size = CrouchingSize;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            spriteRenderer.sprite = standing;
            boxCollider.size = StandingSize;
        }

        if (IsGrounded)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE: " + score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (IsGrounded == false)
            {
                IsGrounded = true;
            }
        }
        
       if (collision.gameObject.CompareTag("Obstacle") && IsImmortal == false)
        {
            spriteRenderer.sprite = dead;
            PlayerPrefs.SetFloat("Highscore", score);
            StartCoroutine(ExecuteAfterTime());
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.CompareTag("Bonus"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(BecomeImmortal());
        }

    } 

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(5f);
    }

    public IEnumerator BecomeImmortal()
    {
        spriteRenderer.color = new Color(0, 1, 1);
        IsImmortal = true;
        yield return new WaitForSeconds(10);
        IsImmortal = false;
        spriteRenderer.color = Color.white;
    }
}
