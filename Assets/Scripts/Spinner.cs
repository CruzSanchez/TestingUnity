using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 1f;

    [SerializeField]
    float pushForce = 10f;

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var playerDirection = collision.gameObject.transform;

        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("Detected Collision!");

            var playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (90 - transform.eulerAngles.z)),
                    Mathf.Sin(Mathf.Deg2Rad * (90 - transform.eulerAngles.z)),
                    Mathf.Sin(Mathf.Deg2Rad * (90 - transform.eulerAngles.y))) * -1;

                Debug.Log(direction);

                playerRb.AddForce(direction * pushForce, ForceMode.Impulse);
            }
        }
    }
}
