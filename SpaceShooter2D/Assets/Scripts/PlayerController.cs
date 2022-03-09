using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchLeft;
    private bool isTouchRight;

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
