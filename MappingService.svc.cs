using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SERVICE_CLIENT_HOST.Models;
using WCF_SERVICE_CLIENT_HOST.Models.MappingModels;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MappingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MappingService.svc or MappingService.svc.cs at the Solution Explorer and start debugging.
    public class MappingService : IMappingService
    {
        private string API_KEY = "AIzaSyCuwFnnkw8PszXyvaq3OBY2S4gmhoJ61-I";
        public string getStringToMap(string campusId, string accommoId)
        {
            ADDRESS fromAddressObj = null;
            ADDRESS toAddressObj = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innJoin1 =
                        from campus in db.CITies
                        where campus.CITY_ID.Equals(Convert.ToInt32(campusId))
                        join address in db.ADDRESSes on campus.ADDRESS_ID equals address.ADDRESS_ID
                        select address;

                    var innJoin2 =
                        from acc in db.HOTELs
                        where acc.HOTEL_ID.Equals(Convert.ToInt32(accommoId))
                        join address in db.ADDRESSes on acc.ADDRESS_ID equals address.ADDRESS_ID
                        select address;

                    fromAddressObj = innJoin1.Single();
                    toAddressObj = innJoin2.Single();

                    string fromAddress = fromAddressObj.STREET + " " + fromAddressObj.TOWN + " " + fromAddressObj.CITY;
                    string toAddress = toAddressObj.STREET + " " + toAddressObj.TOWN + " " + toAddressObj.CITY;

                    return fromAddress + " to " + toAddress;
                }
            }
            catch (Exception)
            {
                return "Failed Cannot map to and from addresses";
            }
        }

        public List<Address> getAllAccommoAddressesByCampus(string campusAbbrev)
        {
            List<Address> addrList = null;
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innJoin1 =
                        from acc in db.HOTELs
                        where acc.NEAREST_TOWN.Equals(campusAbbrev.ToUpper())
                        join address in db.ADDRESSes on acc.ADDRESS_ID equals address.ADDRESS_ID
                        select new Address
                        {
                            Street = address.STREET,
                            City = address.CITY,
                            Town = address.TOWN,
                            PostalCode = address.POSTAL_CODE,
                            Lattitude = address.LATITUDE,
                            Longitude = address.LONGTUDE,
                           InfoUrl = address.INFO_URL
                        };

                    addrList = new List<Address>();

                    foreach (Address addr in innJoin1)
                    {
                        addrList.Add(addr);
                    }

                    return addrList;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string updateAllCoordinatesInDb()
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    List<string> result = new List<string>();
                    List<ADDRESS> listAddr = new List<ADDRESS>();

                    var query = from a in db.ADDRESSes select a;
                    listAddr = query.ToList();

                    foreach (ADDRESS add in listAddr)
                    {
                        if (add.LATITUDE == null || add.LONGTUDE == null)
                        {
                            result = getLatLong(add.STREET, add.TOWN, add.CITY);
                            //Equate the ff to the result of the above
                            string lng = "";
                            string lat = "";
                            if (result.Count() == 2)
                            {
                                lat = result[0];
                                lng = result[1];
                            }
                            add.LONGTUDE = lng;
                            add.LATITUDE = lat;
                        }
                    }
                    db.SubmitChanges();
                }

                return "Success All coordinates updated";
            }
            catch (Exception)
            {
                return "Failed";
            }

        }

        public List<Address> getAllAddresses()
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    return db.ADDRESSes.Select(address => new Address
                    {
                        AddressID = address.ADDRESS_ID,
                        Street = address.STREET,
                        City = address.CITY,
                        Town = address.TOWN,
                        PostalCode = address.POSTAL_CODE,
                        Lattitude = address.LATITUDE,
                        Longitude = address.LONGTUDE,
                        InfoUrl = address.INFO_URL
                    }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Address getAddressById(string id)
        {
            try
            {
                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    var innerJoinQuery =
                    from address in db.ADDRESSes
                    where address.ADDRESS_ID.Equals(Convert.ToInt32(id))
                    select new Address
                    {
                        AddressID = address.ADDRESS_ID,
                        Street = address.STREET,
                        City = address.CITY,
                        Town = address.TOWN,
                        PostalCode = address.POSTAL_CODE,
                        Lattitude = address.LATITUDE,
                        Longitude = address.LONGTUDE,
                        InfoUrl = address.INFO_URL
                    };

                    foreach (Address ca in innerJoinQuery)
                    {
                        return ca;
                    }

                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int insertAddress(Address addr)
        {
            try
            {
                ADDRESS addrLnq = null;

                using (HotelManagementServerDataContext db = new HotelManagementServerDataContext())
                {
                    addrLnq = new ADDRESS();
                    addrLnq = ConvertToLinq.ConvertAddressToLinq(addr);

                    db.ADDRESSes.InsertOnSubmit(addrLnq);

                    db.SubmitChanges();
                    int addrssID = addrLnq.ADDRESS_ID;
                    return addrssID;// "Adding Address was successful";
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<string> getLatLong(string street, string town, string city)
        {
            List<string> diclatlong = new List<string>();
            string geoString = "https://maps.googleapis.com/maps/api/geocode/json?address=" + street + "," + town + "," + city + "&key=" + API_KEY;
            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(geoString);
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    string str = null;
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            str = streamReader.ReadToEnd();
                        }
                    }
                    GeoResponse geoResponse = JsonConvert.DeserializeObject<GeoResponse>(str);
                    if (geoResponse.Status == "OK")
                    {
                        int count = geoResponse.Results.Length;
                        for (int i = 0; i < count; i++)
                        {
                            diclatlong.Add(geoResponse.Results[i].Geometry.Location.Lat.ToString());
                            diclatlong.Add(geoResponse.Results[i].Geometry.Location.Lng.ToString());
                        }
                    }
                    else
                    {
                        diclatlong = null;
                    }
                }
            }
            catch
            {
                throw new Exception("JSON response failed.");
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
            return diclatlong;
        }

        public double calculateDistance(string Fstreet, string Ftown, string Fcity, string Tstreet, string Ttown, string Tcity)
        {

            string baseString = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=";
            string geoString = baseString + Fstreet + "," + Ftown + "," + Fcity + "&destinations=" + Tstreet + "," + Ttown + "," + Tcity + "&mode=walking&language=eng-ENG&key=" + API_KEY;
            string distance = "";
            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(geoString);
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    string str = null;
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            str = streamReader.ReadToEnd();
                        }
                    }
                    MatrixResponse responseMatrix = JsonConvert.DeserializeObject<MatrixResponse>(str);
                    if (responseMatrix.status == "OK")
                    {
                        int count = responseMatrix.rows.Length;
                        for (int i = 0; i < count; i++)
                        {
                            distance = responseMatrix.rows[i].elements[i].distance.text.ToString();
                        }
                    }
                    string newString = distance.Replace("km", " ");
                    return Convert.ToDouble(newString);
                }
                else
                {
                    return -1.00;
                }
            }
            catch
            {
                throw new Exception("JSON response failed.");
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        public double getDistance(string campusId, string Tstreet, string Ttown, string Tcity)
        {
            try
            {
                string addressId = "";
                if (campusId == "2")
                {
                    addressId = "8";
                }
                if (campusId == "3")
                {
                    addressId = "9";
                }
                if (campusId == "4")
                {
                    addressId = "10";
                }
                if (campusId == "5")
                {
                    addressId = "11";
                }

                Address campusAdd = new Address();
                campusAdd = getAddressById(addressId);
                double result = 0.00;

                result = calculateDistance(campusAdd.Street, campusAdd.Town, campusAdd.City, Tstreet, Ttown, Tcity);

                return result;

            }
            catch (Exception)
            {
                return -1.00;
            }
        }
    }
}
