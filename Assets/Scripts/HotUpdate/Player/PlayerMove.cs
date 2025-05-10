using System;
using System.Collections.Generic;
using System.Text;
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

      public override void OnStateLateUpdate(IFSM<PlayerMove> fsm)
      {
      }

      public override void OnStateFixedUpdate(IFSM<PlayerMove> fsm)
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

      public override void OnStateLateUpdate(IFSM<PlayerMove> fsm)
      {
      }

      public override void OnStateFixedUpdate(IFSM<PlayerMove> fsm)
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
      
      public bool isServer = false;
      
      public LinkedList<int> ClientList = new LinkedList<int>(); // 客户端列表
      
      public Dictionary<int, Transform> PlayerPool = new Dictionary<int, Transform>(); // 玩家对象池
      
      private void Start()
      {
         string name = FF8.Config.GetroleByID(GameDataModule.Instance.RoleId).name;
         
         Destroy(playerRole.gameObject);

         FF8.Asset.LoadAsync<GameObject>(name, o =>
         {
            playerRole = Instantiate(o, transform).transform;
         });
         
         
         // 创建两个状态
         var attackState = new AttackState();
         var moveState = new MoveState();
         
         // 创建有限状态机
         playerFSM = FF8.FSM.CreateFSM("PlayerFSM", this, attackState, moveState);
         playerFSM.DefaultState = moveState;
         playerFSM.ChangeToDefaultState();

         FF8.UI.OpenAsync(DemoInitState.UIID.UIAward);
         FF8.UI.OpenAsync(DemoInitState.UIID.UIAward);
         FF8.UI.OpenAsync(DemoInitState.UIID.UIAward);
         FF8.UI.OpenAsync(DemoInitState.UIID.UIAward);
         FF8.UI.OpenAsync(DemoInitState.UIID.UIAward);
         
         // FF8.Input.SwitchDevice(new XboxInputDevice());
         
         FF8.Storage.SetEncrypt(new Util.OptimizedAES("AES_Key123", "AES_IV123"));
         
         FF8.Storage.SetUser("userID");
         
         FF8.Storage.SetFloat("PlayerSpeed", speed);
         
         FF8.Storage.SetFloat("PlayerSpeed", speed, true);
         
         FF8.Storage.SetObject("Key5", Info);
         
         
         // 启动SDK，平台id，渠道id
         FF8.SDK.SDKStart("1", "1");
    
         // 登录
         FF8.SDK.SDKLogin();

         if (isServer)
         {
            // 设置回调
            tcpServerChannel.OnConnected += TcpServer_OnConnected;
            tcpServerChannel.OnDisconnected += TcpServer_OnDisconnected;
            tcpServerChannel.OnDataReceived += TcpServer_OnDataReceived;
         
            // 可选，开启多线程（注意：WebGL不支持多线程）
            // FF8.Network.StartThread();
         
            // 添加通道
            FF8.Network.AddChannel(tcpServerChannel);
         
            // 开始监听端口
            tcpServerChannel.Start();
         }
         else
         {
            // 设置回调
            tcpClientChannel.OnConnected += TcpClient_OnConnected;
            tcpClientChannel.OnDataReceived += TcpClient_OnDataReceived;
            tcpClientChannel.OnDisconnected += TcpClient_OnDisconnected;
         
            // 可选，开启多线程（注意：WebGL不支持多线程）
            // FF8.Network.StartThread();
         
            // 添加通道
            FF8.Network.AddChannel(tcpClientChannel);
         
            // 连接通道
            tcpClientChannel.Connect("127.0.0.1", 6789);
         }
      }

      public class ClassInfo
      {
         public string Initial = "initial";
         public string id = "userID";
      }

      public ClassInfo Info = new ClassInfo();
      
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
      
      
      /*----------------------------tcp/kcp服务器使用----------------------------*/
      // 创建tcp通道
      TcpServerChannel tcpServerChannel = new TcpServerChannel("TEST_TCP_SERVER", 6789);
      
      void TcpServer_OnConnected(int conv, string ip)
      {
         LogF8.LogNet($"TCP_SERVER conv: {conv} Connected, ip: {ip}");
         ClientList.AddLast(conv);
      }
      
      void TcpServer_OnDataReceived(int conv, byte[] data)
      {
         msgData receivedData = msgData.FromBytes(data);
         receivedData.conv = conv;
         byte[] data2 = receivedData.ToBytes();
         LogF8.LogNet($"TCP_SERVER receive data from conv: {conv} . Data: {receivedData.conv}  {receivedData.position}");
         foreach (int item in ClientList)
         {
            if (item != conv) // 发送给其他客户端
            {
               tcpServerChannel.SendMessage(item, data2);
            }
         }
      }
      
      void TcpServer_OnDisconnected(int conv)
      {
         LogF8.LogNet($"TCP_SERVER conv: {conv} Disconnected");
         ClientList.Remove(conv);
      }

      private msgData _msgData = new msgData();
      int TimerId = 0;
      /*----------------------------tcp/kcp客户端使用----------------------------*/
      // 创建tcp通道
      TcpClientChannel tcpClientChannel = new TcpClientChannel("TEST_TCP_CLIENT");
      
      void TcpClient_OnConnected()
      {
         LogF8.LogNet($"TCP_CLIENT Connected");
         // 连接后每0.03333秒发信息
         TimerId = FF8.Timer.AddTimer(this, 0.03333f, 0f, -1, () =>
         {
            _msgData.conv = 0;
            _msgData.position = transform.position;
            byte[] data = _msgData.ToBytes();
            tcpClientChannel.SendMessage(data);
         });
      }
      
      void TcpClient_OnDataReceived(byte[] data)
      {
         msgData receivedData = msgData.FromBytes(data);
         LogF8.LogNet($"TCP_CLIENT receive data: {receivedData.conv}  {receivedData.position}");
         if (PlayerPool.TryGetValue(receivedData.conv, out var value))
         {
            value.position = receivedData.position;
         }
         else
         {
            Transform tr = Instantiate(playerRole, receivedData.position, Quaternion.identity);
            tr.localScale = Vector3.one * 0.1f;
            PlayerPool.TryAdd(receivedData.conv, tr);
         }
      }
      
      void TcpClient_OnDisconnected()
      {
         LogF8.LogNet($"TCP_CLIENT Disconnected");
         FF8.Timer.RemoveTimer(TimerId);
      }
      
      
      // 定义消息数据类
      public class msgData
      {
         public int conv;
         public Vector3 position;

         // 将 msgData 对象转换为字节数组
         public byte[] ToBytes()
         {
            byte[] convBytes = BitConverter.GetBytes(conv);
            byte[] xBytes = BitConverter.GetBytes(position.x);
            byte[] yBytes = BitConverter.GetBytes(position.y);
            byte[] zBytes = BitConverter.GetBytes(position.z);

            byte[] result = new byte[convBytes.Length + xBytes.Length + yBytes.Length + zBytes.Length];
            Array.Copy(convBytes, 0, result, 0, convBytes.Length);
            Array.Copy(xBytes, 0, result, convBytes.Length, xBytes.Length);
            Array.Copy(yBytes, 0, result, convBytes.Length + xBytes.Length, yBytes.Length);
            Array.Copy(zBytes, 0, result, convBytes.Length + xBytes.Length + yBytes.Length, zBytes.Length);

            return result;
         }

         // 从字节数组创建 msgData 对象
         public static msgData FromBytes(byte[] data)
         {
            int conv = BitConverter.ToInt32(data, 0);
            float x = BitConverter.ToSingle(data, sizeof(int));
            float y = BitConverter.ToSingle(data, sizeof(int) + sizeof(float));
            float z = BitConverter.ToSingle(data, sizeof(int) + 2 * sizeof(float));

            return new msgData
            {
               conv = conv,
               position = new Vector3(x, y, z)
            };
         }
      }
   }
}
