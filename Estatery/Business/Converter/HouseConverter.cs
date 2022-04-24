using Dtos.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public class HouseConverter : IHouseConverter
    {
        public House HouseDtoToHouse(AddHouseRequest houseRequest)
        {
            // TODO:1 SalesType Set edilmeli.
            House house = new House();  
            house.CreatedAt = DateTime.Now;
            house.UpdatedAt = DateTime.Now;
            house.Advertiser = houseRequest.Advertiser;
            house.ConstructionYear = houseRequest.ConstructionYear;
            house.NumberOfBath = houseRequest.NumberOfBath;
            house.NumberOfRooms = houseRequest.NumberOfRooms;
            house.SquareMeter = houseRequest.SquareMeter;
            house.LocationId = houseRequest.LocationId;
            house.SalesTypeId = houseRequest.SalesTypeId;
            house.SalesCategoryId = 2;
            return house;
        }

    }
}
