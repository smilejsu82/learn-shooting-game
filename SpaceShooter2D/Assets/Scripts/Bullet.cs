using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        Vector3 movement = Vector2.up * this.speed * Time.deltaTime;
        this.transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletBorder") 
        {
            Destroy(this.gameObject);
        }
    }
}
