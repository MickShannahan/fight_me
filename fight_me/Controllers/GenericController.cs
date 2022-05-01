using System.Collections.Generic;
using fight_me.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fight_me.Controllers
{
  [Route("api/data/{type}")]
    public class GenericController : ControllerBase
    {
        private readonly GenericService _service;

    public GenericController(GenericService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<List<object>> GetAll(string type, string search)
    {
      try
      {
        return Ok(_service.GetAll(type, search));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

     [HttpGet("{id}")]
    public ActionResult<object> GetById(string type, int id)
    {
      try
      {
        return Ok(_service.GetById(type, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

      [HttpPost]
      [Authorize]
    public ActionResult<object> Create(string type, [FromBody] object body)
    {
      try
      {
        return Ok(_service.Create(type, body));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

      [HttpPut("{id}")]
      [Authorize]
    public ActionResult<object> Update(string type, int id, [FromBody] object body)
    {
      try
      {
        return Ok(_service.Update(type, id, body));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

      [HttpDelete("{id}")]
      [Authorize]
    public ActionResult<string> Delete(string type, int id)
    {
      try
      {
        return Ok(_service.Delete(type, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}