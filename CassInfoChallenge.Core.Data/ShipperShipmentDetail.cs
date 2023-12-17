using System;
using System.Collections.Generic;
using System.Text;

namespace CassInfoChallenge.Core.Data
{
  public class ShipperShipmentDetail
  {
    public int shipment_id { get; set; }
    public string shipper_name { get; set; }
    public string carrier_name { get; set; }
    public string shipment_description { get; set; }
    public decimal shipment_weight { get; set; }
    public string shipment_rate_description { get; set; }
  }
}
