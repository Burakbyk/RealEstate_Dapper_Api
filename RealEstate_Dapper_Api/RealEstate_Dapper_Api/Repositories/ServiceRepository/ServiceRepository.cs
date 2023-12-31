﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateStatisticDto createServiceDto)
        {
            string query = "insert into Services (ServiceName,ServiceStatus) values (@serviceName,@serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createServiceDto.SerivceName);
            parameters.Add("@serviceStatus", createServiceDto.ServiceStatus);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            
            
            }
            



        }

        public async void DeleteService(int id)
        {
            string query = "Delete From Services Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            
            }
        }

        public async Task<List<ResultStatisticDto>> GetAllServiceAsync()
        {
            string query = "Select * From Services";
            using(var connection = _context.CreateConnection())
            {
              var values =  await connection.QueryAsync<ResultStatisticDto>(query);

              return values.ToList();
            
            
            }


        }

        public async Task<GetByIdStatisticDto> GetServiceAsync(int id)
        {
            string query = "Select * From Services Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);

            using( var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdStatisticDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateService(UpdateStatisticDto updateServiceDto)
        {
            string query = "Update Services Set ServiceName=@serviceName,ServiceStatus=@serviceStatus Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", updateServiceDto.ServiceName);
            parameters.Add("@serviceStatus",updateServiceDto.ServiceStatus);
            parameters.Add("@serviceID", updateServiceDto.ServiceID);

            using ( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            
            }

        }
    }
}
