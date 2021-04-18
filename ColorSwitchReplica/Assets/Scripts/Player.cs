using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;

    public Rigidbody2D rb;

    [SerializeField] public SpriteRenderer sr;

    [SerializeField] public string currentColour;

    [SerializeField] public Color colorCyan;
    [SerializeField] public Color colorPink;
    [SerializeField] public Color colorPurple;
    [SerializeField] public Color colorYellow;

    void Start()
    {
        SetRandomColour();
            
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if( col.tag == "colorChanger")
        {
            SetRandomColour();
            Destroy(col.gameObject);
            return;
        }
        if( col.tag != currentColour)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void SetRandomColour()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColour = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColour = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColour = "Purple";
                sr.color = colorPurple;
                break;
            case 3:
                currentColour = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}
