using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchLeft;
    private bool isTouchRight;

    public int power;

    public GameObject playerBulletAPrefab;
    public GameObject playerBulletBPrefab;

    Animator anim;

    private void Start()
    {
        this.anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if ((this.isTouchRight && h == 1) || (this.isTouchLeft && h == -1))
        {
            h = 0;
        }

        float v = Input.GetAxisRaw("Vertical");

        if ((this.isTouchTop && v == 1) || (this.isTouchBottom && v == -1))
        {
            v = 0;
        }

        Vector3 currentPos = this.transform.position;
        Vector3 nextPos = new Vector3(h, v, 0).normalized * this.speed * Time.deltaTime;
        this.transform.position = currentPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            this.anim.SetInteger("Input", (int)h);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3 offsetY = Vector3.up * 0.7f;

            switch (power)
            {
                case 1:
                    Instantiate(this.playerBulletAPrefab, this.transform.position + Vector3.up * 0.7f, this.transform.rotation);
                    break;

                case 2:
                    Instantiate(this.playerBulletAPrefab, this.transform.position + offsetY + (Vector3.left * 0.2f), this.transform.rotation);
                    Instantiate(this.playerBulletAPrefab, this.transform.position + offsetY + (Vector3.right * 0.2f), this.transform.rotation);
                    break;

                case 3:
                    Instantiate(this.playerBulletAPrefab, this.transform.position + offsetY + (Vector3.left * 0.3f), this.transform.rotation);
                    Instantiate(this.playerBulletBPrefab, this.transform.position + offsetY, this.transform.rotation);
                    Instantiate(this.playerBulletAPrefab, this.transform.position + offsetY + (Vector3.right * 0.3f), this.transform.rotation);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    this.isTouchTop = true;
                    break;

                case "Bottom":
                    this.isTouchBottom = true;
                    break;

                case "Left":
                    this.isTouchLeft = true;
                    break;

                case "Right":
                    this.isTouchRight = true;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    this.isTouchTop = false;
                    break;

                case "Bottom":
                    this.isTouchBottom = false;
                    break;

                case "Left":
                    this.isTouchLeft = false;
                    break;

                case "Right":
                    this.isTouchRight = false;
                    break;
            }
        }
    }
}
