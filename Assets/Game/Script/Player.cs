using UnityEngine;
using UnityEngine.AI;
public class Player : Character
{
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private NavMeshAgent agent;
    private bool canMoveUp = true;

    public override void OnInit()
    {

        agent.enabled = false;
        base.OnInit();
    }
    private void FixedUpdate()
    {
        MoveByJoyStick();
    }
    private void MoveByJoyStick()
    {
        agent.enabled = true;
        Vector3 movementDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (movementDirection.magnitude > 0)
        {
            if (!canMoveUp && movementDirection.z > 0)
            {
                movementDirection.z = Mathf.Min(0, movementDirection.z);
            }
            ChangeAnim(CONST.RUN_ANIM);
            rb.velocity = movementDirection * 4 + rb.velocity.y * Vector3.up;


            float targetAngle = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg + 90f;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.right = targetRotation * Vector3.forward;

        }
        else
        {
            ChangeAnim(CONST.IDLE_ANIM);
            this.rb.velocity = new Vector3(0, 0, 0);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Stairs brick_bridge = other.GetComponent<Stairs>();
        if (other.CompareTag("Stairs") && bricks.Count == 0)
        {
            if ((int)this.GetColorType() != brick_bridge.GetColor())
            {
                canMoveUp = false;
            }
            else
            {
                canMoveUp = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stairs"))
        {
            canMoveUp = true;
        }
    }
}

