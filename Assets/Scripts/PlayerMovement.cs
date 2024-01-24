using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region SerializedFields
    [SerializeField]
    [Tooltip("Player Movement Speed")]
    public float playerSpeed = .5f;
    #endregion


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0;
        float verticalInput = 0;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }

        var moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.Translate((moveDirection * (playerSpeed * Time.deltaTime)));

    }
}
