using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.CursoMvc.Domain.Model
{
    // Não pode ser instanciada, somente herdada
    // O Guid é gerado e todas as referências já são criadas antes do objeto ser criado
    // Todas as classes de domínio herdarão da classe Entity
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
