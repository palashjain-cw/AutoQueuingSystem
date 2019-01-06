using Dapper;
using Entities;
using Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AutoBookDAL : IAutoBookInterface
    {
        private string _connString = ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;
        public List<BookingStatus> GetDriverBookingStatus(int driverId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("driverId", driverId);
                var query = @"select Id as RequestId,UserId,status,timeOfBooking as BookingTime,
                                timeOfPickUp as PickedUpTime, timeOfDrop as CompleteTime from RideDetails
                            where status = 1 OR (DriverId = @driverId) order by status asc;";
                using (IDbConnection conn = new MySqlConnection(_connString))
                {
                    return conn.Query<BookingStatus>(query, param, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool BookRide(int userId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("userId", userId);
                param.Add("status", (int)BookingStatusEnum.Waiting);
                var query = @"Insert into assignment.RideDetails (userId,timeOfBooking,status)
                    values(@userId,NOW(),@status);";
                using (IDbConnection conn = new MySqlConnection(_connString))
                {
                    return conn.Execute(query, param, commandType: CommandType.Text) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<BookingStatus> GetAllBookingDetails()
        {
            try
            {
                var query = @"select Id as RequestId,UserId,status,timeOfBooking as BookingTime, DriverId from RideDetails
                             order by Id desc;";
                using (IDbConnection conn = new MySqlConnection(_connString))
                {
                    return conn.Query<BookingStatus>(query, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ConfirmRide(int requestId, int driverId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("requestId", requestId);
                param.Add("driverId", driverId);
                var query = @"Update RideDetails 
                                set DriverId = @driverId
                                 where Id= @requestId and DriverId is null";
                using (IDbConnection conn = new MySqlConnection(_connString))
                {
                    return conn.Execute(query, param, commandType: CommandType.Text) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }



    }
}
