using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CassInfoChallenge.Core.Api.Models;
using CassInfoChallenge.Core.Data;

namespace CassInfoChallenge.Core.Api.Controllers
{
  [Route("api/shippers")]
  [ApiController]
  public class ShipperController : Controller
  {
    private readonly IShipperRepository _shipperRepository;

    public ShipperController(IShipperRepository shipperRepository)
    {
      _shipperRepository = shipperRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllShippers()
    {
      var shippers = _shipperRepository.GetAllShippers();
      return Ok(shippers);
    }

    [HttpGet("{id}", Name = "ShipperShipmentById")]
    public async Task<IActionResult> GetShipperShipmentDetail(int id)
    {
      var shipperShipment = _shipperRepository.GetShipperShipmentsDetail(id);
      return Ok(shipperShipment);
    }

  }
}
