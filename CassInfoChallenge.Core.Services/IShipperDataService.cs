using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CassInfoChallenge.Core.Data;

namespace CassInfoChallenge.Services
{
  public interface IShipperDataService
  {
    Task<IEnumerable<Shipper>> GetAllShippers();
    Task<IEnumerable<ShipperShipmentDetail>> GetShipperShipmentsDetail(int id);
  }
}
