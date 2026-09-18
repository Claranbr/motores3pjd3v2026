using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 6, -8);

    private void LateUpdate()
    {
        if (player == null)
            return;

        transform.position = player.position + player.TransformDirection(offset);

        transform.LookAt(player);
    }
}