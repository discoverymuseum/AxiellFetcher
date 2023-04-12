using System;
using FetchingServer.Objects;

namespace FetchingServer.Objects
{
    public class CollectionObject
    {
        public string id { get; set; }
        public string guid { get; set; }
        public string priref { get; set; }
        public string objectTitle { get; set; }
        public string objectName { get; set; }
        public string objectNumber { get; set; }
        public string objectPlacingA { get; set; }
        public string objectPlacingB { get; set; }
        public string manufacturer { get; set; }
        public string creator { get; set; }
        public string creatorRole { get; set; }
        public string productionPlace { get; set; }
        public string date_start { get; set; }
        public string date_end { get; set; }
        public string material { get; set; }
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string category { get; set; }
        public string collection { get; set; }
        public string description { get; set; }
        public string pid_work_uri { get; set; }
        public string pid_work_url { get; set; }
        public string entry_created { get; set; }
        public string entry_modified { get; set; }

        public List<CollectionImage> images { get; set; }

        public CollectionObject()
        {

        }

    }
}

