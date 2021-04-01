using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterData", menuName ="Game Data/Character Data")]
public class CharacterData : ScriptableObject
{
    public float attackRange = .62f;
    public float attackRate = .5f;
    public int baseDamage = 20;
    public float movementSpeed = 10f;
    public float jumpForce = 30f;
    public float sideForce = 20f;
    public float crouchSpeed = 5f;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    //public float crouchColliderHeight = 1f;
    //public float normalColliderHeight = 2f;
    //public float rotationSpeed = 60f;
    //public float crouchRotationSpeed = 30f;
    //public float diveForve = 30f;
    //public float bulletInitialSpeed = 10f;
    //public float diveCooldownTimer = 0.25f;
}
