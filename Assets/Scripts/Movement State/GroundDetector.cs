using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private Vector3 _spherePosition;
    private CharacterController _characterController;
    [SerializeField] float groundYOffset;
    [SerializeField] private LayerMask groundLayer;
    bool IsGrounded()
    {
        
        _spherePosition = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        //Player touching ground
        
        if (Physics.CheckSphere(_spherePosition, _characterController.radius, groundLayer)) return true;
        return false;
    }
}
