using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CassInfoChallenge.Core.Data;
using Microsoft.Data.SqlClient;

namespace CassInfoChallenge.Core.Api.Models
{
  public class ShipperRepository : IShipperRepository
  {
    private readonly DapperContext _context;
  
    public ShipperRepository(DapperContext context)
    {
      _context = context;
    }

    public IEnumerable<Shipper> GetAllShippers()
    {
      List<Shipper> shippers = new List<Shipper>();

      var query = "SELECT shipper_id as ID, shipper_name as Name FROM Shipper order by shipper_name";
      using (var connection = _context.CreateConnection())
      {
        connection.Open();
        var cmd =  connection.CreateCommand();
        cmd.CommandText = query;

        var reader = cmd.ExecuteReader();

        if (reader != null)
        {
          while (reader.Read())
          {
            shippers.Add(new Shipper()
            {
              ID = reader.GetInt32(reader.GetOrdinal("ID")),
              Name = reader.GetString(reader.GetOrdinal("Name"))
            });
          }
        }

        if (!reader.IsClosed)
          reader.Close();

        connection.Close();

        return shippers.Select(i=>i);
      }
     
    }

    public IEnumerable<ShipperShipmentDetail> GetShipperShipmentsDetail(int id)
    {
      List<ShipperShipmentDetail> shipments = new List<ShipperShipmentDetail>();

      var query = "shipper_shipment_details";
      using (var connection = _context.CreateConnection())
      {
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = query;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@shipper_id", id));

        var reader = cmd.ExecuteReader();

        if (reader != null)
        {
          while (reader.Read())
          {
            shipments.Add(new ShipperShipmentDetail()
            {
              shipment_id = reader.GetInt32(reader.GetOrdinal("shipment_id")),
              shipper_name = reader.GetString(reader.GetOrdinal("shipper_name")),
              carrier_name = reader.GetString(reader.GetOrdinal("carrier_name")),
              shipment_description = reader.GetString(reader.GetOrdinal("shipment_description")),
              shipment_weight = reader.GetDecimal(reader.GetOrdinal("shipment_weight")),
              shipment_rate_description = reader.GetString(reader.GetOrdinal("shipment_rate_description"))
            });
          }
        }

        if (!reader.IsClosed)
          reader.Close();

        connection.Close();

        return shipments.Select(i => i);
      }
    }
  }
}
