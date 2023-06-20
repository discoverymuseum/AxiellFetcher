using System;
using Newtonsoft.Json;
using FetchingServer.Objects;
using System.Xml;
using System.Globalization;
using System.Net;
using System.Text.Encodings.Web;

namespace FetchingServer
{
	public class Converter
	{
		public Converter()
		{
		}

		public static void ConvertSingle(ApiResponse response)
		{
			CollectionObject obj = new CollectionObject();
            obj.images = new List<CollectionImage>();
            obj.category = new List<Category>();
            obj.material = new List<Material>();
            obj.manufacturer = new List<Manufacturer>();
            obj.collection = new List<Collection>();
            obj.productionPlace = new List<ProductionPlace>();
            obj.creator = new List<Creator>();
            obj.dimensions = new List<Dimension>();
            obj.objectName = new List<ObjectName>();

            List<CreatorRoles> tempCreatorRoles = new List<CreatorRoles>();

            List<string> tempDimensionType = new List<string>();
            List<string> tempDimensionUnit = new List<string>();
            List<string> tempDimensionValue = new List<string>();



			XmlDocument xDoc = new XmlDocument();
			xDoc.LoadXml(response.data);

			XmlNodeList id = xDoc.GetElementsByTagName("id");
			XmlNodeList guid = xDoc.GetElementsByTagName("guid");
			XmlNodeList priref = xDoc.GetElementsByTagName("priref");
			XmlNodeList objectTitle = xDoc.GetElementsByTagName("title");
            XmlNodeList objectName = xDoc.GetElementsByTagName("object_name");
			XmlNodeList objectNumber = xDoc.GetElementsByTagName("object_number");
            XmlNodeList objectCategory = xDoc.GetElementsByTagName("object_category");
            XmlNodeList objectPlacing = xDoc.GetElementsByTagName("objectplacinga");

            XmlNodeList collection = xDoc.GetElementsByTagName("collection.name");

			XmlNodeList manufacturer = xDoc.GetElementsByTagName("manufacturer");

			XmlNodeList creator = xDoc.GetElementsByTagName("creator");
            XmlNodeList creatorRole = xDoc.GetElementsByTagName("creator.role");
            XmlNodeList productionPlace = xDoc.GetElementsByTagName("production.place");


            XmlNodeList date_start = xDoc.GetElementsByTagName("dating.date.start");
			XmlNodeList date_end = xDoc.GetElementsByTagName("dating.date.end");
			XmlNodeList material = xDoc.GetElementsByTagName("material");

            XmlNodeList dimensionUnit = xDoc.GetElementsByTagName("dimension.unit");
            XmlNodeList dimensionType = xDoc.GetElementsByTagName("dimension.type");
            XmlNodeList dimensionValue = xDoc.GetElementsByTagName("dimension.value");

            XmlNodeList media = xDoc.GetElementsByTagName("media.reference");
            XmlNodeList description = xDoc.GetElementsByTagName("label.text");

            XmlNodeList PIDWorkURI = xDoc.GetElementsByTagName("PID_work_URI");
            XmlNodeList PIDWorkURL = xDoc.GetElementsByTagName("PID_work_URL");





            #region TEMP GENERATED DATA
            // TEMP STATIC TIMESTAMP DATA
            obj.entry_created = "2021-11-12T06:33:45";
            obj.entry_modified = "2022-12-12T09:19:45";

  

            #endregion TEMP GENERATED DATA



            #region OBJECTS WITHOUT MULTIPLE OCCURENCES
            try
            {
				obj.id = objectNumber[0].InnerText.ToString();
			}
			catch
			{

                App.WriteErrorString("ObjectNumber does not exist, defaulting to empty field");
				Console.WriteLine("ObjectNumber does not exist, defaulting to empty field");
                obj.id = "empty_field";
			}

            try
            {
                string desc = WebUtility.HtmlDecode(description[0].InnerText.ToString());
                
                obj.description = desc.ToString();
            }
            catch
            {
                App.WriteErrorString("description does not exist, defaulting to empty field");
                Console.WriteLine("description does not exist, defaulting to empty field");
                obj.description = "empty_field";
            }

            try
            {
                string tit = WebUtility.HtmlDecode(objectTitle[0].InnerText.ToString());

                obj.objectTitle = tit.ToString();
            }
            catch
            {
                App.WriteErrorString("objectTitle does not exist, defaulting to empty field");
                Console.WriteLine("objectTitle does not exist, defaulting to empty field");
                obj.objectTitle = "empty_field";
            }

            try
            {
                obj.pid_work_uri = PIDWorkURI[0].InnerText.ToString();
            }
            catch
            {
                App.WriteErrorString("PIDWorkURI does not exist, defaulting to empty field");

                Console.WriteLine("PIDWorkURI does not exist, defaulting to empty field");
                obj.pid_work_uri = "empty_field";
            }

            try
            {
                obj.pid_work_url = PIDWorkURL[0].InnerText.ToString();
            }
            catch
            {

                App.WriteErrorString("PIDWorkURL does not exist, defaulting to empty field");

                Console.WriteLine("PIDWorkURL does not exist, defaulting to empty field");
                obj.pid_work_url = "empty_field";
            }

            try
            {
                obj.guid = guid[0].InnerText.ToString();
            }
            catch
            {

                App.WriteErrorString("guid does not exist, defaulting to empty field");

                Console.WriteLine("guid does not exist, defaulting to empty field");
                obj.guid = "empty_field";
            }

            try
            {
                obj.priref = priref[0].InnerText.ToString();
            }
            catch
            {
                App.WriteErrorString("priref does not exist, defaulting to empty field");

                Console.WriteLine("priref does not exist, defaulting to empty field");
                obj.priref = "empty_field";
            }


            try
            {
                obj.objectNumber = objectNumber[0].InnerText.ToString();
            }
            catch
            {

                App.WriteErrorString("objectNumber does not exist, defaulting to empty field");

                Console.WriteLine("objectNumber does not exist, defaulting to empty field");
                obj.objectNumber = "empty_field";
            }


            try
            {
                obj.date_start = date_start[0].InnerText.ToString();
            }
            catch
            {

                App.WriteErrorString("date_start does not exist, defaulting to empty field");

                Console.WriteLine("date_start does not exist, defaulting to empty field");
                obj.date_start = "empty_field";
            }

            try
            {
                obj.date_end = date_end[0].InnerText.ToString();
            }
            catch
            {

                App.WriteErrorString("date_end does not exist, defaulting to empty field");

                Console.WriteLine("date_end does not exist, defaulting to empty field");
                obj.date_end = "empty_field";
            }


            try
            {
                obj.objectPlacing = objectPlacing[0].InnerText.ToString();
            }
            catch
            {

                App.WriteErrorString("objectPlacingA does not exist, defaulting to empty field");

                Console.WriteLine("objectPlacingA does not exist, defaulting to empty field");
                obj.objectPlacing = "empty_field";

            }

            #endregion OBJECTS WITHOUT MULTIPLE OCCURENCES










            /*


            try
            {
                obj.creatorRole = creatorRole[0].InnerText.ToString();
            }
            catch
            {
                Console.WriteLine("creatorRole does not exist, defaulting to empty field");
                obj.creatorRole = "empty_field";
            }

    
        
            */
      

            #region OBJECTS WITH MULTIPLE OCCURENCES

            // Hier worden de onderdelen met meerdere waardes vertaald


            // MATERIAL
            try
            {
                if (material.Count == 0)
                {
                    // No materials
                  
                }else if (material.Count == 1)
                {
                    Material mat = new Material();
                    mat.material = material[0].InnerText;
                    mat.externalLink = "no-external-link";

                    obj.material.Add(mat);
                }
                else if (material.Count > 1)
                {
                    string materialstring = "";
                    Console.WriteLine("Meerdere materials");


                    foreach (XmlNode node in material)
                    {
                        Material mat = new Material();
                        mat.material = node.InnerText;
                        mat.externalLink = "no-external-link";

                        obj.material.Add(mat);

                    }

                }
            }
            catch
            {
                App.WriteErrorString("Can't create MO Material list");

            }
            // EIND MATERIAL


            // OBJECTNAME
            try
            {
                if (objectName.Count == 0)
                {
                    // No object name
                }
                else if (objectName.Count == 1)
                {
                    ObjectName name = new ObjectName();
                    name.objectname = objectName[0].InnerText;
                    name.externalLink = "no-external-link";
                    obj.objectName.Add(name);

                }
                else if (objectName.Count > 1)
                {
              
              
                 

                    foreach (XmlNode node in objectName)
                    {
                        ObjectName name = new ObjectName();
                        name.objectname = node.InnerText;
                        name.externalLink = "no-external-link";
                        obj.objectName.Add(name);
                    }

                }
            }
            catch
            {
                App.WriteErrorString("Can't create MO ObjectName list");

            }

            // EIND OBJECTNAME

            // MANUFACTURER

            try
            {
                if (manufacturer.Count == 0)
                {
                    // No manufacturer name
                }
                else if (manufacturer.Count == 1)
                {
                    Manufacturer manu = new Manufacturer();
                    manu.manufacturer = manufacturer[0].InnerText;
                    manu.externalLink = "no-external-link";
                    obj.manufacturer.Add(manu);


                }
                else if (manufacturer.Count > 1)
                {

                    foreach (XmlNode node in manufacturer)
                    {

                        Manufacturer manu = new Manufacturer();
                        manu.manufacturer = node.InnerText;
                        manu.externalLink = "no-external-link";
                        obj.manufacturer.Add(manu);

                    }

                }
            }
            catch
            {
                App.WriteErrorString("Can't create MO Manufacturer list");

            }


            // EIND MANUFACTURER

            // CREATOR

            try
            {
                if (creator.Count == 0)
                {
                    Console.WriteLine("NO CREATOR!!!!!!!");
                    // No object name
                }
                else if (creator.Count == 1)
                {
                    Console.WriteLine("ONLY ONE CREATOR!!!!!!!");
                    Creator crea = new Creator();
                    crea.creator = creator[0].InnerText;
                    crea.externalLink = "no-external-link";

                    try
                    {
                        crea.creatorRole = creatorRole[0].InnerText;
                    }
                    catch
                    {
                        crea.creatorRole = "no-role";
                    }
                    
                    obj.creator.Add(crea);
                    

                }
                else if (creator.Count > 1)
                {
                    Console.WriteLine("MULTIPLE CREATOR!!!!!!!");
                    try
                    {
                        foreach (XmlNode node in creatorRole)
                        {
                            CreatorRoles role = new CreatorRoles();
                            role.creatorRole = node.InnerText;
                            tempCreatorRoles.Add(role);
                        }
                    }
                    catch
                    {
                        CreatorRoles role = new CreatorRoles();
                        role.creatorRole = "not-specified";
                        tempCreatorRoles.Add(role);
                    }

                    int index = 0;
                    foreach (XmlNode node in creator)
                    {

                        Creator crea = new Creator();
                        crea.creator = node.InnerText;
                        crea.externalLink = "no-external-link";
                        crea.creatorRole = tempCreatorRoles[index].creatorRole;
                        obj.creator.Add(crea);
                        index++;
                    }

                }
            }
            catch
            {
                App.WriteErrorString("Can't create MO creatorrole list");

            }


            // EIND CREATOR

            // PRODUCTION PLACE

            try
            {
                if (productionPlace.Count == 0)
                {
                    // No object name
                }
                else if (productionPlace.Count == 1)
                {
                    ProductionPlace place = new ProductionPlace();
                    place.place = productionPlace[0].InnerText;
                    place.externalLink = "no-external-link";
                    obj.productionPlace.Add(place);


                }
                else if (productionPlace.Count > 1)
                {

                    foreach (XmlNode node in productionPlace)
                    {

                        ProductionPlace place = new ProductionPlace();
                        place.place = node.InnerText;
                        place.externalLink = "no-external-link";
                        obj.productionPlace.Add(place);

                    }

                }
            }
            catch
            {
                App.WriteErrorString("Can't create MO productionplace list");

            }


            // EIND PRODUCTION PLACE


            // COLLECTION

            try
            {
                if (collection.Count == 0)
                {
                    // No object name
                }
                else if (collection.Count == 1)
                {
                    Collection col = new Collection();

                    col.collection = collection[0].InnerText;
                    col.externalLink = "no-external-link";
                    obj.collection.Add(col);


                }
                else if (collection.Count > 1)
                {

                    foreach (XmlNode node in collection)
                    {

                        Collection col = new Collection();

                        col.collection = node.InnerText;
                        col.externalLink = "no-external-link";
                        obj.collection.Add(col);

                    }

                }
            }
            catch
            {
                App.WriteErrorString("Can't create MO collection list");

            }


            // EIND COLLECTION



            // MEASUREMENTS


            if (dimensionType.Count == 1)
            {

                Dimension dim = new Dimension();
                dim.dimensionType = dimensionType[0].InnerText;

                try
                {
                    dim.dimensionUnit = dimensionUnit[0].InnerText;
                }
                catch
                {
                    dim.dimensionUnit = "empty-field";
                }

                try
                {
                    dim.dimensionValue = dimensionValue[0].InnerText;
                }
                catch
                {
                    dim.dimensionValue = "empty-field";
                }


            }else if (dimensionType.Count > 1)
            {

                try
                {
                    foreach (XmlNode node in dimensionUnit)
                    {
                        tempDimensionUnit.Add(node.InnerText);
                    }
                }
                catch
                {
                    tempDimensionUnit.Add("empty-field");
                }

                try
                {
                    foreach (XmlNode node in dimensionValue)
                    {
                        tempDimensionValue.Add(node.InnerText);
                    }
                }
                catch
                {
                    tempDimensionValue.Add("empty-field");
                }

                try
                {
                    int index = 0;

                    foreach (XmlNode node in dimensionType)
                    {
                        Dimension dim = new Dimension();
                        dim.dimensionType = node.InnerText;
                        dim.dimensionValue = tempDimensionValue[index];
                        dim.dimensionUnit = tempDimensionUnit[index];
                        obj.dimensions.Add(dim);

                        index++;
                    }
                }
                catch
                {
                    App.WriteErrorString("Can't create MO dimensions list");

                }



            }




            // END MEASUREMENTS

      

            #endregion OBJECTS WITH MULTIPLE OCCURENCES



            // Process images
            try
            {
                foreach (XmlNode node in media)
                {
                    CollectionImage img = new CollectionImage();
                    
                    string imageName = node.InnerText;


                    if (imageName.Contains(@"\images_Continium"))
                    {
                        string newName = imageName.Replace(@"\images_Continium", "images_Continium");
                        img.imageUrl = Configuration.adlibImageDatabaseUrl + newName;
                        img.imageName = node.InnerText;
                        obj.images.Add(img);
                    }


                }
                    
            }
            catch
            {
                App.WriteErrorString("Can't create MO images list");
            }



            JsonSerializerSettings settings = new JsonSerializerSettings();
        
            string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(@json);
            App.collectionList.collectionList.Add(obj);


        }

        public static void ConvertMultiple(string adlibJson)
		{


		}


	}
}





