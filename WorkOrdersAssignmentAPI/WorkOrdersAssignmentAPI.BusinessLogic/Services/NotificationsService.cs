using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.BusinessLogic.Interfaces;
using WorkOrdersAssignmentAPI.Common.DTOs;
using WorkOrdersAssignmentAPI.Repository.Interfaces;

namespace WorkOrdersAssignmentAPI.BusinessLogic.Services
{
    public class NotificationsService : INotifications
    {
        private readonly INotificationsRepo _notificationsRepo;

        public NotificationsService(INotificationsRepo notificationsRepo)
        {
            _notificationsRepo = notificationsRepo;
        }
        public NotificationDTO ReadNotification()
        {
            return _notificationsRepo.ReadNotification();
        }

        public void SendNotification(NotificationDTO notificationDTO)
        {
            _notificationsRepo.SendNotification(notificationDTO);
        }
    }
}
