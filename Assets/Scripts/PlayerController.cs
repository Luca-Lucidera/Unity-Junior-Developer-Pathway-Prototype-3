using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier = 1.0f; //Gravità della terra
    public bool gameOver = false;
    public ParticleSystem explosionVfx;
    public ParticleSystem dirtVfx;
    public AudioClip jumpSfx;
    public AudioClip crashSfx;

    private bool isOnGround = true;
    private Rigidbody playerRigidBody;
    private Animator animator;
    private AudioSource audioSource;
    private AudioSource mainCameraAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Global value
        Physics.gravity *= gravityModifier;

        //Internal GameObject componenet
        playerRigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        //External GameObject
        mainCameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Disable multiple jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {   
            //Logic
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            
            //Animation
            animator.SetTrigger("Jump_trig");
            
            //VFX
            dirtVfx.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                //Logic
                isOnGround = true;
                
                //FX
                dirtVfx.Play();
                
                //AUDIO
                audioSource.PlayOneShot(jumpSfx);
                break;
            case "Obstacle":
                //Logic
                gameOver = true;
                
                //AUDIO
                audioSource.PlayOneShot(crashSfx);
                mainCameraAudioSource.Stop();

                //ANIMATION
                animator.SetBool("Death_b", true);
                animator.SetInteger("DeathType_int", 1);

                //VFX
                explosionVfx.Play();
                dirtVfx.Stop();
                break;
            default:
                break;
        }
    }
}
