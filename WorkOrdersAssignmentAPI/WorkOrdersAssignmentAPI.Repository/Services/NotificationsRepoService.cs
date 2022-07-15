using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.Common.DTOs;
using WorkOrdersAssignmentAPI.Repository.Interfaces;

namespace WorkOrdersAssignmentAPI.Repository.Services
{
    public class NotificationsRepoService : INotificationsRepo
    {
        public NotificationDTO ReadNotification()
        {
            NotificationDTO notificationDTO = new NotificationDTO()
            {
                Message = "Notification from user"
            };
            return notificationDTO;
        }

        public void SendNotification(NotificationDTO notificationDTO)
        {
            Console.WriteLine($"Message to {notificationDTO.TechnicianRegNum}: {notificationDTO.Message}");
        }
    }
}
