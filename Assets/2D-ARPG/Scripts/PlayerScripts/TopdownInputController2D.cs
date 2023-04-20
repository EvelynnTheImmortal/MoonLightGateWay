using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (AttackTrigger))]
[RequireComponent(typeof (BoxCollider2D))]
[AddComponentMenu("2D Action-RPG Kit/Create Player(Top Down)")]

public class TopdownInputController2D : MonoBehaviour {
	private Animator anim;
	private Rigidbody2D rb;
	public float speed = 4.5f;
	private float dirX, dirY;
	private Status stat;
	private bool moving = false;
	private AttackTrigger atk;

	public bool canDash = false;
	public float dashSpeed = 15;
	public float dashDuration = 0.35f;
	private bool onDashing = false;
	public JoystickCanvas joyStick;// For Mobile
	private float moveHorizontal;
	private float moveVertical;

	public Slider dStaminaBar;

	private int maxStamina = 100;
	public int currentStamina;

	private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
	

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		stat = GetComponent<Status>();
		atk = GetComponent<AttackTrigger>();
		if(!anim && stat.mainSprite){
			anim = stat.mainSprite;
		}
		if(!anim && GetComponent<Animator>()){
			anim = GetComponent<Animator>();
		}
		currentStamina = maxStamina;
		dStaminaBar.maxValue = maxStamina;
		dStaminaBar.value = maxStamina;
        lastRoutine = StartCoroutine(StaminaIncreaser());
    }

	

	void Update(){
		if(Time.timeScale == 0.0f || stat.freeze || GlobalStatus.freezeAll || GlobalStatus.freezePlayer || !stat.canControl && !atk.meleefwd){
			rb.velocity = Vector2.zero;
			if(onDashing){
				CancelDash();
			}
			if(anim){
				anim.SetBool("run" , false);
			}
			return;
		}
		if(onDashing){
			return;
		}
		if(canDash && Input.GetKeyDown(KeyCode.Space))
		{
            StartCoroutine("Dash");
            
			
		}

		if(joyStick){
			if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
				moveHorizontal = Input.GetAxis("Horizontal");
				moveVertical = Input.GetAxis("Vertical");
			}else{
				moveHorizontal = joyStick.position.x;
				moveVertical = joyStick.position.y;
			}
		}else{
			moveHorizontal = Input.GetAxis("Horizontal");
			moveVertical = Input.GetAxis("Vertical");
		}
		//Flip Right Side
		if(moveHorizontal > 0.1 && !atk.facingRight){
			atk.facingRight = true;
			Vector3 rot = transform.eulerAngles;
			rot.y = 0;
			transform.eulerAngles = rot;
		}
		//Flip Left Side
		if(moveHorizontal < -0.1 && atk.facingRight){
			atk.facingRight = false;
			Vector3 rot = transform.eulerAngles;
			rot.y = 180;
			transform.eulerAngles = rot;
		}

       
    }
	
	void FixedUpdate(){
		if(Time.timeScale == 0.0f || stat.freeze || GlobalStatus.freezeAll || GlobalStatus.freezePlayer || stat.flinch || !stat.canControl /*|| stat.block*/){
			moveHorizontal = 0;
			moveVertical = 0;
			rb.velocity = Vector2.zero;
			return;
		}
		if(onDashing){
			if(Input.GetKeyUp(KeyCode.Space) || atk.onAttacking){
				CancelDash();
			}

			if(atk.aimAtMouse){
                //atk.LookAtMouse();
                //Vector3 dir = atk.attackPoint.TransformDirection(Vector3.right);
                Vector3 moveVector = Vector3.zero;
                moveVector.x = Input.GetAxis("Horizontal");
                moveVector.y = Input.GetAxis("Vertical");
           
                //float angle = Vector3.Angle(moveVector, Vector3.right);
                //Vector3 moveVector =  vecticalInput + horizontalInput;
                GetComponent<Rigidbody2D>().velocity = moveVector * dashSpeed;
			}else{
				Vector3 dir = transform.TransformDirection(Vector3.right);
				GetComponent<Rigidbody2D>().velocity = dir * dashSpeed;
			}
			return;
		}

		dirX = moveHorizontal * speed;
		dirY = moveVertical * speed;

		rb.velocity = new Vector2(dirX , dirY);
		if(moveHorizontal != 0 || moveVertical != 0){
			moving = true;
			if(anim){
				anim.SetBool("run" , moving);
			}
		}else if(moving){
			moving = false;
			if(anim){
				anim.SetBool("run" , moving);
			}
		}

		
	}

	public void DashButton(){
		StartCoroutine("Dash");
	}

	public IEnumerator Dash()
	{
        Debug.Log("DashStarted");
        
        if (currentStamina >= 33 && !onDashing)
        {
            StopCoroutine(lastRoutine);

            currentStamina -= 33;
            dStaminaBar.value = currentStamina;
            
            
                if (stat.block)
                {
                    stat.GuardBreak("cancelGuard");
                }
                if (atk.aimAtMouse)
                {
                    atk.LookAtMouse();
                }
                onDashing = true;
                anim.SetTrigger("dash");
                anim.ResetTrigger("cancelDash");
                canDash = false;
                yield return new WaitForSeconds(dashDuration);
                
                Debug.Log("dashended");
            
            CancelDash();

            
        }
        
	}
    Coroutine lastRoutine = null;
    public void CancelDash(){
		StopCoroutine("Dash");
        StopCoroutine(lastRoutine);
        anim.SetTrigger("cancelDash");
		onDashing = false;
        canDash = true;
        lastRoutine = StartCoroutine(StaminaIncreaser());
        
        //StartCoroutine(ResetDash());
    }

	//IEnumerator ResetDash()
	//{
	//	StopCoroutine("Dash");
	//	yield return new WaitForSeconds(2f);
	//	canDash = true;
		
	//	StopCoroutine("ResetDash");
	//}

	

	IEnumerator StaminaIncreaser()
	{
		
		yield return new WaitForSeconds(3);
		while (currentStamina < maxStamina)
		{
			currentStamina += maxStamina / 40;
			dStaminaBar.value = currentStamina;
			yield return regenTick;
        }
		
	}

}