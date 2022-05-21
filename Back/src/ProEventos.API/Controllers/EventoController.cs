using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {

        }

        public readonly IEnumerable<Evento> _evento = new Evento[]{
            new Evento()
            {
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Belo Horizonte",
                Lote = "1 lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString()
            },
            new Evento()
            {
                EventoId = 2,
                Tema = "Angular 22 e .NET 2",
                Local = "Blumenau",
                Lote = "3 lote",
                QtdPessoas = 1000,
                DataEvento = DateTime.Now.AddDays(50).ToString()
            }
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }
        [HttpPost]
        public IEnumerable<Evento> Post()
        {
            return _evento;
        }
        [HttpPut("{id}")]
        public IEnumerable<Evento> Put(int id)
        {
            return _evento;
        }
        [HttpDelete("{id}")]
        public IEnumerable<Evento> Delete(int id)
        {
            return _evento;
        }
    }
}
