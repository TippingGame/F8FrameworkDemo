using System;
using F8Framework.Core;
using F8Framework.Launcher;
using UnityEngine;

namespace Demo
{
   public class PlayerMove : MonoBehaviour
   {
      [SerializeField] float speed = 1f;

      public Transform playerRole;

      private void Start()
      {
         string name = FF8.Config.GetroleByID(GameDataModule.Instance.RoleId).name;
         
         Destroy(playerRole.gameObject);
         
         playerRole = Instantiate(FF8.Asset.Load<GameObject>(name), transform).transform;
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
      }

      private void Attack()
      {
         if (FF8.Input.GetButtonDown(InputButtonType.MouseLeft) || FF8.Input.GetButtonDown(InputButtonType.MouseRight))
         {
            FF8.Audio.PlayAudioEffect3D("AF_VOH_Billy_Attack_02", true, this.transform.position);
         }
      }
   }
}
