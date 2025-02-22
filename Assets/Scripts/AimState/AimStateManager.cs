using Cinemachine;
using UnityEngine;

namespace AimState
{
    public class AimStateManager : MonoBehaviour
    {
        AimBaseState _currentAimState;
        public HipFireState HipFireState = new HipFireState();
        public AimingState AimState = new AimingState();

        [HideInInspector] public Animator animator;

        [SerializeField] Transform camFollowPos;
        [SerializeField] Transform player;

        // public InputAxis verticalAxis = new InputAxis { Value = 0f };
        // public InputAxis horizontalAxis = new InputAxis { Value = 0f };
        public float sensitivity = 3f;

        CinemachineInputAxisDriver _xAxis, _yAxis;
        [HideInInspector] public CinemachineVirtualCamera vcamera;
        [SerializeField] public CinemachineVirtualCamera aimcamera;
        public float adsFov = 22f;
        [HideInInspector] public float hipFov;
        [HideInInspector] public float currentFov;
        [SerializeField] public float fovSmoothSpeed = 10f;

        

        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            vcamera = GetComponentInChildren<CinemachineVirtualCamera>();
            hipFov = Camera.main.fieldOfView;
            animator = GetComponent<Animator>();
            SwitchState(HipFireState);
        }

        void Update()
        {
            // float xAxis = Input.GetAxis("Mouse X");
            // float yAxis = Input.GetAxis("Mouse Y");
            // yAxis = Mathf.Clamp(yAxis, -80f, 80f);
            // horizontalAxis.Value += xAxis * sensitivity * Time.deltaTime;
            // verticalAxis.Value += yAxis * sensitivity * Time.deltaTime;
            _currentAimState.UpdateState(this);

            //vcamera.Lens.FieldOfView = Mathf.Lerp(Camera.main.fieldOfView, hipFov, fovSmoothSpeed * Time.deltaTime);

            
        }

        // private void LateUpdate()
        // {
        //     camFollowPos.localEulerAngles = new Vector3(verticalAxis.Value, camFollowPos.localEulerAngles.y,
        //         camFollowPos.localEulerAngles.z);
        //     transform.eulerAngles = new Vector3(transform.eulerAngles.x, horizontalAxis.Value, transform.eulerAngles.z);
        // }

        public void SwitchState(AimBaseState state)
        {
            _currentAimState = state;
            _currentAimState.EnterState(this);
        }
    }
}