﻿namespace RealEstate_Dapper_Api.Dtos.LocationDtos
{ 
    public class ResultLocationDto
    {
        public int LocationID { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }

        public int HowManyEstateIn { get; set; }

        public string LocationImage { get; set; }

    }
}
