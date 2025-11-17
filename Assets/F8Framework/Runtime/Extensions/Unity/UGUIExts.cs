using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace F8Framework.Core
{
    public static class UGUIExts
    {
        public static UIBehaviour AddButtonClickListener(this UIBehaviour @this, UnityAction<BaseEventData> handle)
        {
            var eventTrigger = @this.gameObject.GetOrAddComponent<EventTrigger>();
            EventTrigger.Entry entry = eventTrigger.triggers.Find(e => e.eventID == EventTriggerType.PointerClick);
            if (entry == null)
            {
                entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
                eventTrigger.triggers.Add(entry);
            }
            entry.callback.AddListener(handle);
            return @this;
        }
        
        public static UIBehaviour AddButtonDownListener(this UIBehaviour @this, UnityAction<BaseEventData> handle)
        {
            var eventTrigger = @this.gameObject.GetOrAddComponent<EventTrigger>();
            EventTrigger.Entry entry = eventTrigger.triggers.Find(e => e.eventID == EventTriggerType.PointerDown);
            if (entry == null)
            {
                entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
                eventTrigger.triggers.Add(entry);
            }
            entry.callback.AddListener(handle);
            return @this;
        }
        
        public static UIBehaviour AddButtonUpListener(this UIBehaviour @this, UnityAction<BaseEventData> handle)
        {
            var eventTrigger = @this.gameObject.GetOrAddComponent<EventTrigger>();
            EventTrigger.Entry entry = eventTrigger.triggers.Find(e => e.eventID == EventTriggerType.PointerUp);
            if (entry == null)
            {
                entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
                eventTrigger.triggers.Add(entry);
            }
            entry.callback.AddListener(handle);
            return @this;
        }
        
        public static UIBehaviour AddListener(this UIBehaviour @this, EventTriggerType triggerType, UnityAction<BaseEventData> handle)
        {
            var eventTrigger = @this.gameObject.GetOrAddComponent<EventTrigger>();
            EventTrigger.Entry entry = eventTrigger.triggers.Find(e => e.eventID == triggerType);
            if (entry == null)
            {
                entry = new EventTrigger.Entry { eventID = triggerType };
                eventTrigger.triggers.Add(entry);
            }
            entry.callback.AddListener(handle);
            return @this;
        }
        
        // 便捷移除方法
        public static UIBehaviour RemoveButtonClickListener(this UIBehaviour @this, UnityAction<BaseEventData> handle)
        {
            return @this.RemoveListener(EventTriggerType.PointerClick, handle);
        }
        
        public static UIBehaviour RemoveButtonDownListener(this UIBehaviour @this, UnityAction<BaseEventData> handle)
        {
            return @this.RemoveListener(EventTriggerType.PointerDown, handle);
        }
        
        public static UIBehaviour RemoveButtonUpListener(this UIBehaviour @this, UnityAction<BaseEventData> handle)
        {
            return @this.RemoveListener(EventTriggerType.PointerUp, handle);
        }
        
        // 移除特定类型的所有监听器
        public static UIBehaviour RemoveAllButtonClickListeners(this UIBehaviour @this)
        {
            return @this.RemoveAllListeners(EventTriggerType.PointerClick);
        }
        
        public static UIBehaviour RemoveAllButtonDownListeners(this UIBehaviour @this)
        {
            return @this.RemoveAllListeners(EventTriggerType.PointerDown);
        }
        
        public static UIBehaviour RemoveAllButtonUpListeners(this UIBehaviour @this)
        {
            return @this.RemoveAllListeners(EventTriggerType.PointerUp);
        }
        
        // 移除所有事件类型的所有监听器
        public static UIBehaviour RemoveAllEventListeners(this UIBehaviour @this)
        {
            var eventTrigger = @this.GetComponent<EventTrigger>();
            if (eventTrigger != null)
            {
                foreach (var entry in eventTrigger.triggers)
                {
                    entry.callback.RemoveAllListeners();
                }
                eventTrigger.triggers.Clear();
            }
            return @this;
        }
        
        // 移除EventTrigger组件
        public static UIBehaviour RemoveEventTrigger(this UIBehaviour @this)
        {
            var eventTrigger = @this.GetComponent<EventTrigger>();
            if (eventTrigger != null)
            {
                UnityEngine.Object.Destroy(eventTrigger);
            }
            return @this;
        }
        
        public static UIBehaviour RemoveListener(this UIBehaviour @this, EventTriggerType triggerType, UnityAction<BaseEventData> handle)
        {
            var eventTrigger = @this.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = eventTrigger?.triggers.Find(e => e.eventID == triggerType);
            entry?.callback.RemoveListener(handle);
            return @this;
        }
        
        public static UIBehaviour RemoveAllListeners(this UIBehaviour @this, EventTriggerType triggerType)
        {
            var eventTrigger = @this.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = eventTrigger?.triggers.Find(e => e.eventID == triggerType);
            entry?.callback.RemoveAllListeners();
            return @this;
        }
        
        public static void EnableImage(this Image @this)
        {
            var c = @this.color;
            @this.color = new Color(c.r, c.g, c.b, 1);
        }
        
        public static void DisableImage(this Image @this)
        {
            var c = @this.color;
            @this.sprite = null;
            @this.color = new Color(c.r, c.g, c.b, 0);
        }
    }
}
