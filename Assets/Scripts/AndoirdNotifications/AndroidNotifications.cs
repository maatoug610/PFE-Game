using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class AndroidNotifications : MonoBehaviour
{
    [Header("Timer in Seconds")]
    [SerializeField] int timer = 22;
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationChannel  notificationChannel = new AndroidNotificationChannel(){
            Id = "example_channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic Notifications", 
        };

        AndroidNotificationCenter.RegisterNotificationChannel (notificationChannel);
        AndroidNotification notification = new AndroidNotification ();
        notification.Title = "Reward";
        notification. Text = "Hi Boss Take This !!!";
        notification. SmallIcon = "icon_1";
        notification. LargeIcon = "icon_2";
        notification.ShowTimestamp = true;
        //notification.FireTime = System.DateTime.Now.AddHours(timer);
        notification.FireTime = System.DateTime.Now.AddSeconds(timer);
        var identifier = AndroidNotificationCenter.SendNotification (notification, "example_channel_id");

        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled){
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification (notification, "example_channel_id");
        }
        
    }

   
}
