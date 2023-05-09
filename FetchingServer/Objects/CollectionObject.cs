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
        public List<ObjectName> objectName { get; set; }
        public string objectNumber { get; set; }
        public string objectPlacing { get; set; }
        public List<Manufacturer> manufacturer { get; set; }
        public List<Creator> creator { get; set; }
        public List<ProductionPlace> productionPlace { get; set; }
        public string date_start { get; set; }
        public string date_end { get; set; }
        public List<Material> material { get; set; }

        public List<Dimension> dimensions { get; set; }
        public List<Category> category { get; set; }
        public List<Collection> collection { get; set; }
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

    public class Manufacturer
    {
        public string manufacturer { get; set; }
        public string externalLink { get; set; }
    }

    public class Creator
    {
        public string creator { get; set; }
        public string creatorRole { get; set; }
        public string externalLink { get; set; }
    }

    public class Collection
    {
        public string collection { get; set; }
        public string externalLink { get; set; }
    }

    public class ProductionPlace
    {
        public string place { get; set; }
        public string externalLink { get; set; }
    }

    public class ObjectName
    {
        public string objectname { get; set; }
        public string externalLink { get; set; }
    }

    public class Material
    {
        public string material { get; set; }
        public string externalLink { get; set; }
    }

    public class Category
    {
        public string category { get; set; }
        public string externalLink { get; set; }
    }

    public class CreatorRoles
    {
        public string creatorRole { get; set; }
        public string externalLink { get; set; }
    }

    public class Dimension
    {
        public string dimensionType { get; set; }
        public string dimensionUnit { get; set; }
        public string dimensionValue { get; set; }
    }


}

