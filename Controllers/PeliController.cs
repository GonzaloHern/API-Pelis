using Pelis_API.Models;
using Pelis_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Pelis_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PeliController : ControllerBase
{
    public PeliController(){

    }

    [HttpGet]
    public ActionResult<List<Peli>> GetAll() =>
    PeliService.GetAll();

    //GET Id
    [HttpGet("{id}")]
    public ActionResult<Peli> Get(int id){
        var peli = PeliService.Get(id);

        if(peli == null){
            return NotFound();
        }
        return peli;    //<== Si no encuentra return el get marcará error
    }

    //POST o Crear
    [HttpPost]
    public IActionResult Create(Peli peli){
        PeliService.Add(peli);
        return CreatedAtAction(nameof(Get), new { id = peli.Id}, peli);
    }

    //PUT o Modificar
    [HttpPut("{id}")]
    public IActionResult Update(int id, Peli peli){
        if(id != peli.Id)
            return BadRequest();

        var existingPeli = PeliService.Get(id);
        if(existingPeli is null)
            return NotFound();

        PeliService.Update(peli);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var peli = PeliService.Get(id);

        if(peli is null)
            return NotFound();

        PeliService.Delete(id);
        return NoContent();
    }
}