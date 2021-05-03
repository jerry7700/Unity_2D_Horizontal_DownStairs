using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")]
    public float speed;
    [Header("檢測的範圍")]
    public float checkRadius;
    [Header("檢測的圖層")]
    public LayerMask platform;
    [Header("檢測的點")]
    public GameObject groundCheck;
    [Header("判斷地板")]
    public bool isOnGround;

    bool playerDead;
    float xVelocity;
    Rigidbody2D rb;
    Animator anim;
    #endregion

    #region 初始設定
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platform);
        anim.SetBool("isOnGround", isOnGround);

        Movement();
    }
    #endregion

    #region 設定
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }
    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    public void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        if(xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }

    /// <summary>
    /// 彈跳
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("彈跳"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }

    #region 死亡
    /// <summary>
    /// 觸碰尖刺死亡
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("尖刺"))
        {
            anim.SetTrigger("Dead");
        }
    }

    /// <summary>
    /// 玩家死亡
    /// </summary>
    public void PlayerDead()
    {
        playerDead = true;
        GameManager.GameOver(playerDead);
    }
    #endregion

    #endregion
}
