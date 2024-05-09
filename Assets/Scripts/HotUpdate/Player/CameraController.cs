
using UnityEngine;

namespace Demo
{
    public class CameraController : MonoBehaviour
    {
        //游戏人物 的位置
        [SerializeField] private Transform player;
 
        //游戏人物与 相机的差
        private Vector3 offset;
 
        //相机的速度
        [SerializeField] private float smoothing = 3;
        private new Camera camera;
        // Use this for initialization
        void Start ()
        {
            camera = GetComponent<Camera>();
            transform.position = new Vector3(player.position.x, player.position.y ,transform.position.z);
            offset = transform.position - player.position;
        }
        
        // Update is called once per frame
        void LateUpdate() {
            //player.TransformDirection(offset)
            //世界坐标转换为局部坐标
            Vector3 targetPosition = player.position + player.TransformDirection(offset);
            //Vector3.Lerp 计算相机位置 和 目标位置的插值
            transform.position = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime * smoothing);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Matrix4x4 temp = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            if (camera != null)
            {
                Gizmos.DrawFrustum(Vector3.zero, camera.fieldOfView, camera.farClipPlane, camera.nearClipPlane, camera.aspect);
            }
            Gizmos.matrix = temp;
        }
    }
}