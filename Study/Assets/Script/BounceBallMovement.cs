using UnityEngine;

public class BounceBallMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                           //이동 속도 변수 설정
    public float jumForce = 5.0f;                            //점프의 힘 값을 준다.

    public Rigidbody rb;                                     //플레이어 중력 선언

    public bool isGrounded = true;                            //땅에 있는지 체크하는 변수 (true / falase)

    void Start()
    {
        
    }

    void Update()
    {
        //움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal");  //수평 입력
        float moveVertical = Input.GetAxis("Vertical");       //수직 이동   

        //속도 값으로 직접 이동
        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);

       if(isGrounded == true)
       {
            rb.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
            
            isGrounded = false;
       }
            
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;    
        }

    }
}
