using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /*Config params*/
    [SerializeField] Paddle paddle;
    public float xVelocity = 0;
    public float yVelocity = 0;
    public AudioClip [] audioClips;

    Vector2 attachmentDistance;
    bool isBallAttached = false;
    Rigidbody2D rb;
    AudioSource audioSource;

    void Awake() {
        GetComponents();
    }


    // Start is called before the first frame update
    void Start()
    {
        AttachBallToPaddle();
        InitListeners();
    }


    // Update is called once per frame
    void Update()
    {
        if(isBallAttached) { UpdateBallPosition(); }
    }


    void OnDestroy() {
        try { UnregisterMouseButtonListener(); }
        catch { Debug.Log("Could not unregister mouse button listener"); }
    }

    
    void OnCollisionEnter2D(Collision2D other) {
        if(!isBallAttached){ PlayAudioSFX(); }
    }


    //region Auxiliar Functions
    void AttachBallToPaddle() {
        attachmentDistance = Utils.getVector2Distance(transform.position, paddle.transform.position);
        isBallAttached = true;
    }


    void UpdateBallPosition() =>
        transform.position = new Vector3(
            paddle.transform.position.x + attachmentDistance.x,
            paddle.transform.position.y + attachmentDistance.y,
            transform.position.z
        );


    void InitListeners() {
        MouseManager.OnLeftButtonClick += ShootBall;
    }


    void ShootBall() {
        UnregisterMouseButtonListener();
        isBallAttached = false;
        rb.velocity = new Vector2(xVelocity, yVelocity);
    }


    void UnregisterMouseButtonListener() => MouseManager.OnLeftButtonClick -= ShootBall;


    void GetComponents() {
        rb = gameObject.GetRigidbody2D();
        audioSource = GetComponent<AudioSource>();
    }


    void PlayAudioSFX() {
        AudioClip clip = audioClips.GetRandomItem();
        audioSource.PlayOneShot(clip);
    }
    //endregion
}
