using UnityEngine;

public class ReverseWall : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerInstance;

    private void OnTriggerEnter(Collider other)
    {
        playerInstance = GameObject.Find("Player").GetComponent<PlayerMovement>();

        playerInstance.playerSpeed = playerInstance.playerSpeed * -1;
    }
}
