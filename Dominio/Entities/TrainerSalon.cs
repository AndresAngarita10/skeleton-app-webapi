using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class TrainerSalon 
    {
        public int IdSalonFk { get; set; }
        public Salon Salon { get; set; }
        public int IdPerTrainerFk { get; set; }
        public Persona Persona { get; set; }
    }
}