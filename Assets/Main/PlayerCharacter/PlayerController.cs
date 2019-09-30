using Boo.Lang;
using UnityEngine;
using UnityEngine.Animations;

namespace Main.PlayerCharacter
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public Animator anim;
        [SerializeField] private GameObject[] weapons;
        private CharacterController controller;

        private Joystick joystick;

        private Vector3 moveDirection;
        private float gravityScale = 4.5f, moveSpeed = 10, jumpForce = 12;
        private bool equipedWeapon = true, canMove = true, canJump = true, pressedJump, little, canChangeSize = true;

        private float axisX, axisZ;
        private static readonly int ASpeed = Animator.StringToHash("speed");
        private static readonly int AIsGrounded = Animator.StringToHash("isGrounded");
        private static readonly int AWhatWeapon = Animator.StringToHash("weapon");
        private static readonly int AAttack = Animator.StringToHash("Attack");
        private static readonly int ADie = Animator.StringToHash("Die");

        // Start is called before the first frame update
        void Start() {
            controller = GetComponent<CharacterController>();
            joystick = FindObjectOfType<Joystick>();
        }

        // Update is called once per frame
        void Update() {
            Move();
        }


        private void Move()
        {
            axisX = Input.GetAxisRaw("Horizontal");
            axisZ = Input.GetAxisRaw("Vertical");

            if (canMove)
            {
                //Borrar codigo de teclado al acabar
                moveDirection = new Vector3((joystick.Horizontal * moveSpeed) + (axisX * moveSpeed),moveDirection.y,(joystick.Vertical * moveSpeed) + (axisZ * moveSpeed));
                transform.LookAt(transform.position + new Vector3(moveDirection.x,0,moveDirection.z));
            }

            //Borrar codigo de teclado al acabar
            if ((axisX > 0.1 || axisX < -0.1 || axisZ > 0.1 || axisZ < -0.1) || (joystick.Horizontal > 0.1 || joystick.Horizontal < -0.1 || joystick.Vertical > 0.1 || joystick.Vertical < -0.1) && canMove) {
                anim.SetFloat(ASpeed,1);
            }
            else {
                anim.SetFloat(ASpeed,0);
            }

            Jump();

            controller.Move(moveDirection * Time.deltaTime);
        }
        

        private void Jump()
        {
            anim.SetBool(AIsGrounded,controller.isGrounded);
        

            if ((pressedJump) && controller.isGrounded && canJump) {
                moveDirection.y = jumpForce;
                canJump = false;
            }

            moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
        }

        public void PressJump()
        {
            if (canMove)
            {
                if (pressedJump)
                {
                    pressedJump = false;
                    canJump = true;
                }
                else
                {
                    pressedJump = true;
                
                }
            }
        }


        public void Impulse(float force)
        {
            anim.SetBool(AIsGrounded,controller.isGrounded);

            moveDirection.y = force;
            canJump = false;

            moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
        }
        

        public void ChangeWeapon()
        {

            if (canMove)
            {
                if (equipedWeapon)
                {
                    equipedWeapon = false;
                    weapons[0].SetActive(false);
                    weapons[1].SetActive(true);
                    anim.SetBool(AWhatWeapon,equipedWeapon);
                }
                else
                {
                    equipedWeapon = true;
                    weapons[0].SetActive(true);
                    weapons[1].SetActive(false);
                    anim.SetBool(AWhatWeapon,equipedWeapon);
                }
            }
        }

        public GameObject GetWeapon(int n)
        {
            return weapons[n];
        }


        public void Attack()
        {
            if (canMove)
            {
                if (equipedWeapon)
                {
                    DontMove();
                    anim.SetTrigger(AAttack);
                }
                else
                {
                    if (FindObjectOfType<GameManager.GameManager>().GetBullets() > 0)
                    {
                        DontMove();
                        anim.SetTrigger(AAttack);
                        FindObjectOfType<GameManager.GameManager>().UseBullet();
                    }
                } 
            }
        }


        public void RestartMove()
        {
            canMove = true;
        }


        public void Shrink()
        {
            if (canMove)
            {
                if (canChangeSize)
                {
                    if (little)
                    {
                        gravityScale = gravityScale / 2;
                        transform.localScale += new Vector3(+0.5f,+0.5f,+0.5f);
                        little = false;
                    }
                    else
                    {
                        gravityScale = gravityScale * 2;
                        transform.localScale += new Vector3(-0.5f,-0.5f,-0.5f);
                        little = true;
                    }   
                }  
            }
        }


        public bool GetLittle()
        {
            return little;
        }
        
        public void SetCanChangeSize(bool canChangeSize)
        {
            this.canChangeSize = canChangeSize;
        }

        public bool GetCanchangeSize()
        {
            return canChangeSize;
        }

        public void Die()
        {
            DontMove();
            anim.SetTrigger(ADie);
        }
        

        private void DontMove()
        {
            canMove = false;
            moveDirection = new Vector3(0,moveDirection.y,0);
        }


        public void ReceiveDamage(Transform location)
        {
            Impulse(jumpForce);
            controller.Move(new Vector3(transform.forward.x + 2,transform.forward.y ,transform.forward.z + 2));
            var position = location.position;
            transform.LookAt(new Vector3(position.x,transform.position.y,position.z));
            FindObjectOfType<GameManager.GameManager>().LoseLife();
        }

        public bool IsGrounded()
        {
            return controller.isGrounded;
        }


    }
}
