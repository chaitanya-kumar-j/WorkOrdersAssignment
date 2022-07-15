using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrdersAssignmentAPI.Common.DTOs;

namespace WorkOrdersAssignmentAPI.Repository.Interfaces
{
    public interface INotificationsRepo
    {
        void SendNotification(NotificationDTO notificationDTO);

        NotificationDTO ReadNotification();
    }
}
