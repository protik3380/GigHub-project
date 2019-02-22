using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub_Fundamental.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? OrginalDateTime { get; private set; }
        public string OrginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {

        }

        private Notification(NotificationType type, Gig gig)
        {
            if (gig == null)
            {
                throw new ArgumentNullException("Gig");
            }
            NotificationType = type;
            Gig = gig;
            DateTime = DateTime.Now;
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(NotificationType.GigCreate, gig);
        }

        public static Notification GigUpdated(Gig newGig, DateTime orginalDateTime, string orginalVenue)
        {
            var notification = new Notification(NotificationType.GigUpdated, newGig);
            notification.OrginalDateTime = orginalDateTime;
            notification.OrginalVenue = orginalVenue;
            return notification;
        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(NotificationType.GigCanceled, gig);
        }
    }
}