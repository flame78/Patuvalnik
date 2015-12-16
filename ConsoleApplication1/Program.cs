using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var r =
              "[{\"id\":32516,\"facebook_trip_id\":66156,\"driver_profile_id\":7936,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-16T00:00:00.000+02:00\",\"end_time\":\"2015-12-16T23:59:59.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":null,\"driver_profile\":{\"user\":{\"id\":15248,\"fb_id\":\"912076222191611\",\"real_fb_id\":null,\"name\":\"Vencislav Parunev\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32679,\"facebook_trip_id\":66579,\"driver_profile_id\":8166,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-16T15:30:00.000+02:00\",\"end_time\":\"2015-12-16T16:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":null,\"driver_profile\":{\"user\":{\"id\":671,\"fb_id\":\"802663076515767\",\"real_fb_id\":\"100003162474625\",\"name\":\"Ивон Иванова\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32771,\"facebook_trip_id\":66809,\"driver_profile_id\":4480,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-16T19:00:00.000+02:00\",\"end_time\":\"2015-12-16T19:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":null,\"driver_profile\":{\"user\":{\"id\":8560,\"fb_id\":\"10204060131978647\",\"real_fb_id\":null,\"name\":\"Angel Harizanov\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32714,\"facebook_trip_id\":66652,\"driver_profile_id\":147,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-16T20:00:00.000+02:00\",\"end_time\":\"2015-12-16T20:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":\"7.0\",\"driver_profile\":{\"user\":{\"id\":1021,\"fb_id\":\"981008081911982\",\"real_fb_id\":null,\"name\":\"Pavel Gyurushev\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32500,\"facebook_trip_id\":66827,\"driver_profile_id\":2470,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-16T21:45:00.000+02:00\",\"end_time\":\"2015-12-16T21:45:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":null,\"driver_profile\":{\"user\":{\"id\":4509,\"fb_id\":\"913965848671213\",\"real_fb_id\":\"100001734196722\",\"name\":\"Ventsislav Hadji Toromanov\"},\"rating\":\"5.0\",\"ratings_count\":2}},{\"id\":32749,\"facebook_trip_id\":66751,\"driver_profile_id\":217,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-17T00:00:00.000+02:00\",\"end_time\":\"2015-12-17T00:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":4,\"seats_left\":4,\"price\":null,\"driver_profile\":{\"user\":{\"id\":1086,\"fb_id\":\"117107558625016\",\"real_fb_id\":\"100009773162489\",\"name\":\"Краси Ст. Христев\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32583,\"facebook_trip_id\":66341,\"driver_profile_id\":3297,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-17T06:00:00.000+02:00\",\"end_time\":\"2015-12-17T06:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":null,\"driver_profile\":{\"user\":{\"id\":6177,\"fb_id\":\"889100177838184\",\"real_fb_id\":\"100002146310177\",\"name\":\"Николай Атанасов\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32783,\"facebook_trip_id\":66843,\"driver_profile_id\":407,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-17T07:00:00.000+02:00\",\"end_time\":\"2015-12-17T07:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":\"7.0\",\"driver_profile\":{\"user\":{\"id\":1265,\"fb_id\":\"964631100223760\",\"real_fb_id\":\"100000306363533\",\"name\":\"Vladimir Dobrev\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32763,\"facebook_trip_id\":66786,\"driver_profile_id\":149,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-17T08:00:00.000+02:00\",\"end_time\":\"2015-12-17T08:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":null,\"driver_profile\":{\"user\":{\"id\":1023,\"fb_id\":\"992038104163288\",\"real_fb_id\":\"100000713233018\",\"name\":\"Daniel Popov\"},\"rating\":null,\"ratings_count\":null}},{\"id\":32777,\"facebook_trip_id\":66828,\"driver_profile_id\":8175,\"car_id\":null,\"route_id\":null,\"from_city_id\":2,\"to_city_id\":1,\"start_time\":\"2015-12-17T09:00:00.000+02:00\",\"end_time\":\"2015-12-17T15:00:00.000+02:00\",\"status\":\"OPEN\",\"confirm_type\":\"AUTO\",\"trip_time\":null,\"seats\":3,\"seats_left\":3,\"price\":null,\"driver_profile\":{\"user\":{\"id\":15748,\"fb_id\":\"10205548638820329\",\"real_fb_id\":null,\"name\":\"Viktor Valkov\"},\"rating\":null,\"ratings_count\":null}}]";

            var resultObj = JsonConvert.DeserializeObject<List<Trip>>(r);

            //         DeserializeJson()

            var a = 5;

            //           string dbgString = string.Format("Business Name: {0}\rCity: {1}\rBusiness Phone: {2}\rAverage Rating: {3}", resultObj.businesses[0].name, resultObj.businesses[0].city, resultObj.businesses[0].phone, resultObj.businesses[0].avg_rating);
            //           Debug.WriteLine(dbgString);
        }
    }

    class Trip
    {
        public int Id { get; set; }

        public int Facebook_trip_id { get; set; }

        public int Driver_profile_id { get; set; }

        public int? Car_id { get; set; }

        public int? Route_id { get; set; }

        public int From_city_id { get; set; }

        public int To_city_id { get; set; }

        public DateTime Start_time { get; set; }

        public DateTime End_time { get; set; }

        public string Status { get; set; }

        public string Confirm_type { get; set; }

        public DateTime? Trip_time { get; set; }

        public int Seats { get; set; }

        public int Seats_left { get; set; }

        public decimal? Price { get; set; }

        public DriverProfile Driver_profile { get; set; }

    }

    class DriverProfile
    {
        public User User { get; set; }
        public string Rating { get; set; }

        public int? Ratings_count { get; set; }
    }

    class User
    {
        public int Id { get; set; }

        public ulong Fb_id { get; set; }

        public ulong? Real_fb_id { get; set; }

        public string Name { get; set; }
    }
}
