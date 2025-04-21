using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strenght = 5f;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strenght;
        }

        direction.y += gravity * Time.deltaTime;

        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteIndex++;

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
