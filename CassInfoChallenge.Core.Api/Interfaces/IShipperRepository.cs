using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CassInfoChallenge.Core.Data;

namespace CassInfoChallenge.Core.Api.Models
{
  public interface IShipperRepository
  {    
    IEnumerable<Shipper> GetAllShippers();

    IEnumerable<ShipperShipmentDetail> GetShipperShipmentsDetail(int id);
  }
}
