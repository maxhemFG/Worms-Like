using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Tooltip("The maximum rotation allowed for the weapon when aiming up and down.")]
    [SerializeField] private float clampRotationUp = 30;
    float lookUpRotation = 0f;
    private PlayerFireProjectile weapon;

    private void Start()
    {
        weapon = GetComponent<PlayerFireProjectile>();
    }

    public void AimWeapon()
    {
        lookUpRotation += PlayerInputManager.LookInput.normalized.y * PlayerInputManager.Instance.GetVerticalSens();
        lookUpRotation = Mathf.Clamp(lookUpRotation, -clampRotationUp, clampRotationUp);
        transform.localRotation = Quaternion.Euler(-lookUpRotation, transform.parent.transform.rotation.y, transform.parent.transform.rotation.z);
    }

    public void FireProjectile(bool grounded) {
        weapon.Shoot(grounded);
    }

}
