namespace GroupProjectSethPortion
{
    internal class Event
    {
        internal string userName;
        internal string roomName;
        internal string fStart;
        internal string fEnd;

        internal string eventTitle;
        internal string meetingStart;
        internal string meetingEnd;
        internal string meetingDate;
        internal string meetingParticipants;
        internal string meetingDescription;
        public string getEventTitle()
        {
            return eventTitle;
        }
        public string getMeetingStart()
        {
            return meetingStart;
        }
        public string getMeetingDate()
        {
            return meetingDate;
        }
        public string getMeetingEnd()
        {
            return meetingEnd;
        }
        public string getMeetingParticipants()
        {
            return meetingParticipants;
        }
        public string getMeetingDescription()
        {
            return meetingDescription;
        }
        public string getUserName()
        {
            return userName;
        }

        public string getRoomName()
        {
            return roomName;
        }
        public string getFStart()
        {
            return fStart;
        }
        public string getFEnd()
        {
            return fEnd;
        }
        public Event()
        {
        }
    }
}