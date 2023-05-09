using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private CameraController cameraReference;
    [SerializeField] private AudioSource newAudio;
    [SerializeField] private AudioClip Fire;
    [SerializeField] private Camera Camera;
    private Vector3 movementDirection;

    private void Start() {
        GetComponent<HealthBarController>().onHit += cameraReference.CallScreenShake;
        newAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        MoveThePlayer();

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

        Vector3 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);
    
        Vector3 distance = mouseInput - transform.position;
        Debug.DrawRay(transform.position, distance * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0)){
            BulletController myBullet =  Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            myBullet.SetUpVelocity(distance.normalized, gameObject.tag);
            newAudio.PlayOneShot(Fire);
        }else if(Input.GetMouseButtonDown(1)){
            Debug.Log("Left Click");
        }
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    public void UpdateMovement(Vector2 start)
    {
        myRBD2.velocity = start * velocityModifier;
    }
    void MoveThePlayer()
    {
        Vector3 movement = CameraDirection(movementDirection) * velocityModifier * Time.deltaTime;
        myRBD2.MovePosition(transform.position + movement);
    }
    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = Camera.transform.forward;
        var cameraRight = Camera.transform.right;

        cameraForward.z = 0f;
        cameraRight.z = 0f;

        return cameraForward * movementDirection.y + cameraRight * movementDirection.x;
    }
    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }
}
