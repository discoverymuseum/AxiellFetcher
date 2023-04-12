using System;
using Newtonsoft.Json;
using FetchingServer.Objects;
using System.Xml;


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


			XmlDocument xDoc = new XmlDocument();
			xDoc.LoadXml(response.data);

			XmlNodeList id = xDoc.GetElementsByTagName("id");
			XmlNodeList guid = xDoc.GetElementsByTagName("guid");
			XmlNodeList priref = xDoc.GetElementsByTagName("priref");
			XmlNodeList objectTitle = xDoc.GetElementsByTagName("title");
            XmlNodeList objectName = xDoc.GetElementsByTagName("object_name");
			XmlNodeList objectNumber = xDoc.GetElementsByTagName("object_number");
            XmlNodeList objectCategory = xDoc.GetElementsByTagName("object_category");
            XmlNodeList objectPlacingA = xDoc.GetElementsByTagName("objectplacinga");
			XmlNodeList objectPlacingB = xDoc.GetElementsByTagName("objectplacingb");
			XmlNodeList manufacturer = xDoc.GetElementsByTagName("manufacturer");

			XmlNodeList creator = xDoc.GetElementsByTagName("creator");
            XmlNodeList creatorRole = xDoc.GetElementsByTagName("creator.role");
            XmlNodeList productionPlace = xDoc.GetElementsByTagName("production.place");


            XmlNodeList date_start = xDoc.GetElementsByTagName("dating.date.start");
			XmlNodeList date_end = xDoc.GetElementsByTagName("dating.date.end");
			XmlNodeList material = xDoc.GetElementsByTagName("material");
            XmlNodeList dim = xDoc.GetElementsByTagName("dimension.unit");
            XmlNodeList media = xDoc.GetElementsByTagName("media.reference");
            XmlNodeList description = xDoc.GetElementsByTagName("label.text");

            XmlNodeList PIDWorkURI = xDoc.GetElementsByTagName("PID_work_URI");
            XmlNodeList PIDWorkURL = xDoc.GetElementsByTagName("PID_work_URL");


            // TEMP STATIC TIMESTAMP DATA
            obj.entry_created = "2021-11-12T06:33:45";
            obj.entry_modified = "2022-12-12T09:19:45";

            Random randLength = new Random();
            int length = randLength.Next(1, 50);

            Random randHeight = new Random();
            int height = randHeight.Next(1, 50);

            Random randWidth = new Random();
            int width = randWidth.Next(1, 50);

            Random randWeight = new Random();
            int weight = randWeight.Next(1, 50);

            // TEMP STATIC MEASUREMENT DATA
            obj.length = length.ToString() + "cm";
            obj.width = width.ToString() + "cm";
            obj.height = height.ToString() + "cm";
            obj.weight = weight.ToString() + "cm";

            try
			{
				obj.id = objectNumber[0].InnerText;
			}
			catch
			{
				Console.WriteLine("ObjectNumber does not exist, defaulting to empty field");
                obj.id = "empty_field";
			}

            try
            {
                obj.description = description[0].InnerText;
            }
            catch
            {
                Console.WriteLine("description does not exist, defaulting to empty field");
                obj.description = "empty_field";
            }

            try
            {
                obj.objectTitle = objectTitle[0].InnerText;
            }
            catch
            {
                Console.WriteLine("objectTitle does not exist, defaulting to empty field");
                obj.objectTitle = "empty_field";
            }

            try
            {
                obj.creatorRole = creatorRole[0].InnerText;
            }
            catch
            {
                Console.WriteLine("creatorRole does not exist, defaulting to empty field");
                obj.creatorRole = "empty_field";
            }

            try
            {
                obj.productionPlace = productionPlace[0].InnerText;
            }
            catch
            {
                Console.WriteLine("productionPlace does not exist, defaulting to empty field");
                obj.productionPlace = "empty_field";
            }

            try
            {
                obj.pid_work_uri = PIDWorkURI[0].InnerText;
            }
            catch
            {
                Console.WriteLine("PIDWorkURI does not exist, defaulting to empty field");
                obj.pid_work_uri = "empty_field";
            }

            try
            {
                obj.pid_work_url = PIDWorkURL[0].InnerText;
            }
            catch
            {
                Console.WriteLine("PIDWorkURL does not exist, defaulting to empty field");
                obj.pid_work_url = "empty_field";
            }


            try
            {
                obj.category = objectCategory[0].InnerText;
            }
            catch
            {
                Console.WriteLine("objectCategory does not exist, defaulting to empty field");
                obj.category = "empty_field";
            }

            try
            {
                obj.guid = guid[0].InnerText;
            }
            catch
            {
                Console.WriteLine("guid does not exist, defaulting to empty field");
                obj.guid = "empty_field";
            }

            try
            {
                obj.priref = priref[0].InnerText;
            }
            catch
            {
                Console.WriteLine("priref does not exist, defaulting to empty field");
                obj.priref = "empty_field";
            }

            try
            {
                obj.objectName = objectName[0].InnerText;
            }
            catch
            {
                Console.WriteLine("objectName does not exist, defaulting to empty field");
                obj.objectName = "empty_field";
            }

            try
            {
                obj.objectNumber = objectNumber[0].InnerText;
            }
            catch
            {
                Console.WriteLine("objectNumber does not exist, defaulting to empty field");
                obj.objectNumber = "empty_field";
            }

            try
            {
                obj.objectPlacingA = objectPlacingA[0].InnerText;
            }
            catch
            {
                Console.WriteLine("objectPlacingA does not exist, defaulting to empty field");
                obj.objectPlacingA = "empty_field";
                
            }

            try
            {
                obj.objectPlacingB = objectPlacingB[0].InnerText;
            }
            catch
            {
                Console.WriteLine("objectPlacingB does not exist, defaulting to empty field");
                obj.objectPlacingB = "empty_field";
            }

            try
            {
                obj.manufacturer = manufacturer[0].InnerText;

            }
            catch
            {
                Console.WriteLine("manufacturer does not exist, defaulting to empty field");
                obj.manufacturer = "empty_field";
            }

            try
            {
                obj.creator = creator[0].InnerText;
            }
            catch
            {
                Console.WriteLine("creator does not exist, defaulting to empty field");
                obj.creator = "empty_field";
            }

            try
            {
                obj.date_start = date_start[0].InnerText;
            }
            catch
            {
                Console.WriteLine("date_start does not exist, defaulting to empty field");
                obj.date_start = "empty_field";
            }

            try
            {
                obj.date_end = date_end[0].InnerText;
            }
            catch
            {
                Console.WriteLine("date_end does not exist, defaulting to empty field");
                obj.date_end = "empty_field";
            }


            // Hier worden de onderdelen met meerdere waardes vertaald


            // MATERIAL
            try
            {
                if (material.Count == 0)
                {
                    Console.WriteLine("Geen material");
                    obj.material = "onbekend";
                }else if (material.Count == 1)
                {
                    Console.WriteLine("1 material");
                    obj.material = material[0].InnerText;
                }
                else if (material.Count > 1)
                {
                    string materialstring = "";
                    Console.WriteLine("Meerdere materials");
                    int count = 0;
                    int max = material.Count;

                    foreach (XmlNode node in material)
                    {
                        if (count < max -1)
                        {
                            materialstring += node.InnerText + ",";
                        }
                        else
                        {
                            materialstring += node.InnerText;
                        }

                        count++;
                    }

                    obj.material = materialstring;
                }
            }
            catch
            {
                obj.material = "empty_field";
            }
            // EIND MATERIAL


            // OBJECTNAME
            try
            {
                if (objectName.Count == 0)
                {
                    Console.WriteLine("Geen objectName");
                    obj.objectName = "onbekend";
                }
                else if (objectName.Count == 1)
                {
                    Console.WriteLine("1 objectName");
                    obj.objectName = objectName[0].InnerText;
                }
                else if (objectName.Count > 1)
                {
                    string objectnamestring = "";
                    Console.WriteLine("Meerdere objectnames");
                    int count = 0;
                    int max = objectName.Count;

                    foreach (XmlNode node in objectName)
                    {
                        if (count < max - 1)
                        {
                            objectnamestring += node.InnerText + ",";
                        }
                        else
                        {
                            objectnamestring += node.InnerText;
                        }

                        count++;
                    }

                    obj.objectName = objectnamestring;
                }
            }
            catch
            {
                obj.objectName = "empty_field";
            }

            // EIND OBJECTNAME






            // Process images
            try
            {
                foreach (XmlNode node in media)
                {
                    CollectionImage img = new CollectionImage();

                    string imageName = node.InnerText;


                    img.imageUrl = Configuration.adlibImageDatabaseUrl + imageName;
                    img.imageName = node.InnerText;

                    obj.images.Add(img);
                }
                    
            }
            catch
            {

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