using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamController : MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensitivity = 0.1f;
    public Vector2 pitchMinMax = new Vector2(-40, 13);
    public Vector2 LookInput;

    private Vector2 _lookDirection;

    [SerializeField] private Transform player;

    private PlayerInputControls _input;

    private void Awake() => _input = new PlayerInputControls();

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        _lookDirection += new Vector2(LookInput.x * mouseSensitivity, LookInput.y * mouseSensitivity);

        // Clamps the rotation of the Y-AXIS (vertical)
        _lookDirection.y = Mathf.Clamp(_lookDirection.y, pitchMinMax.x, pitchMinMax.y);

        // Applies the rotations to the camera for vertical, and to the player for horizontal
        transform.localRotation = Quaternion.Euler(-_lookDirection.y, 0, 0);
        player.localRotation = Quaternion.Euler(0, _lookDirection.x, 0);
    }

    // Registering events
    private void OnEnable()
    {
        _input.PlayerControls.Look.performed += OnLook;
        _input.PlayerControls.Look.canceled += OnLook;
        _input.Enable();
    }

    // Deregistering events
    private void OnDisable()
    {
        _input.PlayerControls.Look.performed -= OnLook;
        _input.PlayerControls.Look.canceled -= OnLook;
        _input.Disable();
    }

    private void OnLook(InputAction.CallbackContext obj) => LookInput = obj.ReadValue<Vector2>();
}
