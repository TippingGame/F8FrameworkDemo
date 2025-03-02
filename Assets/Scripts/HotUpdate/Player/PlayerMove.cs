using System;
using F8Framework.Core;
using F8Framework.Launcher;
using UnityEngine;

namespace Demo
{
   // 攻击状态
   public class AttackState : FSMState<PlayerMove>
   {
      private Animator animator;
      public override void OnInitialization(IFSM<PlayerMove> fsm)
      {
         animator = fsm.Owner.playerRole.GetComponent<Animator>();
      }
    
      public override void OnStateEnter(IFSM<PlayerMove> fsm)
      {
         if (animator)
         {
            animator.Play("Player_attack");
         }
      }
    
      public override void OnStateUpdate(IFSM<PlayerMove> fsm)
      {
      }
    
      public override void OnStateExit(IFSM<PlayerMove> fsm)
      {
      }
    
      public override void OnTermination(IFSM<PlayerMove> fsm)
      {
      }
   }
   
   // 移动状态
   public class MoveState : FSMState<PlayerMove>
   {
      private Animator animator;
      public override void OnInitialization(IFSM<PlayerMove> fsm)
      {
         animator = fsm.Owner.playerRole.GetComponent<Animator>();
      }
    
      public override void OnStateEnter(IFSM<PlayerMove> fsm)
      {
         if (animator)
         {
            animator.Play("Player_move");
         }
      }
    
      public override void OnStateUpdate(IFSM<PlayerMove> fsm)
      {
      }
    
      public override void OnStateExit(IFSM<PlayerMove> fsm)
      {
      }
    
      public override void OnTermination(IFSM<PlayerMove> fsm)
      {
      }
   }
   
   public class PlayerMove : MonoBehaviour
   {
      [SerializeField] float speed = 1f;

      public Transform playerRole;

      private IFSM<PlayerMove> playerFSM;
      private void Start()
      {
         string name = FF8.Config.GetroleByID(GameDataModule.Instance.RoleId).name;
         
         Destroy(playerRole.gameObject);
         
         playerRole = Instantiate(FF8.Asset.Load<GameObject>(name), transform).transform;
         
         
         // 创建两个状态
         var attackState = new AttackState();
         var moveState = new MoveState();
         
         // 创建有限状态机
         playerFSM = FF8.FSM.CreateFSM("PlayerFSM", this, attackState, moveState);
         playerFSM.DefaultState = moveState;
         playerFSM.ChangeToDefaultState();

         FF8.UI.Open(DemoInitState.UIID.UIAward);
         FF8.UI.Open(DemoInitState.UIID.UIAward);
         FF8.UI.Open(DemoInitState.UIID.UIAward);
         FF8.UI.Open(DemoInitState.UIID.UIAward);
         FF8.UI.Open(DemoInitState.UIID.UIAward);
         
         // FF8.Input.SwitchDevice(new XboxInputDevice());
      }

      private void Update()
      {
         Move();
         Attack();
      }

      private void Move()
      {
         float x = FF8.Input.GetAxisRaw(InputAxisType.HorizontalRaw);
         float y = FF8.Input.GetAxisRaw(InputAxisType.VerticalRaw);

         if (x == 0 && y == 0)
         {
            return;
         }
         
         playerRole.SetLocalScaleX(x > 0 ? -1 : 1);
         
         if (x != 0 && y != 0)
         {
            x *= 0.707f;
            y *= 0.707f;
         }
         transform.Translate(x * Time.deltaTime * speed,
            y * Time.deltaTime * speed, 0, Space.World);
         
         playerFSM.ChangeState<MoveState>();
      }

      private void Attack()
      {
         if (FF8.Input.GetButtonDown(InputButtonType.MouseLeft) || FF8.Input.GetButtonDown(InputButtonType.MouseRight))
         {
            FF8.Audio.PlayAudioEffect3D("AF_VOH_Billy_Attack_02", true, this.transform.position);
            
            FF8.Message.DispatchEvent(GameDataModule.MessageEvent.SubHp);
            
            playerFSM.ChangeState<AttackState>();
         }
      }
   }
}
